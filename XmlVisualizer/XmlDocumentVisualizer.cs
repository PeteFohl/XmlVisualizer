using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using XmlVisualizer;
using System.Xml;
using Microsoft.VisualStudio.DebuggerVisualizers;

[assembly: DebuggerVisualizer( typeof( XmlDocumentVisualizer ), typeof( XmlVisualizerObjectSource ), Target = typeof( XmlDocument ), Description = "Xml Document Visualizer" )]
[assembly: DebuggerVisualizer( typeof( XmlDocumentVisualizer ), typeof( XmlVisualizerObjectSource ), Target = typeof( XmlElement ), Description = "Xml Document Visualizer" )]

namespace XmlVisualizer
{
    public class XmlDocumentVisualizer : DialogDebuggerVisualizer
    {
        private IDialogVisualizerService modalService;

        protected override void Show( IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider )
        {

            modalService = windowService;
            if( modalService == null )
                throw new NotSupportedException( "This debugger does not support modal visualizers" );

            XmlDocument xml = new XmlDocument();
            xml.LoadXml( objectProvider.GetObject().ToString() );
            XmlVisualizerForm form = new XmlVisualizerForm( xml.DocumentElement );
            modalService.ShowDialog( form );
        }

    }
}
