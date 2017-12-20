using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace prog3_nie_obe
{
    class Figure
    {

        private VertexData[] verts;
        private string name = null;
        private int vboHandle;
        private int vaoHandle;

        private Matrix4 displayMatrix;
        private Vector3 fixedPoint;
        private Vector3 translateAmount;

        //A normalized vector pointing in the forward direction of the figure.
        public Vector3 forward { get; set; }

        private Vector3 max;
        private Vector3 min;

        private VertexDataList vdl;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Figure()
        {

        }

        /// <summary>
        /// I added a "copy constructor" to Figure: public Figure(Figure f) that initialized all the data members using those from  f.
        /// I used this so that I could add projectiles to the Projectile list when the Fire button is pressed without re-reading from a file.
        /// </summary>
        /// <param name="f">projectile figure</param>
        public Figure(Figure f)
        {
            verts = f.verts;
            vboHandle = f.vboHandle;
            vaoHandle = f.vaoHandle;

            displayMatrix = f.displayMatrix;
            fixedPoint = f.fixedPoint;
            translateAmount = f.translateAmount;

            forward = f.forward;

            max = f.max;
            min = f.min;

            vdl = f.vdl;

            min = f.min;

            max = f.max;

            // Stuffs and stuff
        }

        public Vector3 CurrentCenter
        {
            get { return translateAmount; }
        }

        public void Load(string fileName)
        {
            name = new FileInfo(fileName).Name;
            name = name.Substring(0, name.IndexOf(".wrl"));

            vdl = new VertexDataList();

            vdl.LoadDataFromVRML(fileName);

            verts = vdl.VertexArray();

            //Loop through verts and get set the min/max;
            max = min = verts[0].Position;

            for (int i = 0; i < verts.Length; i++)
            {
                Vector3 curVert = verts[i].Position;

                //Finding maximums
                if (curVert.X > max.X)
                    max.X = curVert.X;
                if (curVert.Y > max.Y)
                    max.Y = curVert.Y;
                if (curVert.Z > max.Z)
                    max.Z = curVert.Z;

                //Finding minimums
                if (curVert.X < min.X)
                    min.X = curVert.X;
                if (curVert.Y < min.Y)
                    min.Y = curVert.Y;
                if (curVert.Z < min.Z)
                    min.Z = curVert.Z;

            }

            //Calculate fixed point
            fixedPoint = new Vector3(
                (max.X + min.X) / 2,
                (max.Y + min.Y) / 2,
                (max.Z + min.Z) / 2);

            loadInitTranslation();


            GL.GenBuffers(1, out vboHandle);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandle);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(verts.Length * BlittableValueType.StrideOf(verts)), verts, BufferUsageHint.StaticDraw);

            GL.GenVertexArrays(1, out vaoHandle);
            GL.BindVertexArray(vaoHandle);

            //GL.EnableClientState(ArrayCap.VertexArray);
            //GL.EnableClientState(ArrayCap.ColorArray);

            //GL.VertexPointer(3, VertexPointerType.Float, BlittableValueType.StrideOf(verts), (IntPtr)0);
            //GL.ColorPointer(3, ColorPointerType.Float, BlittableValueType.StrideOf(verts), (IntPtr)12);

            int vertPositionLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexPosition");
            GL.EnableVertexAttribArray(vertPositionLoc);
            GL.VertexAttribPointer(vertPositionLoc, 3, VertexAttribPointerType.Float, false, BlittableValueType.StrideOf(verts), (IntPtr)0);

            int vertColorLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexColor");
            GL.EnableVertexAttribArray(vertColorLoc);
            GL.VertexAttribPointer(vertColorLoc, 3, VertexAttribPointerType.Float, false, BlittableValueType.StrideOf(verts), (IntPtr)12);

            int vertNormalLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexNormal");
            GL.EnableVertexAttribArray(vertNormalLoc);
            GL.VertexAttribPointer(vertNormalLoc, 3, VertexAttribPointerType.Float, false, BlittableValueType.StrideOf(verts), (IntPtr)24);


            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.UseProgram(0);

            Random rand = new Random((int)DateTime.Now.Ticks);

            Shininess = 1.0f; //(float)rand.NextDouble();

        }

        public void Show(ref Matrix4 lookat)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandle);
            GL.UseProgram(ShaderLoader.Instance.ProgramHandle);
            GL.BindVertexArray(vaoHandle);

            //Set the matrix mode to modelview
            //GL.MatrixMode(MatrixMode.Modelview);

            Matrix4 ModelMatrix = displayMatrix * Matrix4.CreateTranslation(translateAmount);

            //Calculate the next model view matrix.
            Matrix4 ModelViewMatrix = displayMatrix * Matrix4.CreateTranslation(translateAmount) * lookat;



            //Create normal matrix which is inverse transpose of ModelView matrix
            Matrix4 normalMatrix = ModelViewMatrix;
            normalMatrix.Transpose();
            normalMatrix.Invert();

            
            int normalMatrixLocation = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle,
                                   "NormalMatrix");
            GL.UniformMatrix4(normalMatrixLocation, false, ref normalMatrix);


            
            int modelMatrixLocation = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle,
                                               "ModelMatrix");
            GL.UniformMatrix4(modelMatrixLocation, false, ref ModelMatrix);

            
            int shininessLocation = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle,
                                   "Shininess");
            GL.Uniform1(shininessLocation, Shininess);

            //Load model view matrix.
            //GL.LoadMatrix(ref ModelViewMatrix);

            GL.DrawArrays(PrimitiveType.Triangles, 0, verts.Length);
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.UseProgram(0);
        }

        public float Shininess { get; set; }

        public void loadInitTranslation()
        {
            //Make the display matrix a translation to the fixed point.
            displayMatrix = Matrix4.CreateTranslation(-fixedPoint);

            //Set the initial translate amount to the fixed point
            translateAmount = fixedPoint;

            forward = new Vector3(0, 0, 1);

        }


        public void Translate(Vector3 translation)
        {
            //Translate by changing the position
            translateAmount += translation;

        }


        public void RotateGlobalX(Single angle)
        {

            Matrix4 rotMatrix = Matrix4.CreateRotationX(angle);

            //Translate the object back to the center.
            Matrix4 transMatrix = Matrix4.CreateTranslation(-translateAmount);

            Matrix4 transBackMatrix = Matrix4.CreateTranslation(translateAmount);

            Matrix4 final = Matrix4.Mult(transBackMatrix, Matrix4.Mult(rotMatrix, transMatrix));

            displayMatrix = Matrix4.Mult(final, displayMatrix);

            forward = Vector3.TransformNormal(forward, final);

        }

        //Translate on the local X axis of the figure.
        public void RotateLocalX(Single angle)
        {

            Matrix4 rotMatrix = Matrix4.CreateRotationX(angle);

            displayMatrix = Matrix4.Mult(displayMatrix, rotMatrix);

            forward = Vector3.TransformNormal(forward, rotMatrix);

        }

        //Translate on the global Y axis.
        public void RotateGlobalY(Single angle)
        {

            Matrix4 rotMatrix = Matrix4.CreateRotationY(angle);

            //Translate the object back to the center.
            Matrix4 transMatrix = Matrix4.CreateTranslation(-translateAmount);

            Matrix4 transBackMatrix = Matrix4.CreateTranslation(translateAmount);


            Matrix4 final = Matrix4.Mult(transBackMatrix, Matrix4.Mult(rotMatrix, transMatrix));

            displayMatrix = Matrix4.Mult(final, displayMatrix);

            forward = Vector3.TransformNormal(forward, final);
        }

        //Translate on the local Y axis of the figure.
        public void RotateLocalY(Single angle)
        {

            Matrix4 rotMatrix = Matrix4.CreateRotationY(angle);

            displayMatrix = Matrix4.Mult(rotMatrix, displayMatrix);

            forward = Vector3.TransformNormal(forward, rotMatrix);

        }

        //Translate on the global Z axis.
        public void RotateGlobalZ(Single angle)
        {

            Matrix4 rotMatrix = Matrix4.CreateRotationZ(angle);

            //Translate the object back to the center.
            Matrix4 transMatrix = Matrix4.CreateTranslation(-translateAmount);

            Matrix4 transBackMatrix = Matrix4.CreateTranslation(translateAmount);


            Matrix4 final = Matrix4.Mult(transBackMatrix, Matrix4.Mult(rotMatrix, transMatrix));

            displayMatrix = Matrix4.Mult(final, displayMatrix);

            forward = Vector3.TransformNormal(forward, final);

        }

        //Translate on the local Z axis of the figure.
        public void RotateLocalZ(Single angle)
        {

            Matrix4 rotMatrix = Matrix4.CreateRotationZ(angle);

            displayMatrix = Matrix4.Mult(rotMatrix, displayMatrix);

            forward = Vector3.TransformNormal(forward, rotMatrix);

        }

        //Do a rotation along a user-defined axis.
        public void Rotate(Vector3 axis, Single angle)
        {

            Matrix4 rotation = Matrix4.CreateFromAxisAngle(axis, angle);

            displayMatrix = Matrix4.Mult(rotation, displayMatrix);

            forward = Vector3.TransformNormal(forward, rotation);

        }

        public void OrbitPoint(Vector3 axis, Vector3 point, Single angle)
        {
            
            //Translate the object back to the center.
            Matrix4 transMatrix = Matrix4.CreateTranslation(-point);

            Matrix4 transBackMatrix = Matrix4.CreateTranslation(point);

            Matrix4 rotation = Matrix4.CreateFromAxisAngle(axis, angle);
            
            Matrix4 final = Matrix4.Mult(Matrix4.Mult(transBackMatrix, rotation), transMatrix);
            
            displayMatrix = Matrix4.Mult(final, displayMatrix);

            forward = Vector3.TransformNormal(forward, final);
            
        }

        //Scale the object with a vector.
        public void Scale(Vector3 scaler)
        {
            Matrix4 scaleMatrix = Matrix4.CreateScale(scaler);

            displayMatrix = Matrix4.Mult(scaleMatrix, displayMatrix);

            forward = Vector3.TransformNormal(forward, scaleMatrix);

        }

        public bool CollidesWith(Vector3 OtherObjectMax, Vector3 OtherObjectMin, Vector3 OtherObjectPosition)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((max[i] + translateAmount[i]) <
                    (OtherObjectMin[i] + OtherObjectPosition[i]) ||
                    (OtherObjectMax[i] + OtherObjectPosition[i]) <
                    (min[i] + translateAmount[i]))
                    return false;
            }
            return true;
        }

        public bool CollidesWith(Figure f)
        {
            return CollidesWith(f.max, f.min, f.translateAmount);
        }


    }
}
