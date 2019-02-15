using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Data
{
    [XmlRoot("root")]
    public class RootData
    {
        [XmlArray]
        [XmlArrayItem("file")]
        public List<FileDefinition> files = new List<FileDefinition>();

        [XmlArray]
        [XmlArrayItem("rule")]
        public List<RulesDefinition> rules = new List<RulesDefinition>();

        public List<NamedResource> GetNamedResources()
        {
            List<NamedResource> allNamedResources = new List<NamedResource>();
            allNamedResources.AddRange(rules);
            return allNamedResources;
        }
    }


    public class NamedResource
    {
        [XmlAttribute]
        public string name;
    }

    public class FileDefinition
    {
        public string file;
    }
}