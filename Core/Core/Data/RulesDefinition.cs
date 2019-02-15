using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Data
{
    public class RulesDefinition : NamedResource
    {
        [XmlAttribute]
        public string function;

        [XmlAttribute]
        public string value;
    }
}
