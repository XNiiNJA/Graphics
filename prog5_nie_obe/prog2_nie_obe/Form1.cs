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
 using prog4_nie_obe;

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

        private const int FORWARD_KEY = 87;
        private const int LEFT_KEY = 65;
        private const int BACK_KEY = 83;
        private const int RIGHT_KEY = 68;
        private const int UP_KEY = 16;
        private const int DOWN_KEY = 17;
        private const int SPACE_KEY = 32;

        private const int INIT_TIME = 480;

        private static int score = 0;

        private static int gameTime = INIT_TIME;

        private bool forwardDown = false;
        private bool backwardDown = false;

        private bool leftDown = false;
        private bool rightDown = false;

        private bool upDown = false;
        private bool downDown = false;

        private bool spaceDown = false;

        private Decimal globalAmbient;

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

        Vector3 lightPos = new Vector3(5.0f, 5.0f, 5.0f);

        Vector3 lightColor = new Vector3(1.0f, 1.0f, 1.0f);

        /*
         *  Prepares the projection matrics and loads the figure from a file.
         */
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /**
         * Clears the buffers and redraws the glControl with current figure. 
         */
        private void redrawWorld()
        {
            
            Matrix4 projMat = Matrix4.Zero;
            Matrix4 lookat = Matrix4.Zero;
            

            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            

            //GL.MatrixMode(MatrixMode.Projection);

            if (isOrtho)
            {
                projMat = Matrix4.CreateOrthographic(10.0f, 10.0f, 0.0f, 100.0f);
            }
            else
            {                
                projMat = Matrix4.CreatePerspectiveOffCenter(
                    -2.0f, 2.0f, -2.0f, 2.0f, 2.0f, 500.0f);
            }
            GL.UseProgram(ShaderLoader.Instance.ProgramHandle);
            //GL.LoadMatrix(ref projMat);

            int projMatrixLocation = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle,
                       "ProjectionMatrix");
            GL.UniformMatrix4(projMatrixLocation, false, ref projMat);

            lookat = Ship.Instance.LookAt();
                //Matrix4.LookAt(camX, camY, camZ, 0, 0, 0, 0, 1, 0);


            int lookatMatLoc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ViewMatrix");
            GL.UniformMatrix4(lookatMatLoc, false, ref lookat);

            int ambientLocation = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "GlobalAmbient");
            GL.Uniform1(ambientLocation, (float)globalAmbient);

            int lgtPosLocation = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "LightPosition");
            GL.Uniform3(lgtPosLocation, Ship.Instance.Position);

            int lgtColorLocation = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "LightColor");
            GL.Uniform3(lgtColorLocation, lightColor);

            int viewMatrixLocation = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle,
                       "ViewMatrix");
            GL.UniformMatrix4(viewMatrixLocation, false, ref lookat);

            int lgtSpotDirection = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "SpotDirection");
            GL.Uniform3(lgtSpotDirection, Ship.Instance.Direction);

            int lgtSpotAngle = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "spotCutOffAngle");
            GL.Uniform1(lgtSpotAngle, (float)60);

            int lgtSpotExponent = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "spotExponent");
            GL.Uniform1(lgtSpotExponent, (float)5);

            GL.UseProgram(0);

            //GL.MatrixMode(MatrixMode.Modelview);

            //GL.LoadMatrix(ref lookat);
            
            figList.drawAll(ref lookat);

            glControl1.SwapBuffers();

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

            globalAmbient = (Decimal)0.1;

            figList = new FigureList();

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
            //file.SelectedPath = "K:\\Courses\\CSSE\\tianb\\cs3920_cs5920\\nie_obe";
            //file.SelectedPath = "C:\\Users\\n3wd4\\Documents\\Visual Studio 2015\\Projects\\Graphics\\Graphics\\prog5_nie_obe";
            //file.SelectedPath = "C:\\Users\\n3wd4\\Documents\\Visual Studio 2015\\Projects\\Graphics\\Graphics\\prog5_nie_obe";
            file.SelectedPath = "C:\\Users\\Grant\\Academics\\Fall\\2017\\Graphics\\github\\Graphics";
            if (file.ShowDialog() == DialogResult.OK)
            {
                String path = file.SelectedPath;

                figList.LoadFigures(path);

            }

            redrawWorld();

        }

        /**
         * Resets the camera and redraws the world.
         */
        private void resetBtn_Click(object sender, EventArgs e)
        {
            Ship.Instance.Reset();
            figList.resetAll();
            redrawWorld();

            score = 0;

            gameTime = INIT_TIME;

            targLbl.Text = "Targets Remaining: " + figList.Count();
            scoreLbl.Text = "Score: " + score;
            timeLbl.Text = "Time Remaining: " + gameTime;

            tmrGame.Start();
        }

        /**
         * Resizes the world when the form is resized.
         */
        private void Form1_Resize(object sender, EventArgs e)
        {

            //redrawWorld();
        }

        /**
         * Keeps world updated while the form is active
         */
        private void Form1_Activated(object sender, EventArgs e)
        {
            redrawWorld();
        }

        /**
         * Timer that moves all figures on ticks and redraws world
         */
        private void tmrMove_Tick(object sender, EventArgs e)
        {

            if (forwardDown)
                Ship.Instance.ChangeDirection(0, -0.01f);
            if (leftDown)
                Ship.Instance.ChangeDirection(0.01f, 0);
            if (rightDown)
                Ship.Instance.ChangeDirection(-0.01f, 0);
            if (backwardDown)
                Ship.Instance.ChangeDirection(0, 0.01f);
            if (upDown)
                Ship.Instance.Move(1);
            if (downDown)
                Ship.Instance.Move(-1);
            if (spaceDown)
                figList.AddProjectile(Ship.Instance.Direction, Ship.Instance.Position);

            figList.moveAll();

            score += figList.CheckCollisions();

            scoreLbl.Text = "Score: " + score;

            targLbl.Text = "Targets Remaining: " + figList.Count();
            
            redrawWorld();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShaderLoader.Instance.Unload();
        }

        private void glControl1_KeyUp(object sender, KeyEventArgs e)
        {

            if (FORWARD_KEY == e.KeyValue)
            {
                forwardDown = false;
            }
            else if (LEFT_KEY == e.KeyValue)
            {
                leftDown = false;
            }
            else if (RIGHT_KEY == e.KeyValue)
            {
                rightDown = false;
            }
            else if (BACK_KEY == e.KeyValue)
            {
                backwardDown = false;
            }
            else if (UP_KEY == e.KeyValue)
            {
                upDown = false;
            }
            else if (DOWN_KEY == e.KeyValue)
            {
                downDown = false;
            }
            else if (SPACE_KEY == e.KeyValue)
            {
                spaceDown = false;
            }

        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (FORWARD_KEY == e.KeyValue)
            {
                forwardDown = true;
            }
            else if (LEFT_KEY == e.KeyValue)
            {
                leftDown = true;
            }
            else if (RIGHT_KEY == e.KeyValue)
            {
                rightDown = true;
            }
            else if (BACK_KEY == e.KeyValue)
            {
                backwardDown = true;
            }
            else if (UP_KEY == e.KeyValue)
            {
                upDown = true;
            }
            else if (DOWN_KEY == e.KeyValue)
            {
                downDown = true;
            }
            else if (SPACE_KEY == e.KeyValue)
            {
                spaceDown = true;
            }
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            if (gameTime <= 0)
            {
                tmrGame.Stop();
                //game over
            }
            gameTime--;

            timeLbl.Text = "Time Remaining: " + gameTime;
        }
    }
}
