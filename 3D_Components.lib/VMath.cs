using System;



namespace _3D_Components.lib
{
    public class VMath
    {


        public static double epsilon = 0.001;
       
        public Point Pos(Ray ray, double distance) //calculated position given a ray and a distance
        {
            Tuple pos_ini = (ray.orig + ray.direct * distance);
            Point position = new Point(pos_ini.x, pos_ini.y, pos_ini.z);

            return position;
        }

       

        public double Angle(Vector v1, Vector v2)
        {
            double cos = v1.Dot(v2) / (v1.Mag() * v2.Mag());
            return Math.Acos(cos);
        }
    }

}
