using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Drawing.Text;
using System.Diagnostics;

namespace XmlVisualizer
{
    public partial class XmlViewerBox : UserControl
    {
        public XmlElement Element { get; set; }
        public Color TagNameColor { get; set; }
        public Color InnerTextColor { get; set; }
        public Color AttributeNameColor { get; set; }
        public Color AttributeValueColor { get; set; }

        private float LineHeight { get; set; }
        private float Indent { get; set; }
        private float MaxWidth { get; set; }
        private Node RootNode { get; set; }

        private List<Node> _drawnNodes;
        private List<TextLine> _lines;
        private int _currentDrawingLine;
        private bool _inDragMode;
        private List<TextCharacter> _selectedChars;
        private SelectionPoint _selectionStart;
        private SelectionPoint _selectionEnd;
        private SelectionPoint _mouseDownPoint;

        public XmlViewerBox()
        {
            InitializeComponent();
        }

        private void XmlViewerBox_Paint( object sender, PaintEventArgs e )
        {
            if (Element != null)
            {
                using( Bitmap offscreenBitmap = new Bitmap( ClientRectangle.Width, ClientRectangle.Height ) )
                {
                    _drawnNodes = new List<Node>();
                    _currentDrawingLine = 0;
                    _lines = new List<TextLine>();
                    Graphics offscreenGraphics = Graphics.FromImage( offscreenBitmap );
                    using (Brush b = new SolidBrush(this.BackColor))
                    {
                        offscreenGraphics.FillRectangle( b, e.ClipRectangle );                    	
                    }
                    Indent = 25;
                    MaxWidth = 0;
                    LineHeight = offscreenGraphics.MeasureString( "TEST", this.Font ).Height;
                    if (RootNode == null)
                        RootNode = new Node();
                    int rowsAdded = ProcessNode( offscreenGraphics, Element, RootNode, DisplayRectangle.X + 12, DisplayRectangle.Y + 2 );
                    AutoScrollMinSize = new Size( (int)MaxWidth - DisplayRectangle.X, ((rowsAdded + 1) * (int)LineHeight) + 2 );
                    e.Graphics.DrawImage( offscreenBitmap, 0, 0 );
                    offscreenGraphics.Dispose();
                    DrawSelectionBox( e.Graphics, this.ForeColor );
                }
            }
        }

        private float DrawString( Graphics g, Color c, string s, float left, float top )
        {
            StringFormat sf = StringFormat.GenericTypographic;
            using( Brush b = new SolidBrush( c ) )
                g.DrawString( s, this.Font, b, left, top, StringFormat.GenericTypographic );


            //CharacterRange[] ranges = new CharacterRange[ s.Length ];
            //for( int i = 0; i < s.Length; i++ )
            //    ranges[ i ] = new CharacterRange( i, 1 );
            //sf.SetMeasurableCharacterRanges( ranges );

            SizeF stringSize = g.MeasureString( s, this.Font, new PointF( left, top ), sf );
            //Region[] regions = g.MeasureCharacterRanges( s, this.Font, new RectangleF( left, top, stringSize.Width, stringSize.Height ), StringFormat.GenericTypographic );

            //if( _currentDrawingLine == _lines.Count )
            //    _lines.Add( new TextLine( regions, s, g ) );
            //else
            //    _lines[ _currentDrawingLine ].Add( regions, s );

            return stringSize.Width;
        }

