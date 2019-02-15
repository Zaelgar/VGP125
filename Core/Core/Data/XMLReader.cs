using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Core.Debug;

namespace Core.Data
{
    public class XMLReader
    {
        private XmlSerializer m_Serializer;
        

        public XMLReader()
        {
            m_Serializer = new XmlSerializer(typeof(RootData));

            m_Serializer.UnknownNode += serializer_UnknownNode;
            m_Serializer.UnknownAttribute += serializer_UnknownAttribute;
            m_Serializer.UnknownElement += serializer_UnknownElement;
        }

        private void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            Debug.Debug.Error(string.Format("Unknown element found at [{0}] type of [{1}]", e.Attr.Name, e.ObjectBeingDeserialized.GetType().Name));
        }

        private void serializer_UnknownElement(object sender, XmlElementEventArgs e)
        {
            Debug.Debug.Error(string.Format("Unknown element found at [{0}] type of [{1}]", e.Element.Name, e.ObjectBeingDeserialized.GetType().Name));
        }

        private void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Debug.Debug.Error(string.Format("Unknown element found at [{0}] type of [{1}]", e.Name, e.ObjectBeingDeserialized.GetType().Name));
        }

        public RootData LoadFile(string fileName)
        {
            Debug.Debug.Log(string.Format("Reading {0} xml file", fileName));
            RootData data = null;
            using (StreamReader stream = new StreamReader(fileName))
            {
                try
                {
                    data = m_Serializer.Deserialize(stream) as RootData;
                }
                catch (System.Exception ex)
                {
                    Debug.Debug.Error(ex.ToString());
                }
            }

            return data;
        }
    }
}