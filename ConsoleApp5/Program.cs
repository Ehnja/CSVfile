using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                using (var reader = new StreamReader(@"C:\flyvning\flyvning1.csv"))
                {
                    List<string> exportSVC = new List<string>();
                    List<string[]> dataArrays = new List<string[]>();

                    List<string> GPSLong = new List<string>();
                    List<string> GPSLat = new List<string>();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(';');

                        GPSLong.Add(values[2]);
                        GPSLat.Add(values[3]);  
                    }

                    for (int i = 2; i < GPSLong.Count - 1; i++)
                    {
                        GPSLong[i] = GPSLong[i].Replace(".", string.Empty);
                        GPSLong[i] = GPSLong[i].Insert(1, ".");
                    }
                    for (int i = 2; i < GPSLat.Count - 1; i++)
                    {
                        GPSLat[i] = GPSLat[i].Replace(".", string.Empty);
                        GPSLat[i] = GPSLat[i].Insert(2, ".");
                    }
                    for (int i = 2; i < GPSLat.Count; i++)
                    {
                        exportSVC.Add(GPSLong[i] + ", " + GPSLat[i]);

                    }

                    File.WriteAllLines(@"C:\flyvning\flyvning2.csv", exportSVC);

                    for (int i = 0; i < GPSLong.Count - 1; i++)
                    {
                        Console.WriteLine(GPSLat[i]);
                        Console.WriteLine(GPSLong[i]);
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }   
}
