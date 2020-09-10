using System;


namespace _3D_Components.lib
{
    public class Point : Tuple
    {
        public Point(double x_coord, double y_coord, double z_coord) : base(x_coord, y_coord, z_coord, 1.0)
        {
        }

    }
}