        private int ProcessNode( Graphics g, XmlElement xmlNode, Node treeNode, float left, float top )
        {
            int rowsAdded = 1;

            float x = left + DrawString( g, ForeColor, "<", left, top );
            x += DrawString( g, TagNameColor, xmlNode.Name, x, top );

            float attributeOrigin = x;
            foreach( XmlAttribute attr in xmlNode.Attributes )
            {
                string wholeAttribute = string.Format( " {0}=\"{1}\"", attr.Name, attr.Value );
                SizeF stringSize = g.MeasureString( wholeAttribute, this.Font, new PointF( x, top ), StringFormat.GenericTypographic );
                if( stringSize.Width + x > g.VisibleClipBounds.Right )
                {
                    if( x > MaxWidth )
                        MaxWidth = x;
                    top += LineHeight;
                    x = attributeOrigin;
                    _currentDrawingLine++;
                    rowsAdded++;
                }
                x += DrawString( g, AttributeNameColor, string.Format( " {0}", attr.Name ), x, top );
                x += DrawString( g, ForeColor, "=\"", x, top );
                x += DrawString( g, AttributeValueColor, attr.Value, x, top );
                x += DrawString( g, ForeColor, "\"", x, top );                
            }
            if( xmlNode.ChildNodes.Count > 0 && treeNode.Open )
            {
                DrawNodeToggle( treeNode, g, left - 11, top );
                x += DrawString( g, ForeColor, ">", x, top );
                _currentDrawingLine++;
                if( x > MaxWidth )
                    MaxWidth = x;
                
                int subRows = ProcessNodes( g, xmlNode.ChildNodes, treeNode, left + Indent, top + LineHeight );
                rowsAdded += subRows + 1;

                top += (subRows + 1) * LineHeight;
                x = left + DrawString( g, ForeColor, "</", left, top );
                x += DrawString( g, TagNameColor, xmlNode.Name, x, top );
                x += DrawString( g, ForeColor, ">", x, top );
                _currentDrawingLine++;
                if( x > MaxWidth )
                    MaxWidth = x;
            }
            else
            {
                if (xmlNode.ChildNodes.Count > 0)
                    DrawNodeToggle( treeNode, g, left - 11, top );
                x += DrawString( g, ForeColor, "></", x, top );
                x += DrawString( g, TagNameColor, xmlNode.Name, x, top );
                x += DrawString( g, ForeColor, ">", x, top );
                _currentDrawingLine++;

                if( x > MaxWidth )
                    MaxWidth = x;
            }

            return rowsAdded;
        }
        private int ProcessNodes( Graphics g, XmlNodeList nodes, Node treeNode, float left, float top )
        {
            int rowsAdded = 0;
            if (treeNode.SubNodes == null)
            {
                treeNode.SubNodes = new Node[ nodes.Count ];
                for( int i = 0; i < treeNode.SubNodes.Length; i++ )
                {
                    treeNode.SubNodes[ i ] = new Node();
                }
            }
            for( int i = 0; i < nodes.Count; i++ )
            {
                float y = top + (LineHeight * rowsAdded);
                if( nodes[ i ] is XmlElement )
                {
                    rowsAdded += ProcessNode( g, nodes[ i ] as XmlElement, treeNode.SubNodes[i], left, y );
                }
                else
                {
                    rowsAdded++;
                    string text = nodes[ i ].InnerText.Trim();
                    float x = left + DrawString( g, InnerTextColor, text, left, y );
                    _currentDrawingLine++;
                    if( x > MaxWidth )
                        MaxWidth = x;
                }
            }
            return rowsAdded;
        }

        private void DrawNodeToggle( Node node, Graphics g, float left, float top )
        {
            using( Pen p = new Pen(ForeColor))
            {
                g.DrawLine( p, left + 1, top + 1, left + 9, top + 1 );
                g.DrawLine( p, left + 9, top + 1, left + 9, top + 9 );
                g.DrawLine( p, left + 9, top + 9, left + 1, top + 9 );
                g.DrawLine( p, left + 1, top + 9, left + 1, top + 1 );
                g.DrawLine( p, left + 3, top + 5, left + 7, top + 5 );
                if (!node.Open)
                    g.DrawLine( p, left + 5, top + 3, left + 5, top + 7 );
            }
            node.Rect = new RectangleF( left + 1, top + 1, 8, 8 );
            _drawnNodes.Add( node );
        }

        private void DrawSelectionBox( Graphics g, Color c )
        {
            if( _selectionStart != null && _selectionEnd != null )
            {
                using( Pen pen = new Pen( c, 1 ) )
                {
                    if( _selectionStart.Line == _selectionEnd.Line )
                    {
                        DrawSelectionBox( g, pen, _selectionStart.Line, _selectionStart.Character, _selectionEnd.Character );
                    }
                    else
                    {
                        DrawSelectionBox( g, pen, _selectionStart.Line, _selectionStart.Character, 0 );
                        for( int i = _selectionStart.Line + 1; i < _selectionEnd.Line; i++ )
                        {
                            DrawSelectionBox( g, pen, i, 0, 0 );
                        }
                        DrawSelectionBox( g, pen, _selectionEnd.Line, 0, _selectionEnd.Character );
                    }
                }
            }
        }

