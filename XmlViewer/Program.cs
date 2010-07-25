using System;
using System.Windows.Forms;

namespace XmlViewer
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            string pipeName = null;
            if( args.Length > 0 )
                pipeName = args[ 0 ];
            using( Form1 form = new Form1(pipeName) )
            {
                Application.Run( form );
            }
        }

    }
}
