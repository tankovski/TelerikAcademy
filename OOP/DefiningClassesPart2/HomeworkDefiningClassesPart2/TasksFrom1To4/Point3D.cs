using System;

struct Point3D
{
    //Fields
    private int x;
    private int y;
    private int z;
    private static readonly Point3D zeroPoint = new Point3D(0, 0, 0);

    //Properties
    public int X
    {
        get { return this.x; }
        set { this.x = value; }
    }
    public int Y
    {
        get { return this.y; }
        set { this.y = value; }
    }
    public int Z
    {
        get { return this.z; }
        set { this.z = value; }
    }
    public static Point3D ZeroPoint
    {
        get { return zeroPoint; }
    }

    //Constructor
    public Point3D(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    //Metods
    public override string ToString()
    {
        return String.Format("{0},{1},{2}", X, Y, Z);
    }
}

