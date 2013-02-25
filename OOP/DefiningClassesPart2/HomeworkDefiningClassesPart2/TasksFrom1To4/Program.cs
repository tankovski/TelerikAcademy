using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFrom1To4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make two points
            Point3D p1 = new Point3D(1, 2, 4);
            Point3D p2 = new Point3D(4,3,6);

            //Calculate the distance between this points
            Console.WriteLine(CalculateDistanceBetweenTwo3DPoints.Calculate(p1,p2));
          
            //Make two paths
            Path path1 = new Path();
            Path path2 = new Path();

            //Add points to this paths
            path2.AddPoints(p2);
            path2.AddPoints(p1);
            path1.AddPoints(p1);
            path1.AddPoints(p2);

            //Save the paths in text file
            PathStorage.SavePath(path1);
            PathStorage.SavePath(path2);
           
            //Print the static method load path
            for (int i = 0; i < PathStorage.LoadPath().Count; i++)
            {
                Console.Write("Path{0}: ",i+1);
                for (int j = 0; j < PathStorage.LoadPath()[i].Storage.Count; j++)
                {                   
                        Console.Write(PathStorage.LoadPath()[i].Storage[j].ToString());
                        if (j<PathStorage.LoadPath()[i].Storage.Count-1)
                        {
                            Console.Write(" - ");
                        }
                }
                Console.WriteLine();
            }
            
            
           
        }
    }
}
