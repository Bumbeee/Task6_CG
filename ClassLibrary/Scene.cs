using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary
{
    public class Scene
    {
        public List<IModel> Models { get; set; }
        public Scene()
        {
            Models = new List<IModel>();
        }
        public Bitmap DrawAll(Camera cam, Screen scr)
        {
            Bitmap bmp = new Bitmap(scr.Size.Width, scr.Size.Height);
            Graphics g = Graphics.FromImage(bmp);
            List<PolyLine3D> lines = new List<PolyLine3D>();
            foreach (IModel m in Models)
                foreach (PolyLine3D pl in m.GetLines()) 
                {
                    List<Vector3> vl = new List<Vector3>();
                    foreach (Vector3 v in pl.Vertices)
                        vl.Add(cam.Convert(v));
                    lines.Add(new PolyLine3D(vl));
                }
            
            foreach (var pl in lines)
            {
                List<Point> points = new List<Point>();
                foreach (Vector3 v in pl.Vertices)
                    points.Add(scr.Convert(v));
                g.DrawLines(Pens.Black, points.ToArray());
            }

            g.Dispose();
            return bmp;
        }
    }
}
