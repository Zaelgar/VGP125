using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;

namespace Assignment02
{
    public class CSVParser
    {
        private static readonly Dictionary<string, Func<object>> instanceCreatorByName = new Dictionary<string, Func<object>>()
        {
            // I didn't understand this at first, but then I realised it was just a dictionary entry with the name of the class and a function pointer to a lambda expression which defines a default constructor.
            // We can use this to construct the object once we have the actual data in our list of dictionaries... Right?
            // We can add more string class names and define those constructors as well if we wanted to
            {
                "UserData", () =>
                {
                    return new UserData();
                }
            }
            /*     Example of what I mean
            ,
            {
                "Data", () =>
                {
                    return new Data();
                }
            }
            */
        };

        static public List<UserData> Deserialize(string csvPath)
        {
            List<UserData> userDataList = new List<UserData>();

            if (File.Exists((csvPath)))
            {
                Console.WriteLine("FILE EXISTS with path: " + csvPath);

                using (StreamReader sr = new StreamReader(csvPath))
                {
                    Console.WriteLine("File Open...\n");

                    string readIn = sr.ReadLine();

                    // Give us array of headers
                    string[] headerInfo = readIn.Split(',');

                    List<Dictionary<string, object>> reconstructedDataList = new List<Dictionary<string, object>>();
                    string[] rowInfo;
                    for (int i = 1; i < headerInfo.Length; ++i)
                    {
                        // Read in next row and separate into data fields, pair data fields into dictionary, then add dictionary to list of dictionaries.
                        rowInfo = sr.ReadLine().Split(',');
                        Dictionary<string, object> newEntry = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                        for (int j = 0; j < rowInfo.Length; ++j)
                        {
                            newEntry.Add(headerInfo[j], rowInfo[j]);
                        }
                        reconstructedDataList.Add(newEntry);
                    }
                    // Data reconstruction complete

                    FieldInfo[] fields = typeof(UserData).GetFields();  // expensive to lookup
                    for (int i = 0; i < reconstructedDataList.Count; ++i) // loop through each data set
                    {
                        UserData instance = Activator.CreateInstance<UserData>();
                        for (int j = 0; j < fields.Length; ++j) // loop through each field in each data type UserData so we can match with current constructed data item
                        {
                            string nameOfFieldToMatch = fields[j].Name;

                            if (reconstructedDataList[i].TryGetValue(nameOfFieldToMatch, out dynamic contentValue) == true)  // test to see if we can extract the value of named field (in any position) into contentValue
                            {
                                fields[j].SetValue(instance, Convert.ChangeType(contentValue, fields[j].FieldType));
                            }
                            else
                            {
                                // field either doe not exist or spelled differently
                                Console.WriteLine("ERROR: Better luck next time, try spellcheck! Name of failed field: {0}", nameOfFieldToMatch);
                            }
                        }

                        // We matched as many fields as we could
                        userDataList.Add(instance);
                    }

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

    class Program
    {
        static void Main(string[] args)
        {
            //string path = "F:/Jaidon/Documents/GitHub/VGP125/Assignment02/files/file.csv";
            string path = "../../files/file.csv";

            List<UserData> users = CSVParser.Deserialize(path);

            for (int i = 0; i < users.Count; ++i)
            {
                users[i].Print();
            }

            Console.ReadKey();
        }
    }

    public class UserData
    {
        public bool isAlive;
        public string name;
        public string location;
        public string pet;
        public long userId;

        public void Print()
        {
            Console.WriteLine("Name: {0}\tLocation: {1}\tPet: {2}\tIs Alive?: {3}\t\tUser ID: {4}", name, location, pet, isAlive, userId);
        }
    }
}