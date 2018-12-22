using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Task6_CG
{
    public class World
    {
        public float G { get; set; }
        public Rocket Rocket { get; set; }

        public World(Rocket rocket)
        {
            Rocket = rocket;
            G = 9.8f;
        }

        public void Update(float t)
        {
            float posX = Rocket.Position.X + Rocket.Velocity * (float)Math.Cos(Rocket.Angle) * t;
            float posZ = posX * (float)Math.Tan(Rocket.Angle) - (G * posX * posX) / (2 * Rocket.Velocity * Rocket.Velocity * (float)Math.Cos(Rocket.Angle) * (float)Math.Cos(Rocket.Angle));
            double angle = (float)Math.Tan(Rocket.Angle) - (G * posX) / (Rocket.Velocity * Rocket.Velocity * (float)Math.Cos(Rocket.Angle) * (float)Math.Cos(Rocket.Angle));
            float posY = 0;
            if(Rocket.AngleY !=0)
            {
                posY = posX / (float)Math.Cos(Rocket.Angle);
            }
            Rocket.Move(new Vector3(posX, posY, posZ));
        }
    }
}
