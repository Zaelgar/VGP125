using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
    public interface IGameData
    {
        void LoadFile(string fileName);
        T GetResourceByName<T>(string name) where T : NamedResource;
    }

    // Holds all game data read from xml files
    class GameData
    {
        public void LoadFile(string rootFilename)
        {
            XMLReader xmlReader = new XMLReader();

            var filesData = xmlReader.LoadFile(rootFilename);


            List<NamedResource> allTheResources = new List<NamedResource>();
            for(int i = 0; i < filesData.files.Count; ++i)
            {
                var file = filesData.files[i];

                var data = xmlReader.LoadFile(file.file);

                allTheResources.AddRange(data.GetNamedResources());
            }

            for(int i = 0; i < allTheResources.Count; ++i)
            {
                NamedResource resource = allTheResources[i];

                m_namedResourcesByName[resource.name] = resource;
            }
        }

        public T GetResourceByName<T>(string name) where T : NamedResource
        {
            NamedResource resource;
            if(m_namedResourcesByName.TryGetValue(name, out resource))
            {
                return resource as T;
            }
            else
            {
                Debug.Debug.Log("WHAT");
            }
        }
    }
}