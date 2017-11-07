using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace prog2_nie_obe
{
    class Figure
    {

        private VertexData[] verts;
        private string name = null;
        private int vboHandle;
        private int vaoHandle;

        private VertexDataList vdl;

        /**
         * Load the vertex data from a file.
         */ 
        public void Load(string fileName)
        {
            name = new FileInfo(fileName).Name;
            name = name.Substring(0, name.IndexOf(".wrl"));
            
            vdl = new VertexDataList();

            vdl.LoadDataFromVRML(fileName);

            verts = vdl.VertexArray();

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

        /*
         * Show the vertex data if it exists.
         */ 
        public void Show()
        {
            if (verts != null)
            {
                GL.BindVertexArray(vaoHandle);
                GL.DrawArrays(PrimitiveType.Triangles, 0, verts.Length);
                GL.BindVertexArray(0);
            }
        }

    }
}
