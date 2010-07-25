using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace TestXmlVisualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(
                @"<sample>
                    <subnode attr='attribute value'/>
                    <subnode attr='sub 2'>inner text</subnode>
                    <subnode attr='third node'/>
                    <subnode attr='4th'/>
                    <subnode attr='5th'/>
                    <subnode attr='6th'/>
                    <subnode attr='7th'/>
                    <subnode attr='8th'/>
                    <subnode attr='9th'/>
                    <subnode attr='10th'/>
                    <subnode attr='11th'/>
                    <subnode attr='12th'/>
                    <subnode attr='13th'/>
                    <subnode attr='14th'/>
                    sample text
                </sample>" );
            xmlViewerBox1.Element = xml.DocumentElement;
        }

        private void btnSpawn_Click( object sender, EventArgs e )
        {
            Process p = Process.Start( @"D:\work\Utilities\XmlVisualizer\XmlViewer\bin\Debug\XmlViewer.exe" );
            Debug.WriteLine( p );
        }
    }
}
