using Cw2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Data\dane.csv";
            var result = "result.xml";
            var format = "xml";
            var students = new HashSet<Student>();

            if (args.Length == 3)
            {
                path = args[0];
                result = args[1];
                format = args[2];
                
            }

            //Wczytywanie 
            var fi = new FileInfo(path);
            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] kolumny = line.Split(',');
                    if (kolumny.Length < 9)
                    {
                        Log.LogIt("Za mało danych!");
                        Console.WriteLine("Za mało danych!");
                        continue;
                    }
                    
                    for(int i = 0; i < kolumny.Length; i++)
                    {
                        if(kolumny[i].Equals(null))
                        {
                            Log.LogIt("Brak wszystkich danych!");
                            Console.WriteLine("Brak wszystkich danych!");
                            continue;
                        }
                    }
                
                        var student = new Student
                        {
                            Name = kolumny[0],
                            Surname = kolumny[1],
                            Subject = kolumny[2],
                            Type = kolumny[3],
                            ID = kolumny[4],
                            Birthday = kolumny[5],
                            Email = kolumny[6],
                            MotherName = kolumny[7],
                            FatherName = kolumny[8]
                        };
    
                    
                        if(!students.Add(student))
                        {
                            Log.LogIt("Duplikat!");
                            Console.WriteLine("Duplikat!");
                            continue;
                        }
                    Console.WriteLine(line);
                }
            }

            if (format.Equals("xml"))
            {
                var list = new List<Student>(students);
                FileStream writer = new FileStream(@"data.xml", FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("Uczelnia"));
                serializer.Serialize(writer, list);
            }

            if (format.Equals("json"))
            {
                var list = new List<Student>(students);
                var jsonString = JsonSerializer.Serialize(list);
                File.WriteAllText("data.json", jsonString);

            }
        }
    }
}
