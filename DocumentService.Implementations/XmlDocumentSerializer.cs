using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using DocumentService.Contract.Services;

namespace DocumentService.Implementations
{
    public class XmlDocumentSerializer : ISerializer
    {
        public string Serialize(IEnumerable<Uri> source)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true
            };

            StringBuilder builder = new StringBuilder();

            using XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("uriAdresses");
            foreach (var uri in source)
            {
                this.Serialize(xmlWriter, uri);
            }

            xmlWriter.WriteEndElement();

            xmlWriter.Flush();

            return builder.ToString();
        }

        private void Serialize(XmlWriter xmlWriter, Uri uri)
        {
            xmlWriter.WriteStartElement("uriAddress");

            xmlWriter.WriteStartElement("host");
            xmlWriter.WriteAttributeString("name", uri.Host);
            xmlWriter.WriteEndElement();

            this.WriteSegments(xmlWriter, uri);

            this.WriteParameters(xmlWriter, uri);

            xmlWriter.WriteEndElement();
        }

        private void WriteSegments(XmlWriter xmlWriter, Uri uri)
        {
            if (uri.Segments.Length != 0)
            {
                xmlWriter.WriteStartElement("uri");

                foreach (var uriSegment in uri.Segments)
                {
                    if (uriSegment == "/")
                    {
                        continue;
                    }

                    xmlWriter.WriteStartElement("segment");
                    xmlWriter.WriteString(uriSegment.Replace("/", ""));
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
            }
        }

        private void WriteParameters(XmlWriter xmlWriter, Uri uri)
        {
            if (uri.Query.Length > 1)
            {
                xmlWriter.WriteStartElement("parameters");

                var query = uri.Query.Split(new char[] { '?', '=', '&' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < query.Length; i += 2)
                {
                    xmlWriter.WriteStartElement("parametr");
                    xmlWriter.WriteAttributeString("value", query[i + 1]);
                    xmlWriter.WriteAttributeString("key", query[i]);
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
            }
        }
    }
}
