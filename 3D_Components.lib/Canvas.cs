using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace _3D_Components.lib
{
    public class Canvas
    {
        public Color[][] canvas;
        public int width;
        public int height;
        public Canvas(int c_width, int c_height)
        {
            width = c_width; 
            height = c_height;

            Color blank = new Color(0, 0, 0);

            canvas = new Color[height][];
            for (int i = 0; i < height; i++)
            {
                canvas[i] = new Color[width];

                for(int j =0; j < width; j++)
                {
                    canvas[i][j] = blank;
                }
            }
        }

        public void ColorIn(int x_coord, int y_coord, Color color)
        {
            canvas[x_coord][y_coord] = color;
        }

        

        

    }

    
}
