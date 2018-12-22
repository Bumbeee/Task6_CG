using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Camera
    {
        public Matrix4 View { get; set; }
        public Matrix4 Projection { get; set; }

        public Vector3 Up { get; set; }
        public Vector3 Center { get; set; }
        public Vector3 Eye { get; set; }

        public Vector3 X { get; set; }
        public Vector3 Y { get; set; }
        public Vector3 Z { get; set; }

        private float aspect { get; set; }
        private float fovy { get; set; }


        public Camera()
        {
            //View = Matrix4.One();
            Projection = Matrix4.One();
            Eye = new Vector3(0f, 0f, 0f);
            Up = new Vector3(0f, 0f, -2f);
            Center = new Vector3(4f, 2f, 1f);
            Z = (Eye - Center) / Vector3.Abs(Eye - Center);
            X = Up * Z / Vector3.Abs(Up * Z);
            Y = Z * X;
            View = new Matrix4(new float[,]
            {
                { X.X, X.Y, X.Z, -(X.X*Eye.X + X.Y*Eye.Y + X.Z*Eye.Z) },
                { Y.X, Y.Y, Y.Z, -(Y.X*Eye.X + Y.Y*Eye.Y + Y.Z*Eye.Z) },
                { Z.X, Z.Y, Z.Z, -(Z.X*Eye.X + Z.Y*Eye.Y + Z.Z*Eye.Z) },
                { 0, 0, 0, 1 },
            });
            
        }
        public Vector3 Convert(Vector3 v)
        {
            Vector4 r = Projection * View * new Vector4(v);
            return new Vector3(r);
        }

        public Matrix4 GetProjection(float zNear, float zFar, float Witdh, float Heigth)
        {
            float b = -Witdh / 2;
            float r = Heigth / 2;
            //float n = zNear;
            float l = -Heigth / 2;
            float t = Witdh / 2;
            Projection = new Matrix4(new float[,]
            {
                { 2 * zNear /  (r - l), 0, (r + l) / (r - l), 0 },
                { 0, 2 * zNear / (t - b), (t + b) / (t - b), 0 },
                { 0, 0, -(zFar + zNear) / (zFar - zNear), -2 * (zFar * zNear) / (zFar - zNear)},
                { 0, 0,-1 ,0 },
            });
            return Projection;
        }
    }
}
