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
                    List<string>[] DataRest = new List<string>[14];
                    for (int i = 0; i < DataRest.Length; i++)
                    {
                        DataRest[i] = new List<string>();
                    }

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(';');
                                              
                        for (int i = 0; i < 13; i++)
                        {
                            DataRest[i].Add(values[i]);
                        }
                        
                    }

                    for (int i = 2; i < DataRest[2].Count - 1; i++)
                    {
                        DataRest[2][i] = DataRest[2][i].Replace(".", string.Empty);
                        DataRest[2][i] = DataRest[2][i].Insert(1, ".");
                    }
                    for (int i = 2; i < DataRest[3].Count - 1; i++)
                    {
                        DataRest[3][i] = DataRest[3][i].Replace(".", string.Empty);
                        DataRest[3][i] = DataRest[3][i].Insert(2, ".");
                    }

                    exportSVC.Add("Ticks; offsetTime; GPSLong; GPSLat; GPSDate; GPSTime; GPSheightMSL; GPShDOP; GPSpDOP; GPSsAcc; GPSnumGPS; GPSnumGLNAS; GPSnumSV; GPSkoord");
                    
                    for (int i = 2; i < DataRest[2].Count; i++)
                    {
                        exportSVC.Add(DataRest[0][i] + ";" + DataRest[1][i] + ";" + DataRest[2][i] + ";" + DataRest[3][i] + ";" + DataRest[4][i] + ";" + DataRest[5][i] + ";" + DataRest[6][i] + ";" + DataRest[7][i] + ";" + DataRest[8][i] + ";" + DataRest[9][i] + ";" + DataRest[10][i] + ";" + DataRest[11][i] + ";" + DataRest[12][i] + ";" + DataRest[2][i] + ", " + DataRest[3][i]);

                    }

                    File.WriteAllLines(@"C:\flyvning\flyvning2.csv", exportSVC); 
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
