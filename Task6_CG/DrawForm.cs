using ClassLibrary;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Task6_CG
{
    public partial class DrawForm : Form
    {
        private Scene scene;
        private Camera camera;
        private Target target;
        private Rocket rocket;
        private World world;
        private const float coeff = 0.03f;

        public DrawForm()
        {
            InitializeComponent();
            scene = new Scene();
            target = new Target(new Vector3(0.3f, 0.3f, 0.3f), new Vector3(0.4f, 0.7f, 0.8f));
            rocket = new Rocket(new Vector3(1f, 0.5f, 1f), coeff);
            scene.Models.Add(target);
            world = new World(rocket);
            camera = new Camera();
            camera.Projection = camera.GetProjection(0.3f, 1f, 1f, 1.5f);

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           | BindingFlags.Instance | BindingFlags.NonPublic, null,
           WorldPanel, new object[] { true });
        }
        bool hit;
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            camera.View = rocket.Translation;
            rocket.Move(new Vector3(rocket.Position.X, rocket.Position.Y, rocket.Position.Z + coeff));            
            //camera.View = camera.View * Matrix4.Scale(1 + coeff, 1 + coeff, 1 + coeff);           
            hit = target.CheckHit(rocket);
            if (hit)
            {
                MessageBox.Show("Попал!");
                UpdateTimer.Stop();
                DrawTimer.Stop();
            }
            Invalidate();
        }

        DateTime lasttime = new DateTime();
        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            float t = 0.001f * (lasttime).Millisecond;
            //world.Update(t);
            WorldPanel.Invalidate();
        }

        private void WorldPanel_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = scene.DrawAll(camera,
            new ClassLibrary.Screen(WorldPanel.Size,
            new RectangleF(-1.5f, -1.5f, 3, 3)));
            e.Graphics.DrawImage(bmp, 0, 0);
            bmp.Dispose();
        }

        //Point last = new Point();

        private void DrawForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                UpdateTimer.Start();
                DrawTimer.Start();
                lasttime = DateTime.Now;
            }
            if(e.KeyCode == Keys.C)
            {
                UpdateTimer.Stop();
                DrawTimer.Stop();
            }
            if (e.KeyCode == Keys.D)
            {
                //camera.View = camera.View * Matrix4.Translate(0f, coeff, 0f);
                rocket.Move(new Vector3(rocket.Position.X + 10 * coeff, rocket.Position.Y, rocket.Position.Z));
            }
            if(e.KeyCode == Keys.A)
            {
                rocket.Move(new Vector3(rocket.Position.X - 10 * coeff, rocket.Position.Y, rocket.Position.Z));
                //camera.View = camera.View * Matrix4.Translate(0f, -coeff, 0f);
            }
            if (e.KeyCode == Keys.W)
            {
                rocket.Move(new Vector3(rocket.Position.X, rocket.Position.Y - 10 * coeff, rocket.Position.Z));
                //camera.View = camera.View * Matrix4.Translate(0f, 0f, coeff);
            }
            if (e.KeyCode == Keys.S)
            {
                rocket.Move(new Vector3(rocket.Position.X, rocket.Position.Y + 10 * coeff, rocket.Position.Z));
                //camera.View = camera.View * Matrix4.Translate(0f, 0f, -coeff);
            }
        }
    }
}
