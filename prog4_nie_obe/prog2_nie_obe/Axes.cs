
using System;

using OpenTK;
using OpenTK.Graphics.OpenGL4;


public class Axes
{
    private static Axes _instance = null;
    private int vboHandle;
    private int vaoHandle;

    private VertexData[] verts =
    {
      /*Set up X Axis*/
      new VertexData(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(1.0f, 0.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f)),
      new VertexData(new Vector3(200.0f, 0.0f, 0.0f), new Vector3(1.0f, 0.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f)),

      /*Set up Y Axis*/
      new VertexData(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f)),
      new VertexData(new Vector3(0.0f, 200.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f)),

      /*Set up Z Axis*/
      new VertexData(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f)),
      new VertexData(new Vector3(0.0f, 0.0f, 200.0f), new Vector3(0.0f, 0.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f)),
   };

    public static Axes Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Axes();
            return _instance;
        }
    }

    private Axes()
    {
        

        // Make the Vertex Buffer Object (VBO) and Vertex Array Object (VAO)
        GL.GenBuffers(1, out vboHandle);
        GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandle);
        GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(verts.Length * BlittableValueType.StrideOf(verts)), verts, BufferUsageHint.StaticDraw);

        GL.GenVertexArrays(1, out vaoHandle);
        GL.BindVertexArray(vaoHandle);


        //GL.EnableClientState(ArrayCap.VertexArray);       //Don't need these?????
        //GL.EnableClientState(ArrayCap.ColorArray);

        //GL.VertexPointer(3, VertexPointerType.Float, BlittableValueType.StrideOf(verts), (IntPtr)0);
        //GL.ColorPointer(3, ColorPointerType.Float, BlittableValueType.StrideOf(verts), (IntPtr)12);


        int vertNormalLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexNormal");
        GL.EnableVertexAttribArray(vertNormalLoc);
        GL.VertexAttribPointer(vertNormalLoc, 3, VertexAttribPointerType.Float, true, BlittableValueType.StrideOf(verts), (IntPtr)24);

        int vertPositionLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexPosition");
        GL.EnableVertexAttribArray(vertPositionLoc);
        GL.VertexAttribPointer(vertPositionLoc, 3, VertexAttribPointerType.Float, true, BlittableValueType.StrideOf(verts), (IntPtr)0);

        int vertColorLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexColor");
        GL.EnableVertexAttribArray(vertColorLoc);
        GL.VertexAttribPointer(vertColorLoc, 3, VertexAttribPointerType.Float, true, BlittableValueType.StrideOf(verts), (IntPtr)12);



        GL.BindVertexArray(0);
    }
    
    public void Show()
    {
        GL.BindVertexArray(vaoHandle);
        GL.DrawArrays(PrimitiveType.Lines, 0, verts.Length);
        GL.BindVertexArray(0);
    }
}
