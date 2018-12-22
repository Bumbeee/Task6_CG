using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ClassLibrary;

namespace Task6_CG
{
    public class Rocket
    {
        public float Velocity { get; set; }
        public float AngleY { get; set; }
        public float Angle { get; set; }
        public Vector3 Position { get; set; } 

        public Matrix4 Translation { get { return new Matrix4(new float[,]
            {
                { Position.X, 0, 0, 0 },
                { 0, Position.Y, 0, 0 },
                { 0, 0, Position.Z,  0},
                { 0, 0, 0, 1 },
            }); } }

        public Rocket(Vector3 position, float velocity)
        {
            Position = position;
            Velocity = velocity;
            Angle = (float)Math.PI / 3;
        }

        public void Move(Vector3 newPos)
        {
            Position = newPos;
            //Translation = new Matrix4(new float[,]
            //{
            //    { 1, 0, 0, newPos.X },
            //    { 0, 1, 0, newPos.Y },
            //    { 0, 0, 1, newPos.Z },
            //    { 0, 0, 0, 1 },
            //});
        }
    }
}
