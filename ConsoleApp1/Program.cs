using Core.Data;
using Core.Debug;
using Core.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DataParser
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLReader xmlReader = new XMLReader();
            var fileData = xmlReader.LoadFile("files.xml");

            List<NamedResource> allTheResources = new List<NamedResource>();
            for(int i = 0; i <fileData.files.Count; ++i)
            {
                var file = fileData.files[i];

                var data = xmlReader.LoadFile(file.file);

                allTheResources.AddRange(data.GetNamedResources());
            }

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < allTheResources.Count; ++i)
            {
                sb.AppendLine(allTheResources[i].name);
            }


            RulesSystem rulesSystem = new RulesSystem();
            rulesSystem.Run((RulesDefinition)allTheResources[0]);


            Console.ReadKey();
        }
    }
}