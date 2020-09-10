using System;
using System.Collections.Generic;
using System.Text;

namespace _3D_Components.lib
{
    public class Mesh : Objects
    {

        public List<Point> vertices;
        public List<MeshTriangle> faces;
      
        public Mesh(List<Point> vertices, List<(int, int, int)> vertexIndices)
        {
            this.vertices = vertices;

            foreach((int, int, int) triple in vertexIndices)
            {
                this.faces.Add(new MeshTriangle(this, triple));
            }
        }


        public override List<Intersection> Intersects(Ray r)
        {
            List<Intersection> Intersections = new List<Intersection>();

            Ray objSpaceRay = r.Transform(transform.Inverse());

            foreach(MeshTriangle face in faces)
            {

                face.CramersLaw(face.axisA, face.axisB, r.orig, r.direct);

                if (face.Beta >= 0 && face.Gamma >= 0 && face.Beta + face.Gamma <= 1)
                {
                    Intersections.Add(new Intersection(face.t, this, r));
                }
                else
                { }

                
            }
            return Intersections;
        }


        }

    public class MeshTriangle : Triangle
    {
        Mesh mesh;

        
        
       


        public MeshTriangle(Mesh mesh, (int, int, int) vertexTriple) 
            : base(mesh.vertices[vertexTriple.Item1], mesh.vertices[vertexTriple.Item1], mesh.vertices[vertexTriple.Item1])
        {
            this.mesh = mesh;
        /*
            a = mesh.vertices[vertexTriple.Item1];
            b = mesh.vertices[vertexTriple.Item2];
            c = mesh.vertices[vertexTriple.Item3];


            axisA = (a - b).AsVector();
            axisB = (a - c).AsVector();

            normal = (axisA.Cross(axisB)).AsVector();
            */
        }


    }


    
}
