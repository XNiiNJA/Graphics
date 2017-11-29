
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
      new VertexData(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(1.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f)),
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
        GL.UseProgram(ShaderLoader.Instance.ProgramHandle);

        // Make the Vertex Buffer Object (VBO) and Vertex Array Object (VAO)
        GL.GenBuffers(1, out vboHandle);
        GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandle);
        GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(verts.Length * BlittableValueType.StrideOf(verts)), verts, BufferUsageHint.StreamDraw);

        GL.GenVertexArrays(1, out vaoHandle);
        GL.BindVertexArray(vaoHandle);


        //GL.EnableClientState(ArrayCap.VertexArray);       //Don't need these?????
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
    }
    
    public void Show()
    {
        GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandle);
        GL.UseProgram(ShaderLoader.Instance.ProgramHandle);
        GL.BindVertexArray(vaoHandle);

        Matrix4 identity = Matrix4.Identity;

        int normalMatrixLocation = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle,
                       "NormalMatrix");
        GL.UniformMatrix4(normalMatrixLocation, false, ref identity);

        int modelMatrixLocation = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle,
                                           "ModelMatrix");
        GL.UniformMatrix4(modelMatrixLocation, false, ref identity);



        int shininessLocation = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle,
                               "Shininess");
        GL.Uniform1(ShaderLoader.Instance.ProgramHandle, 0);


        GL.DrawArrays(PrimitiveType.Lines, 0, verts.Length);
        GL.BindVertexArray(0);
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.UseProgram(0);
        
    }
}
