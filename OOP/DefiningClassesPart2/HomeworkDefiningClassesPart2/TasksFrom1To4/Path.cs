using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Path
{
    //Field
    private List<Point3D> storage = new List<Point3D>();

    public List<Point3D> Storage
    {
        get { return storage; }
    }

    public void AddPoints(Point3D point)
    {
        storage.Add(point);
    }
}

