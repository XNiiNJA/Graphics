using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

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

        private Vector3 max;
        private Vector3 min;
        
        private VertexDataList vdl;

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
                (max.X + min.X)/2, 
                (max.Y + min.Y)/2,
                (max.Z + min.Z)/2);

            displayMatrix = Matrix4.CreateTranslation(-fixedPoint);

            translateAmount = fixedPoint;
            

            GL.GenBuffers(1, out vboHandle);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandle);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(verts.Length * BlittableValueType.StrideOf(verts)), verts, BufferUsageHint.StaticDraw);

            GL.GenVertexArrays(1, out vaoHandle);
            GL.BindVertexArray(vaoHandle);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            GL.VertexPointer(3, VertexPointerType.Float, BlittableValueType.StrideOf(verts), (IntPtr)0);
            GL.ColorPointer(3, ColorPointerType.Float, BlittableValueType.StrideOf(verts), (IntPtr)12);

            GL.BindVertexArray(0);
            
        }

        public void Show(ref Matrix4 lookat)
        {

            GL.BindVertexArray(vaoHandle);

            //
            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadIdentity();

            Matrix4 ModelViewMatrix = displayMatrix * Matrix4.CreateTranslation(translateAmount) * lookat;

            GL.LoadMatrix(ref ModelViewMatrix);
            //

            GL.DrawArrays(PrimitiveType.Triangles, 0, verts.Length);
            GL.BindVertexArray(0);
        }

        public void Translate(Vector3 translation)
        {

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
            
        }
        
        public void RotateLocalX(Single angle)
        {

            Matrix4 rotMatrix = Matrix4.CreateRotationX(angle);
            
            displayMatrix = Matrix4.Mult(displayMatrix, rotMatrix);

        }

        public void RotateGlobalY(Single angle)
        {

            Matrix4 rotMatrix = Matrix4.CreateRotationY(angle);

            //Translate the object back to the center.
            Matrix4 transMatrix = Matrix4.CreateTranslation(-translateAmount);

            Matrix4 transBackMatrix = Matrix4.CreateTranslation(translateAmount);


            Matrix4 final = Matrix4.Mult(transBackMatrix, Matrix4.Mult(rotMatrix, transMatrix));

            displayMatrix = Matrix4.Mult(final, displayMatrix);
            

        }

        public void RotateLocalY(Single angle)
        {

            Matrix4 rotMatrix = Matrix4.CreateRotationY(angle);

            displayMatrix = Matrix4.Mult(rotMatrix, displayMatrix);

        }

        public void RotateGlobalZ(Single angle)
        {

            Matrix4 rotMatrix = Matrix4.CreateRotationZ(angle);

            //Translate the object back to the center.
            Matrix4 transMatrix = Matrix4.CreateTranslation(-translateAmount);

            Matrix4 transBackMatrix = Matrix4.CreateTranslation(translateAmount);


            Matrix4 final = Matrix4.Mult(transBackMatrix, Matrix4.Mult(rotMatrix, transMatrix));

            displayMatrix = Matrix4.Mult(final, displayMatrix);
            
        }

        public void RotateLocalZ(Single angle)
        {

            Matrix4 rotMatrix = Matrix4.CreateRotationZ(angle);

            displayMatrix = Matrix4.Mult(rotMatrix, displayMatrix);

        }


        public void Rotate(Vector3 axis, Single angle)
        {
            
            Matrix4 rotation = Matrix4.CreateFromAxisAngle(axis, angle);
            
        }


        public void Scale(Vector3 scaler)
        {
            Matrix4 scaleMatrix = Matrix4.CreateScale(scaler);

            displayMatrix = Matrix4.Mult(scaleMatrix, displayMatrix);

        }

    }
}
