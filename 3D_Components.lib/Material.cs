using System;
using System.Collections.Generic;
using System.Text;

namespace _3D_Components.lib
{
    public class Material
    {
        public Color baseColor = new Color(1, 1, 1);
        public double brightness = 1.0;
        public double diffuse = 1.0;
        public double shininess = 200.0;
        public double specular = 1.0; //this was messing things up
        public double ambient = 1.0;//?

        //double check this against the book! again!
        public Color ColorAtPoint(HitRecord hitRec, World world) //take in world and loop through lights add up diffuse colors 
        {
            VMath math = new VMath();


            Color color = new Color(0, 0, 0);// * brightness).AsColor();//???

            

            foreach (Light light in world.lights)
            {
                Vector VectorToLight = (light.pos - hitRec.hitPoint).AsVector();

                Vector unitVectorToLight = (VectorToLight).Normalize();
                double lightIntensity = unitVectorToLight.Dot(hitRec.normalVec);

                //Color ambient = (color * this.ambient).AsColor();
                
               // double specAngle = math.Angle(unitVectorToLight, hitRec.eyeVec);

                
                if (lightIntensity < 0)
                {
                    lightIntensity = 0;
                }

                //if (specAngle == 0)
                //{
                //    specular = new Color(1, 1, 1);
                //}

                //else
                //{
                //    specular = (baseColor / specAngle).AsColor();
                //}

                Vector reflectv = (VectorToLight.ReflectedVectorOver(hitRec.normalVec).Normalize()).AsVector();
                Double reflect_dot_eye = reflectv.Dot(hitRec.eyeVec);

                Color specularColor;

                if (reflect_dot_eye <=0)
                {
                    specularColor = C_col.black;
                }

                else
                {
                    Double factor = Math.Pow(reflect_dot_eye, shininess);
                    specularColor = (light.col* specular * factor).AsColor();
                }

                Color diffuseColor = (baseColor * light.col * lightIntensity /* ambient*/ * diffuse).AsColor();
                color += diffuseColor;
                color += specularColor;
            }

            return color;

        }
    }

   
}
/*
 * 
 * my understanding of the specular calculation is that light intensity should
 * increase as a function of the angle between the lightvector and the eyevector 
 * so I multiply light intensity by this angle where angle of 0 degrees
 * is full intensity and 45 is 0
 * basecolor / 45 should be close to nothing
 * and basecolor /~0 should be max
 * if angle is 0 set specular to max
 */
