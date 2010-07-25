using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.IO;

namespace XmlViewer
{
    public partial class Form1 : Form
    {
        public Form1(string pipeName)
        {
            InitializeComponent();
            if( pipeName != null )
                Listen(pipeName);
            //this.Text = String.Format( "Xml Viewer External ({0})", DateTime.Now );
        }

        #region Named Pipes

        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern SafeFileHandle CreateNamedPipe(
           String pipeName,
           uint dwOpenMode,
           uint dwPipeMode,
           uint nMaxInstances,
           uint nOutBufferSize,
           uint nInBufferSize,
           uint nDefaultTimeOut,
           IntPtr lpSecurityAttributes );

        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern int ConnectNamedPipe(
           SafeFileHandle hNamedPipe,
           IntPtr lpOverlapped );


        public const uint DUPLEX = (0x00000003);
        public const uint FILE_FLAG_OVERLAPPED = (0x40000000);

        public const int BUFFER_SIZE = 4096;

        private void Listen(string pipeName)
        {
            SafeFileHandle clientPipeHandle;
            bool gotData = false;
            while( !gotData )
            {
                clientPipeHandle = CreateNamedPipe(
                   @"\\.\pipe\" + pipeName,
                   DUPLEX | FILE_FLAG_OVERLAPPED,
                   0,
                   255,
                   BUFFER_SIZE,
                   BUFFER_SIZE,
                   0,
                   IntPtr.Zero );

                //failed to create named pipe
                if( clientPipeHandle.IsInvalid )
                    break;

                int success = ConnectNamedPipe( clientPipeHandle, IntPtr.Zero );

                //failed to connect client pipe
                if( success != 1 )
                    break;
                //client connection successfull

                using( FileStream fStream = new FileStream( clientPipeHandle, FileAccess.ReadWrite, BUFFER_SIZE, true ) )
                {
                    using( StringWriter writer = new StringWriter() )
                    {
                        byte[] buffer = new byte[ BUFFER_SIZE ];
                        ASCIIEncoding encoder = new ASCIIEncoding();
                        while( true )
                        {
                            int bytesRead = fStream.Read( buffer, 0, BUFFER_SIZE );
                            //could not read from file stream
                            if( bytesRead == 0 )
                                break;
                            writer.Write( encoder.GetString( buffer ) );
                        }
                        gotData = true;
                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml( writer.ToString() );
                        xmlViewerBox.Element = xml.DocumentElement;
                    }
                }
            }
        }

        #endregion
    }
}
