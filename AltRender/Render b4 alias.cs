//using System;
//using System.Collections.Generic;
//using System.Text;
//using _3D_Components.lib;

//namespace AltRender
//{
//    public class Render
//    {
        
      
        
        
//        public Render(Canvas can, World world)
//        {
//            string w = can.width.ToString();
//            string h = can.height.ToString();
//            using (System.IO.StreamWriter file =
//            new System.IO.StreamWriter(@"D:\Desktop\CG class\AltRender\Renders\render.ppm", true))
//            {
//                file.WriteLine("P3");
//                file.WriteLine($"{w} {h}");
//                file.WriteLine($"{255}");

//                for (int i = 0; i < can.height; i++)
//                {

//                    double y = 
                        
//                        2 - (double)i / (can.height/4);

//                    for(int j =0; j<can.width; j++)
//                    {
                        
               
                        

//                        double x =  -2 + (double)j / (can.width/4);

//                        Point origin = new Point(x, y, -5);

//                        Ray ray =  new Ray(origin, new Vector(0, 0, 1));

//                        Intersection[] ts = world.IntersectionsWith(ray).ToArray();

                        

//                        foreach(Intersection t in ts)
//                        {
//                            double intersectionT = t.t;
//                            if (intersectionT < 0)
//                            {
//                                can.ColorIn(i, j, C_col.black);
                                
//                            }
//                            else if (intersectionT > 0)
//                            {

//                                HitRecord hit = new HitRecord(); //can make a generate hitrecord functiont for this process
//                                hit.hitPoint = ray.PointAtT(intersectionT);
//                                VMath math = new VMath();
//                                hit.normalVec = t.obj.Normal_at(hit.hitPoint);
//                                hit.eyeVec = (ray.orig - hit.hitPoint).AsVector().Normalize(); //this is the ray turned around?
//                                //hit.lightVec = 
//                                Color pixelColor = t.obj.mat.ColorAtPoint(hit, world); //call 4 times and average for anti-alias?
//                                can.ColorIn(i, j, pixelColor);

//                                if(hit.eyeVec.Dot(hit.normalVec)<0)
//                                {
//                                    hit.inside = true;
//                                    hit.normalVec = (hit.normalVec * -1).AsVector();
//                                }
//                                hit.overPoint = (hit.hitPoint + hit.normalVec * 0.00001).AsPoint(); //must come after inside calculation to make overpoint not an "underpoint"

//                                break; 

//                            }

                            
                                
//                        }

//                        file.Write((can.canvas[i][j]).ColorToPixels());

                        
//                    }

//                    file.WriteLine();

//                }
//            }


//        }


//    }
//}
