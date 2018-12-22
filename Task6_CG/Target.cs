using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ClassLibrary;

namespace Task6_CG
{
    public class Target : IModel
    {
        public Vector3 TLF { get; set; } //top left far
        public Vector3 BRN { get; set; } // bottom right near 
        public Target(Vector3 tlf, Vector3 brn)
        {
            TLF = tlf;
            BRN = brn;
        }
        public List<PolyLine3D> GetLines()
        {
            List<PolyLine3D> r = new List<PolyLine3D>();
            r.Add(new PolyLine3D(new List<Vector3>()
            {
            new Vector3(TLF.X, TLF.Y, TLF.Z),
            new Vector3(BRN.X, TLF.Y, TLF.Z),
            new Vector3(BRN.X, BRN.Y, TLF.Z),
            new Vector3(TLF.X, BRN.Y, TLF.Z)}, true));
            r.Add(new PolyLine3D(new List<Vector3>() {
            new Vector3(BRN.X, BRN.Y, BRN.Z),
            new Vector3(BRN.X, TLF.Y, BRN.Z),
            new Vector3(TLF.X, TLF.Y, BRN.Z),
            new Vector3(TLF.X, BRN.Y, BRN.Z)}, true));
            r.Add(new PolyLine3D(new List<Vector3>(){
            new Vector3(BRN.X, TLF.Y, TLF.Z),
            new Vector3(BRN.X, TLF.Y, BRN.Z)}, true));
            r.Add(new PolyLine3D(new List<Vector3>(){
            new Vector3(TLF.X, BRN.Y, TLF.Z),
            new Vector3(TLF.X, BRN.Y, BRN.Z)}, true));
            r.Add(new PolyLine3D(new List<Vector3>(){
            new Vector3(TLF.X, TLF.Y, TLF.Z),
            new Vector3(TLF.X, TLF.Y, BRN.Z)}, true));
            r.Add(new PolyLine3D(new List<Vector3>(){
            new Vector3(BRN.X, BRN.Y, TLF.Z),
            new Vector3(BRN.X, BRN.Y, BRN.Z)}, true));
            return r;
        }

        public bool CheckHit(Rocket rocket)
        {
            if (rocket.Position.Z == BRN.Z && rocket.Position.X > new Vector3(BRN.X, TLF.Y, TLF.Z).X && rocket.Position.X < new Vector3(TLF.X, BRN.Y, BRN.Z).X)
                return true;
            else
                return false;
        }
    }
}