        private void DrawSelectionBox( Graphics graphics, Pen p, int line, int startCharacter, int endCharacter )
        {
            if( endCharacter == 0 )
                endCharacter = _lines[ line ].Characters.Count - 1;
            RectangleF startingRect = _lines[ line ].Characters[ startCharacter ].Region.GetBounds( graphics );
            RectangleF endingRect = _lines[ line ].Characters[ endCharacter ].Region.GetBounds( graphics );

            Rectangle drawRect = Rectangle.Round( new RectangleF( startingRect.Left, startingRect.Top, endingRect.Right - startingRect.Left, startingRect.Height ) );
            drawRect.Inflate( 1, 1 );
            graphics.DrawRectangle( p, drawRect );

        }

        private void XmlViewerBox_Scroll( object sender, ScrollEventArgs e )
        {
            Refresh();
        }


        private void XmlViewerBox_MouseClick( object sender, MouseEventArgs e )
        {
            foreach( Node node in _drawnNodes )
            {
                if( node.Rect.Contains( e.Location ) )
                {
                    node.Open = !node.Open;
                    Refresh();
                    return;
                }
            }
        }

        private void XmlViewerBox_MouseDown( object sender, MouseEventArgs e )
        {
            SelectionPoint point = GetMousePositionCharacter( e, this.CreateGraphics() );
            if( point != null )
            {
                _inDragMode = true;
                _selectionStart = null;
                _selectionEnd = null;
                _mouseDownPoint = point;
                Refresh();
            }
        }

        private void XmlViewerBox_MouseMove( object sender, MouseEventArgs e )
        {
            if( _inDragMode )
            {
                Graphics g = this.CreateGraphics();
                SelectionPoint point = GetMousePositionCharacter( e, g );
                if( point != null && point != _selectionEnd)
                {
                    SelectionPoint oldStart = _selectionStart;
                    SelectionPoint oldEnd = _selectionEnd;
                    if( point.CompareTo( _mouseDownPoint ) < 0 )
                    {
                        _selectionStart = point;
                        _selectionEnd = _mouseDownPoint;
                    }
                    else
                    {
                        _selectionStart = _mouseDownPoint;
                        _selectionEnd = point;
                    }
                    if( oldStart == null || oldEnd == null || oldStart.CompareTo( _selectionStart ) != 0 || oldEnd.CompareTo(_selectionEnd) != 0 )
                    {
                        Refresh();
                    }
                }
            }

        }

        private SelectionPoint GetMousePositionCharacter( MouseEventArgs e, Graphics g)
        {
            for( int i = 0; i < _lines.Count; i++ )
            {
                if( _lines[ i ].Bottom >= e.Y && _lines[ i ].Top <= e.Y )
                {
                    for( int j = 0; j < _lines[ i ].Characters.Count; j++ )
                    {
                        RectangleF bounds = _lines[ i ].Characters[ j ].Region.GetBounds( g );
                        if( bounds.Contains( e.Location ) )
                            return new SelectionPoint { Line = i, Character = j };
                    }
                }
            }
            return null;
        }
        private void XmlViewerBox_MouseUp( object sender, MouseEventArgs e )
        {
            _inDragMode = false;
        }

        private class Node
        {
            public bool Open { get; set; }
            public Node[] SubNodes { get; set; }
            public RectangleF Rect { get; set; }

            public Node()
            {
                Open = true;
            }
        }

        private class SelectionPoint : IComparable<SelectionPoint>
        {
            public int Line;
            public int Character;


            public int CompareTo( SelectionPoint other )
            {
                int cmp = Line - other.Line;
                if( cmp == 0 )
                    cmp = Character - other.Character;
                return cmp;
            }

        }

        private void XmlViewerBox_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.C && e.Control )
            {
                StringBuilder builder = new StringBuilder();
                for( int i = _selectionStart.Line; i <= _selectionEnd.Line; i++ )
                {
                    int startChar = 0;
                    int endChar = _lines[ i ].Characters.Count() - 1;
                    if( i == _selectionStart.Line )
                        startChar = _selectionStart.Character;
                    if( i == _selectionEnd.Line )
                        endChar = _selectionEnd.Character;
                    for( int j = startChar; j <= endChar; j++ )
                        builder.Append( _lines[ i ].Characters[ j ].Character );
                    builder.Append( Environment.NewLine );
                }
                Clipboard.SetData( DataFormats.StringFormat, builder.ToString() );
            }
        }

    }

}
