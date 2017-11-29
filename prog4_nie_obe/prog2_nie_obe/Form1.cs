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
using OpenTK.Graphics.OpenGL4;

namespace prog3_nie_obe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private FigureList figList;
        
        private const int DEFAULT_CAM_X = 5;
        private const int DEFAULT_CAM_Y = 5;
        private const int DEFAULT_CAM_Z = 5;
        
        /*
         * Set current rendering mode
         */
        private bool isOrtho = false;
        

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
            updateCameraPosition();
            trkTime.Value = tmrMove.Interval;
        }

        /**
         * Clears the buffers and redraws the glControl with current figure. 
         */
        private void redrawWorld()
        {
            
            Matrix4 projMat = Matrix4.Zero;
            Matrix4 lookat = Matrix4.Zero;
            
            //GL.MatrixMode(MatrixMode.Projection);

            if (isOrtho)
            {
                txtPerspective.Text = "Orthographic";
                projMat = Matrix4.CreateOrthographic(10.0f, 10.0f, 0.0f, 100.0f);
            }
            else
            {
                txtPerspective.Text = "Perspective";
                projMat = Matrix4.CreatePerspectiveOffCenter(
                    -2.0f, 2.0f, -2.0f, 2.0f, 2.0f, 80.0f);


            }

            //GL.LoadMatrix(ref projMat);

            int projMatrixLocation = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle,
                       "ProjectionMatrix");
            GL.UniformMatrix4(projMatrixLocation, false, ref projMat);

            lookat = Matrix4.LookAt(camX, camY, camZ, 0, 0, 0, 0, 1, 0);

            int lookatMatLoc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ViewMatrix");
            GL.UniformMatrix4(lookatMatLoc, false, ref lookat);

            //GL.MatrixMode(MatrixMode.Modelview);

            //GL.LoadMatrix(ref lookat);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            figList.drawAll(ref lookat);

            glControl1.SwapBuffers();

            //updateCameraPosition();
        }
        
        /**
         * glControl load event.
         * Sets the 
         */ 
        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.DepthTest);

            String vertShaderFileName = "Prog4_VS.glsl";
            String fragShaderFileName = "Prog4_FS.glsl";

            if (!ShaderLoader.Instance.Load(vertShaderFileName, fragShaderFileName))
                MessageBox.Show(ShaderLoader.Instance.LastLoadError);

            /*GL.MatrixMode(MatrixMode.Projection);
            
            //Matrix4 projMat = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI/2.0f, 1, 1, 100);
            Matrix4 projMat = Matrix4.CreateOrthographic(20.0f, 20.0f, 0.0f, 100.0f);
            GL.LoadMatrix(ref projMat);


            Matrix4 lookat = Matrix4.LookAt(camX, camY, camZ, 0, 0, 0, 0, 1, 0);

            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadMatrix(ref lookat);*/

            figList = new FigureList();
            
            resetCamera();
            
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
            
            FolderBrowserDialog file = new FolderBrowserDialog();

         //file.RootFolder = System.Environment.SpecialFolder.MyComputer;
         file.SelectedPath = "K:\\Courses\\CSSE\\tianb\\cs3920_cs5920\\nie_obe";
            if (file.ShowDialog() == DialogResult.OK)
            {
                String path = file.SelectedPath;

                figList.LoadFigures(path);

            }

            redrawWorld();

        }

        /**
         * Updates the camera position lable.
         */
        private void updateCameraPosition()
        {
            txtZ.Text = camZ.ToString();
            txtY.Text = camY.ToString();
            txtX.Text = camX.ToString();
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

            txtX.Text = "5";
            txtY.Text = "5";
            txtZ.Text = "5";

            redrawWorld();

        }

        /**
         * Resets the camera and redraws the world.
         */
        private void resetBtn_Click(object sender, EventArgs e)
        {
            resetCamera();
            redrawWorld();
            figList.resetAll();
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

        /**
         * Timer that moves all figures on ticks and redraws world
         */
        private void tmrMove_Tick(object sender, EventArgs e)
        {

            figList.moveAll();
            redrawWorld();

        }

        /**
         * Trackbar that controrls the interval of the ticks
         */
        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            if (trkTime.Value == 0)
                tmrMove.Enabled = false;
            else
            {
                tmrMove.Enabled = true;
                tmrMove.Interval = trkTime.Value;
            }
        }

        /**
         * Text box to adjust camera X position, Allows fine control
         */
        private void txtX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                camX = float.Parse(txtX.Text);
                trkX.Value = (int)camX;
                redrawWorld();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

        }

        /**
         * Text box to adjust camera Y position, Allows fine control
         */
        private void txtY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                camY = float.Parse(txtY.Text);
                trkY.Value = (int)camY;
                redrawWorld();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /**
         * Text box to adjust camera Z position, Allows fine control
         */
        private void txtZ_TextChanged(object sender, EventArgs e)
        {
            try
            {
                camZ = float.Parse(txtZ.Text);
                trkZ.Value = (int)camZ;
                redrawWorld();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShaderLoader.Instance.Unload();
        }

        private void lightXtxt_TextChanged(object sender, EventArgs e)
        {
            lightRePos();
        }

        private void lightYtxt_TextChanged(object sender, EventArgs e)
        {
            lightRePos();
        }

        private void lightZtxt_TextChanged(object sender, EventArgs e)
        {
            lightRePos();
        }

        private void lightRePos()
        {
            try
            {
                int lightX = Convert.ToInt32(lightXtxt.Text);
                int lightY = Convert.ToInt32(lightYtxt.Text);
                int lightZ = Convert.ToInt32(lightZtxt.Text);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void lightRedBar_Scroll(object sender, EventArgs e)
        {
            lightReColor();
        }

        private void lightGrnBar_Scroll(object sender, EventArgs e)
        {
            lightReColor();
        }

        private void lightBlueBar_Scroll(object sender, EventArgs e)
        {
            lightReColor();
        }

        private void lightReColor()
        {
            int red = lightRedBar.Value;
            int green = lightGrnBar.Value;
            int blue = lightBlueBar.Value;

            groupBox2.BackColor = Color.FromArgb(red, green, blue);
        }

        private void globalAmbientNum_ValueChanged(object sender, EventArgs e)
        {
            Decimal globalAmbient = globalAmbientNum.Value;
        }
    }
}
