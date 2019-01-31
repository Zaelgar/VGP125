using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Assignment02
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = "F:/Jaidon/Documents/GitHub/VGP125/Assignment02/files/file.csv";
            string path = "../../files/file.csv";

            List<UserData> users = Deserialize(path);

            Console.ReadKey();
        }

        static List<UserData> Deserialize(string csvPath)
        {
            List<UserData> userDataList = new List<UserData>();

            if (File.Exists((csvPath)))
            {
                Console.WriteLine("FILE EXISTS with path: " + csvPath);

                using (StreamReader sr = new StreamReader(csvPath))
                {
                    Console.WriteLine("File Open...\n");

                    sr.ReadLine();
                    while (sr.EndOfStream == false)
                    {
                        string thisLine = sr.ReadLine();
                        var splitValues = thisLine.Split(',');

                        userDataList.Add(new UserData(Int32.Parse(splitValues[0]), splitValues[1], splitValues[2]));
                    }
                }

                for(int i = 0; i < userDataList.Count; ++i)
                {
                    Console.WriteLine("ID = " + userDataList[i].id + "  NAME = " + userDataList[i].userName + "  OCCUPATION = " + userDataList[i].occupation);
                }

                return userDataList;
            }
            else
            {
                Console.WriteLine("DOES NOT EXIST");
                return null;
            }
        }
    }

    class UserData
    {
        public UserData(int ID, string USERNAME, string OCCUPATION)
        {
            id = ID;
            userName = USERNAME;
            occupation = OCCUPATION;
        }

        public int id;
        public string userName;
        public string occupation;
    }
}