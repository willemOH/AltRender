using System;
using System.Collections.Generic;
using System.Text;

namespace _3D_Components.lib
{
    public abstract class Light
    {
        public Point pos;
        public Vector vec;
        public Color col;

        public double intensity = 1.0; //this hasn't been implemented
        
        /*
        public Light(Color color, double x, double y, double z, double w = 1.0)
        {
            col = color;

            if (w == 1.0)
                pos = new Point(x, y, z);
            else if (w == 0)
                vec = new Vector(x, y, z);
            else
                throw new System.ArgumentException("w value must be 1.0 or 0.0");
        }
        
    */
   
            
    }

    public class PointLight : Light
    {
        public PointLight(Point loc, Color color)
        {
            base.col = color;
            base.pos = loc;
        }
    }
}
