using System;


namespace _3D_Components.lib
{
    public class Vector : Tuple
    {
        public Vector(double x_coord, double y_coord, double z_coord) : base(x_coord, y_coord, z_coord, 0.0)
        {

        }

        public Vector Normalize()
        {
            double mag = Math.Sqrt(this.Dot(this)); //magnitude
            return (this * 1 / mag).AsVector(); // vector divided by magnitude (in the form of multiplying by fraction)

        }
    }
}
