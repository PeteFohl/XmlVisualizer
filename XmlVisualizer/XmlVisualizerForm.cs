using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace XmlVisualizer
{
    public partial class XmlVisualizerForm : Form
    {
        public XmlVisualizerForm(XmlElement element)
        {
            InitializeComponent();
            xmlViewer.Element = element;
        }

        private void btnSpawn_Click( object sender, EventArgs e )
        {
            string pipeName = Guid.NewGuid().ToString();
            Process.Start( "XmlViewer.exe", pipeName );
            SendXml( pipeName );
        }

        #region Named Pipe

        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern SafeFileHandle CreateFile(
           String pipeName,
           uint dwDesiredAccess,
           uint dwShareMode,
           IntPtr lpSecurityAttributes,
           uint dwCreationDisposition,
           uint dwFlagsAndAttributes,
           IntPtr hTemplate );



        private void SendXml(string pipeName)
        {
            uint GENERIC_READ = (0x80000000);
            uint GENERIC_WRITE = (0x40000000);
            uint OPEN_EXISTING = 3;
            uint FILE_FLAG_OVERLAPPED = (0x40000000);
            int BUFFER_SIZE = 4096;

            int waitCount = 0;
            while(waitCount < 100)
            {
                SafeFileHandle pipeHandle =
                   CreateFile(
                      @"//./pipe/" + pipeName,
                      GENERIC_READ | GENERIC_WRITE,
                      0,
                      IntPtr.Zero,
                      OPEN_EXISTING,
                      FILE_FLAG_OVERLAPPED,
                      IntPtr.Zero );

                //could not get a handle to the named pipe
                if( pipeHandle.IsInvalid )
                {
                    waitCount++;
                    Thread.Sleep( 100 );
                    continue;
                }

                using( FileStream fStream = new FileStream( pipeHandle, FileAccess.ReadWrite, BUFFER_SIZE, true ) )
                {
                    ASCIIEncoding encoder = new ASCIIEncoding();
                    string xmlString = xmlViewer.Element.OuterXml;
                    int i;
                    for( i = 0; i < xmlString.Length - BUFFER_SIZE; i += BUFFER_SIZE )
                    {
                        byte[] messageBuffer = encoder.GetBytes( xmlString.Substring(i,BUFFER_SIZE) );
                        fStream.Write( messageBuffer, 0, messageBuffer.Length );                        
                    }
                    if( i < xmlString.Length )
                    {
                        byte[] messageBuffer = encoder.GetBytes( xmlString.Substring( i ) );
                        fStream.Write( messageBuffer, 0, messageBuffer.Length );
                    }
                    fStream.Flush();
                    break;
                }
            }
        }
        #endregion

    }
}
