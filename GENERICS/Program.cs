using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace GENERICS_
{
    internal class Program
    {
        static string filename = @"Students.dat";
        [Obsolete]
        static void Main(string[] args)
        {

            bool hasCancel = true;

            GenericWorld<STUDENT> school = new GenericWorld<STUDENT>();

            while (hasCancel != false)
            {
                Console.Clear();
                PrintMenu();

                int selectedMenu = ReadInteger("Please select the menu: ");

                switch (selectedMenu)
                {
                    case 1:
                        {
                            Console.Clear();
                            STUDENT b = new STUDENT();

                            Console.WriteLine("Name of the Student: ");
                            b.Name = Console.ReadLine();

                            Console.WriteLine("Surname of the Student: ");
                            b.Surname = Console.ReadLine();

                            Console.WriteLine("Age of the Student: ");
                            b.Age = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("School of the Student: ");
                            b.Surname = Console.ReadLine();                         

                            b.Class = ReadDouble("Class of the Student: ");

                            school.Add(b);
                            break;
                        }
                    case 2:
                        {

                            Console.WriteLine("List of the Students: ");
                            for (int i = 0; i < school.Lenght; i++)
                            {
                                STUDENT b = school[i];
                                Console.WriteLine($"{i}.{b}");
                            }
                            int index = ReadInteger("Enter the serial number: ");

                            school.RemoveAt(index);
                            goto case 3;


                        }



                    case 3:
                        Console.Clear();

                        Console.WriteLine("List of the Students: ");
                        foreach (var item in school)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Press any key to go to menu ");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Exitting application... COMPLETE!!! PRESS ANY KEY");
                        Console.ReadLine();
                        Console.WriteLine("Are you suuuuuure?PRESS ANY KEY");
                        hasCancel = false;
                        break;
                    case 5:
                        SaveToFile(school, filename);
                        break;
                    case 6:
                        SaveToFile(school, filename);
                        hasCancel = false;
                        break;
                    case 7:
                        school = LoadFromFile(filename);
                        break;
                    default:
                        break;
                }

            }

            Console.ReadKey();
        }

        [Obsolete]
        static void SaveToFile(GenericWorld<STUDENT> school, string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, school);
            }
        }

        [Obsolete]
        static GenericWorld<STUDENT> LoadFromFile(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    var fileBulk = bf.Deserialize(fs);
                    GenericWorld<STUDENT> school = (GenericWorld<STUDENT>)fileBulk;
                    return school;
                }
            }
            catch (Exception)
            {

                return new GenericWorld<STUDENT>();
            }

          
        }

        static void PrintMenu()
        {
            Console.WriteLine("1: Add New Student");
            Console.WriteLine("2: Remove Student by index");
            Console.WriteLine("3: List of Students");
            Console.WriteLine("4: Exit");
            Console.WriteLine("6: Save");
            Console.WriteLine("6: Save and Exit");
            Console.WriteLine("7: Load data from db");
        }

        static int ReadInteger(string caption)
        {
        l1:
            Console.Write(caption);

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;

            }
            goto l1;
        }

        
        static double ReadDouble(string caption)
        {
        l1:
            Console.Write(caption);

            if (double.TryParse(Console.ReadLine(), out double value))
            {
                return value;

            }
            goto l1;


            //WASNT WORKING HERE
            //[Obsolete]
            //static void SaveToFile(GenericWorld<STUDENT> school, string filePath)
            //{
            //    using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            //    {
            //        BinaryFormatter bf = new BinaryFormatter();

            //        bf.Serialize(fs, school);
            //    }       
            //}


            //[Obsolete]
            //static GenericWorld<STUDENT> LoadFromFile( string filePath)
            //{
            //    using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            //    {
            //        BinaryFormatter bf = new BinaryFormatter();
            //        var fileBulk = bf.Deserialize(fs);
            //        GenericWorld<STUDENT> school = (GenericWorld<STUDENT>)fileBulk;
            //       return school;
            //    }
            //}

        }
    }  
}
