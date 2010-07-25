using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace XmlFileViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click( object sender, EventArgs e )
        {
            using( FileDialog dlg = new OpenFileDialog() )
            {
                if( dlg.ShowDialog() == DialogResult.OK )
                {
                    XmlDocument xml = new XmlDocument();
                    using( StreamReader reader = File.OpenText( dlg.FileName ) )
                    {
                        xml.LoadXml( reader.ReadToEnd() );
                        xmlViewerBox1.Element = xml.DocumentElement;
                    }
                }
            }
        }
    }
}
