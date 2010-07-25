using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace XmlVisualizer
{
    public class TextLine
    {
        public float Top;
        public float Bottom;

        public List<TextCharacter> Characters;

        public void Add( Region[] regions, string text )
        {
            for( int i = 0; i < regions.Length; i++ )
                Characters.Add( new TextCharacter() { Character = text[ i ], Region = regions[ i ] } );
        }
        public TextLine( Region[] regions, string text, Graphics g )
        {
            Characters = new List<TextCharacter>();
            Add( regions, text );
            RectangleF bounds = regions[ 0 ].GetBounds( g );
            Top = bounds.Top;
            Bottom = bounds.Bottom;
        }
    }

    public class TextCharacter
    {
        public Region Region;
        public char Character;
    }
}
