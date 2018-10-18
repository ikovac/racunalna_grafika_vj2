using System;
using System.Drawing;
using System.Windows.Forms;
using CsGL.OpenGL;

namespace Vjezba2
{
    public class OurView : OpenGLControl
    {

        private float angleY = 0;
        private float angleX = 0;
        private float angleZ = 0;
        private float angleR = 0;
        private float angleT = 0;
        private float lengthZ = 0;

        public OurView()
        {
            this.KeyDown += new KeyEventHandler(OurView_OnKeyDown);
        }

        protected void OurView_OnKeyDown(object Sender, KeyEventArgs kea)
        {
            if (kea.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            if (kea.KeyCode == Keys.Y)
            {
                angleY += 5;
                Refresh();
            }
            if (kea.KeyCode == Keys.X)
            {
                angleX += 5;
                Refresh();
            }
            if (kea.KeyCode == Keys.Z)
            {
                angleZ += 5;
                Refresh();
            }
            if (kea.KeyCode == Keys.P)
            {
                angleR += 10;
                Refresh();
            }
            if (kea.KeyCode == Keys.T)
            {
                angleT += 10;
                Refresh();
            }
            if (kea.KeyCode == Keys.Q)
            {
                lengthZ += 1;
                Refresh();
            }
            if (kea.KeyCode == Keys.W)
            {
                lengthZ -= 1;
                Refresh();
            }
        }

        public override void glDraw()
        {
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            GL.glLoadIdentity();
            GL.glTranslatef(0, 0, -6f + lengthZ);
            
            GL.glScalef(1.4f, 1.4f, 1);

            GL.glRotatef(angleY, 0, 1, 0);
            GL.glRotatef(angleX, 1, 0, 0);
            GL.glRotatef(angleZ, 0, 0, 1);

            GL.glPushMatrix();
            GL.glRotatef(angleT, 0, 0, 1);
            GL.glBegin(GL.GL_POLYGON);
            GL.glColor3f(255, 0, 0);
            GL.glVertex3f(0, 1, 0);
            GL.glVertex3f(-1, -1, 0);
            GL.glVertex3f(1, -1, 0);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glTranslatef(0.1f, -0.4f, 1);
            GL.glRotatef(angleR, 0, 1, 0);
            GL.glBegin(GL.GL_POLYGON);
            GL.glColor3f(0, 255, 0);
            GL.glVertex3f(0.3f, 0.3f, 0);
            GL.glVertex3f(0.3f, -0.3f, 0);
            GL.glVertex3f(-0.3f, -0.3f, 0);
            GL.glVertex3f(-0.3f, 0.3f, 0);
            GL.glEnd();

        }

        protected override void InitGLContext()
        {
            GL.glShadeModel(GL.GL_SMOOTH);
            GL.glClearColor(0.0f, 0.0f, 0.0f, 0.5f);
            GL.glClearDepth(1.0f);
            GL.glEnable(GL.GL_DEPTH_TEST);
            GL.glDepthFunc(GL.GL_LEQUAL);
            GL.glHint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);
            Size s = this.Size;
            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.glLoadIdentity();
            GL.gluPerspective(45f, (double)s.Width / (double)s.Height, 0.1f, 100.0f);
            GL.glMatrixMode(GL.GL_MODELVIEW);
        }
    }

    public class MainForm : Form
    {
        private OurView view;

        public MainForm()
        {
            this.AutoScaleBaseSize = new Size(5, 13);
            this.ClientSize = new Size(740, 580);
            this.Name = "MainForm";
            this.Text = "Vjezba2";
            this.view = new OurView();
            this.view.Parent = this;
            this.view.Dock = DockStyle.Fill;
        }

        static void Main()
        {
            Application.Run(new MainForm());
        }
    }
}
