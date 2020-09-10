using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using static System.Math;

namespace _3D_Components.lib
{
    public class Camera
    {
        public int hsize;
        public int vsize;
        public double aspect;
        public double FOV; //make degrees

        double half_width;
        double half_height;
        //point and lookat for camera
        //up value jittered by small amount so it doesnt equal 0
        //u = wx up -> p is up value
        //ray directio = x*u + y*v+z*w
        //orthonornal basis rather than transform basis
        public double pixel_size;

        public Matrices transform = new Matrices();

        double half_view;
        public Camera(int horizonal, int vertical, double FieldOfView = Math.PI/ 2)
        {
            hsize = horizonal;
            vsize = vertical;
            FOV = FieldOfView;

            calcPixelSize();

        }

        private void calcPixelSize()
        {
            half_view = Math.Tan(FOV / 2); //mathmatically this would be FOV/2 over 1 going off the right angle tangent formula
                                         //can only do this because canvas is always 1 unit away from view
            aspect = hsize / vsize;
            
            if(hsize>= vsize)
            {
                half_width = half_view;
                half_height = half_view / aspect;
            }
            else
            {
                half_width = half_view * aspect;
                half_height = half_view;
            }

            pixel_size = (half_width * 2) / hsize;
        }

        public Matrices View(Point from, Point to, Vector up)
        {
            Vector forward = (from - to).AsVector().Normalize();
            Vector left = from.Cross(up).AsVector();
            Vector true_up = left.Cross(forward).AsVector();

            Matrices orientation = new Matrices(new double[,] {
                                            {left.x}, {left.y}, {left.x},
                                            {true_up.x}, {true_up.y}, {true_up.z},
                                            {-forward.x}, {-forward.y}, {-forward.z},
                                            {0}, {0}, {0}, {1}


                                                                });
            return orientation;

        }

    }

}
        

    

