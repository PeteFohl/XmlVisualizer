using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace XmlVisualizer
{
    public class XmlVisualizerObjectSource : VisualizerObjectSource
    {
        public override void GetData( object target, Stream outgoingData )
        {
            string xml = "";
            if( target is XmlDocument )
                xml = (target as XmlDocument).DocumentElement.OuterXml;
            else if( target is XmlElement )
                xml = (target as XmlElement).OuterXml;
            base.GetData( xml, outgoingData );
        }
    }
}
