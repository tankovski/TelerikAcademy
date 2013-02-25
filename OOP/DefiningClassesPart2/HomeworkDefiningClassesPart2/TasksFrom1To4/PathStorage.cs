using System;
using System.Collections.Generic;
using System.IO;


static class PathStorage
{
    private static string str = null;

    public static void SavePath(Path path)
    {
        try
        {
            StreamWriter writer = new StreamWriter("Storage.txt");
            using (writer)
            {
                for (int i = 0; i < path.Storage.Count; i++)
                {
                    str+=path.Storage[i]+" ";
                }
                writer.WriteLine(str);
                str += Environment.NewLine;
            }
        }
        catch (IOException io)
        {
            Console.WriteLine("Error!" + io.Message);
        }
        catch
        {
            Console.WriteLine("Unknown error!");
        }
    }

    public static List<Path> LoadPath()
    {
        List<Path> paths = new List<Path>();
        try
        { 
            StreamReader reader = new StreamReader("Storage.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                while (line!=null)
                {
                    string[] arr = line.Split(' ');
                    Path pa = new Path();
                    foreach (string st in arr)
                    {
                        if (st!=string.Empty)
                        {
                            int x = (int)(st[0] - 48);
                            int y = (int)(st[2] - 48);
                            int z = (int)(st[4] - 48);
                            pa.AddPoints(new Point3D(x, y, z));
                        }
                    }
                    paths.Add(pa);
                    line = reader.ReadLine();
                   
                }
            }
        }
        catch (IOException io)
        {
            Console.WriteLine("Error!" + io.Message);
        }
        catch
        {
            Console.WriteLine("Unknown error!");
        }
        return paths;
    }
}

