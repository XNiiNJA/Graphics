
using System.Collections.Generic;
using System.IO;
using OpenTK;
//using OpenTK.Graphics.OpenGL4;

namespace prog3_nie_obe
{
    /**
     * Class to maintain a list of figure and movement pattern pairs
     */
    class FigureList
    {
        /**
         * Struct for one figure paired with one movment pattern
         */
        private struct FigureMovementPair
        {
            public Figure fig;
            public MovePattern movement;
        }

        private List<FigureMovementPair> figlist =
            new List<FigureMovementPair>();

        /**
         * Loads all figures from the specified folder
         * @param folderName: the complete file path to the folder containing the figures
         */
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

        /**
         * Moves each figure in the figure list according to each figures paired movement pattern
         */
        public void moveAll()
        {

            foreach (var fmPair in figlist)
                fmPair.movement.Move(fmPair.fig);

        }

        /**
         * Redraws each figure in the figure list after each movement
         */
        public void drawAll(ref Matrix4 lookat)
        {
            
            Axes.Instance.Show();

            foreach (var fmPair in figlist)
                fmPair.fig.Show(ref lookat);
            
        }

        /**
         * resets all figures to their starting positions
         */
        public void resetAll()
        {
            foreach (var fmPair in figlist)
                fmPair.fig.loadInitTranslation();

        }

    }

}