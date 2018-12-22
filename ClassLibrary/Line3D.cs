using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Line3D : IModel
    {
        Vector3 v1, v2;
        public Line3D(Vector3 a, Vector3 b)
        {
            v1 = a;
            v2 = b;
        }
        public List<PolyLine3D> GetLines()
        {
            return new List<PolyLine3D>() { new PolyLine3D(new List<Vector3>() { v1, v2}) };
        }
    }
}
