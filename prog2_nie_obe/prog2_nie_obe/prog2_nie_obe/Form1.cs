using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace prog2_nie_obe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Figure fig;

        private Axes axes;

        private const int DEFAULT_CAM_X = 5;
        private const int DEFAULT_CAM_Y = 5;
        private const int DEFAULT_CAM_Z = 5;

        /*
         * Set current rendering mode
         */
        private bool isOrtho = true;
        

        /*
         * Current camera position variables. 
         */ 
        private float camX = -5;
        private float camY = 0;
        private float camZ = 0;

        /*
         *  Prepares the projection matrics and loads the figure from a file.
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            redrawWorld();
        }

        /**
         * Clears the buffers and redraws the glControl with current figure. 
         */
        private void redrawWorld()
        {
            
            Matrix4 projMat = Matrix4.Zero;
            
            GL.MatrixMode(MatrixMode.Projection);

            if (isOrtho)
            {
                txtPerspective.Text = "Orthographic";
                projMat = Matrix4.CreateOrthographic(10.0f, 10.0f, 0.0f, 100.0f);
            }
            else
            {
                txtPerspective.Text = "Perspective";
                projMat = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 2.0f, 1, 1, 100);
            }

            GL.LoadMatrix(ref projMat);

            Matrix4 lookat = Matrix4.LookAt(camX, camY, camZ, 0, 0, 0, 0, 1, 0);

            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadMatrix(ref lookat);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            axes.Show();

            fig.Show();

            glControl1.SwapBuffers();

            updateCameraPosition();
        }
        
        /**
         * glControl load event.
         * Sets the 
         */ 
        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.DepthTest);
            GL.MatrixMode(MatrixMode.Projection);
            /*
            //Matrix4 projMat = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI/2.0f, 1, 1, 100);
            Matrix4 projMat = Matrix4.CreateOrthographic(20.0f, 20.0f, 0.0f, 100.0f);
            GL.LoadMatrix(ref projMat);


            Matrix4 lookat = Matrix4.LookAt(camX, camY, camZ, 0, 0, 0, 0, 1, 0);

            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadMatrix(ref lookat);*/

            fig = new Figure();

            axes = Axes.Instance;

            resetCamera();

            Axes.Instance.Show();

            redrawWorld();
        }

        /**
         * Camera's x position track bar scrolled event 
         */
        private void trkX_Scroll(object sender, EventArgs e)
        {

            camX = trkX.Value;

            updateCameraPosition();

            redrawWorld();
        }
        
        /**
         * Camera's y position track bar scrolled event 
         */
        private void trkY_Scroll(object sender, EventArgs e)
        {
            camY = trkY.Value;

            updateCameraPosition();

            redrawWorld();
        }
       
        /**
         * Camera's z position track bar scrolled event 
         */
        private void trkZ_Scroll(object sender, EventArgs e)
        {
            camZ = trkZ.Value;

            updateCameraPosition();

            redrawWorld();

        }

        /**
         * Exit button in the file menu. Closes the form. 
         */
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /**
         * Load button in the file menu. Brings up the file system to load a figure. 
         */
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;

                fig.Load(path);
            }

            redrawWorld();

        }

        /**
         * Updates the camera position lable.
         */
        private void updateCameraPosition()
        {
            lblZ.Text = "Z = " + camZ;
            lblY.Text = "Y = " + camY;
            lblX.Text = "X = " + camX;
        }

        /**
         * Resets the camera to default camera position.
         */
        private void resetCamera()
        {

            camX = DEFAULT_CAM_X;
            camY = DEFAULT_CAM_Y;
            camZ = DEFAULT_CAM_Z;

            trkX.Value = 5;
            trkY.Value = 5;
            trkZ.Value = 5;

            redrawWorld();

        }

        /**
         * Resets the camera and redraws the world.
         */
        private void resetBtn_Click(object sender, EventArgs e)
        {
            resetCamera();
            redrawWorld();
        }

        /**
         * Resizes the world when the form is resized.
         */
        private void Form1_Resize(object sender, EventArgs e)
        {

            redrawWorld();
        }

        /**
         * Keeps world updated while the form is active
         */
        private void Form1_Activated(object sender, EventArgs e)
        {
            redrawWorld();
        }

        /**
         * Switches between perspective and othrographic views
         */
        private void togglePerspectiveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            isOrtho = !isOrtho;
            redrawWorld();

        }
    }
}
