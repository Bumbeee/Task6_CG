using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PolyLine3D
    {
        private List<Vector3> vertices = new List<Vector3>();
        public PolyLine3D(IList<Vector3> v, bool closed = false)
        {
            vertices.AddRange(v);
            if (closed)
                vertices.Add(v[0]);
        }
        public List<Vector3> Vertices
        {
            get { return vertices; }
        }
    }
}
