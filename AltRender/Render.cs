using System;
using System.Collections.Generic;
using System.Text;
using _3D_Components.lib;

namespace AltRender
{
    public class Render
    {

        public int antiAlias = 4;



        public Render(Canvas can, World world)
        {
            string w = can.width.ToString();
            string h = can.height.ToString();
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"E:\Desktop\CG class\AltRender\Renders\render.ppm", true))
            {
                file.WriteLine("P3");
                file.WriteLine($"{w} {h}");
                file.WriteLine($"{255}");

                Random random = new Random();

                float[,] aliasPoints = new float[20, 2];

                for (int a = 0; a < 20; a++)
                {
                    aliasPoints[a, 0] = (float)(random.NextDouble() - .5);
                    aliasPoints[a, 1] = (float)(random.NextDouble() - .5);

                    /*
                    switch (a) //creating array that every 4 coordinates is in a different .25 quadrant of the pixel
                    {
                        case 0: //upper right quad of pixel
                            aliasPoints[a, 0] = (float)(0 - random.NextDouble()/2);
                            aliasPoints[a, 1] = (float)(0 - random.NextDouble() / 2);
                            break;

                        case 1: //upper left
                            aliasPoints[a, 0] = (float)(random.NextDouble() /2);
                            aliasPoints[a, 1] = (float)(0 - random.NextDouble() / 2);
                            break;

                        case 2: //lower left
                            aliasPoints[a, 0] = (float)(random.NextDouble() / 2);
                            aliasPoints[a, 1] = (float)(0 - random.NextDouble() / 2);
                            break;


    

                    }
                */
                }

                for (int i = 0; i < can.height; i++)
                {


                    for (int j = 0; j < can.width; j++)
                    {







                        //  List<Ray> rays = new List<Ray>();

                        int startPoint = random.Next(0, 19);

                        Color pixelColor = C_col.black;

                        for (int o = 0; o < antiAlias; o++) //adding to list of rays to send through ColorAtPoint then average for aliasing
                        {
                            double newX = aliasPoints[startPoint, 0];
                            double newY = aliasPoints[startPoint, 1];
                            double x = -2 + (double)(j + newX) / (can.width / 4);
                            double y = 2 - (double)(i + newY) / (can.height / 4);
                            Ray ray = new Ray(new Point(x, y, -5), new Vector(0, 0, 1));
                            // rays.Add(ray);

                            startPoint++;
                            startPoint = startPoint % 20; //loops around from 20 to 1


                            Intersection[] ts = world.IntersectionsWith(ray).ToArray(); // how to get list of rays into this?

                            foreach (Intersection t in ts)
                            {



                                double intersectionT = t.t;

                                if (intersectionT < 0)
                                {
                                    can.ColorIn(i, j, C_col.black);

                                }
                                else if (intersectionT > 0)
                                {
                                    HitRecord hit = new HitRecord(); //can make a generate hitrecord functiont for this process
                                    hit.hitPoint = ray.PointAtT(intersectionT);


                                    VMath math = new VMath();
                                    hit.normalVec = t.obj.Normal_at(hit.hitPoint);
                                    hit.eyeVec = (ray.orig - hit.hitPoint).AsVector().Normalize(); //this is the ray turned around?
                                                                                                   //hit.lightVec = 



                                    if (hit.eyeVec.Dot(hit.normalVec) < 0)
                                    {
                                        hit.inside = true;
                                        hit.normalVec = (hit.normalVec * -1).AsVector();
                                    }
                                    hit.overPoint = (hit.hitPoint + hit.normalVec * 0.00001).AsPoint(); //must come after inside calculation to make overpoint not an "underpoint"
                                    pixelColor += t.obj.mat.ColorAtPoint(hit, world); //call 4 times and average for anti-alias?

                                    break;

                                }
                            }



                        }
                        pixelColor = (pixelColor / antiAlias).AsColor();
                        can.ColorIn(i, j, pixelColor);

                        file.Write((can.canvas[i][j]).ColorToPixels());

                    }

                    file.WriteLine();

                }
            }


        }


    }
}
