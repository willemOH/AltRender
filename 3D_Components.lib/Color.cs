using System;
using System.Collections.Generic;
using System.Text;

namespace _3D_Components.lib
{
    public class Color : Tuple
    {

        public string ColorToPixels()
        {

            int redInt = Math.Min(Math.Max((int)(x * 255), 0), 255);
            int greenInt = Math.Min(Math.Max((int)(y * 255), 0), 255);
            int blueInt = Math.Min(Math.Max((int)(z * 255), 0), 255);



            return $"{redInt} {greenInt} {blueInt} ";
        }


        public Color(double red, double green, double blue) : base(red, green, blue, 0.0)
        {
            x = red;
            y = green;
            z = blue;

        }

        public static Color operator +(Color a, Color b)
        {
            return new Color((a.x + b.x), (a.y + b.y), (a.z + b.z));
        }

        public static Color operator *(Color a, Color b)
        {
            return new Color((a.x * b.x), (a.y * b.y), (a.z * b.z));
        }
    }
}
