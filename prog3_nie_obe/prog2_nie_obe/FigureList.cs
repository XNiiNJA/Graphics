
using System.Collections.Generic;

using System.IO;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace prog3_nie_obe
{
    class FigureList
    {
        private struct FigureMovementPair
        {
            public Figure fig;
            public MovePattern movement;
        }

        private List<FigureMovementPair> figlist =
            new List<FigureMovementPair>();

        public void LoadFigures(string folderName)
        {

            string[] files = Directory.GetFiles(folderName, "*.wrl");

            foreach (string file in files)
            {

                FigureMovementPair fmPair = new FigureMovementPair();

                fmPair.fig = new Figure();

                fmPair.fig.Load(file);

                fmPair.movement = MovePattern.getRandom();

                figlist.Add(fmPair);

            }
            
        }

        public void moveAll()
        {

            foreach (var fmPair in figlist)
                fmPair.movement.Move(fmPair.fig);

        }

        public void drawAll(ref Matrix4 lookat)
        {
            foreach (var fmPair in figlist)
                fmPair.fig.Show(ref lookat);
        }

    }

}