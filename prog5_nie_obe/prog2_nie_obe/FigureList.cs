
using System;
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

        private const int POS_RANGE = 10;

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

        private List<FigureMovementPair> projectileList = new List<FigureMovementPair>();

        private FigureMovementPair projectileTemplate = new FigureMovementPair();

        public void AddProjectile(Vector3 frwd, Vector3 position)
        {
            FigureMovementPair projectileCopy = new FigureMovementPair();

            projectileCopy.fig = new Figure(projectileTemplate.fig);
            projectileCopy.movement = projectileTemplate.movement;

            projectileCopy.fig.forward = frwd;
            projectileCopy.fig.Translate(position);

            projectileList.Add(projectileCopy);
        }

        public int CheckCollisions()
        {
            /**
             * It was a double-for loop that removed colliding objects if an object from one list collided with an object from the other list
             *  (e.g, a projectile colliding with a piece of space debris).  I suggest that the outer loop goes backwards (know why!).  .... WHY???
             *  Also am I doing this right?
             */
            List<FigureMovementPair> reverseList = figlist;
            reverseList.Reverse();

            int score = 0;

            //foreach (FigureMovementPair fig in reverseList)
            for (int i = figlist.Count; i > 0; i--)
            {
                foreach (FigureMovementPair pro in projectileList)
                    if (figlist[i - 1].fig.CollidesWith(pro.fig))
                    {
                        figlist.Remove(figlist[i - 1]);
                        projectileList.Remove(pro);
                        score++;
                        break;
                    }
            }
            return score;
        }

        /// <summary>
        /// Loads all figures from the specified folder
        /// </summary>
        /// <param name="folderName">the complete file path to the folder containing the figures</param>
        public void LoadFigures(string folderName, int num)
        {

            string[] files = Directory.GetFiles(folderName, "*.wrl");

            Random rand = new Random((int)DateTime.Now.Ticks);

            while (figlist.Count < num)
            {
                foreach (string file in files)
                {

                    FigureMovementPair fmPair = new FigureMovementPair();

                    fmPair.fig = new Figure();

                    fmPair.fig.Load(file);

                    fmPair.movement = MovePattern.getRandom();

                    float xnew = (float)(rand.NextDouble() * (double)POS_RANGE * 2) - POS_RANGE;

                    float ynew = (float)(rand.NextDouble() * (double)POS_RANGE * 2) - POS_RANGE;

                    float znew = (float)(rand.NextDouble() * (double)POS_RANGE * 2) - POS_RANGE;

                    fmPair.fig.Translate(new Vector3(xnew, ynew, znew));
                    
                    figlist.Add(fmPair);
                        


                }

            }
            
            // probably dumb might not

            //It is, but we'll keep it for now.
            string projectileFile = ".\\..\\..\\..\\sphear.wrl";

            //"C:\\Users\\Grant\\Academics\\Fall\\2017\\Graphics\\github\\Graphics\\nie_obe.wrl";
            //                "C:\\Users\\n3wd4\\Documents\\Visual Studio 2015\\Projects\\Graphics\\Graphics\\prog5_nie_obe\\sphear.wrl";
            projectileTemplate.fig = new Figure();
            projectileTemplate.fig.Load(projectileFile);
            projectileTemplate.movement = MovePattern.getProjectile();

        }

        /**
         * Moves each figure in the figure list according to each figures paired movement pattern
         */
        public void moveAll()
        {

            foreach (var fmPair in figlist)
                fmPair.movement.Move(fmPair.fig);

            foreach (var fmPair in projectileList)
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

            foreach (var fmPair in projectileList)
                fmPair.fig.Show(ref lookat);

        }

        /**
         * resets all figures to their starting positions
         */
        public void resetAll()
        {
            foreach (var fmPair in figlist)
                fmPair.fig.loadInitTranslation();

            projectileList.RemoveAll(AllPairs);


            //foreach (var fmPair in projectileList)
            //    projectileList.Remove(fmPair);

        }

        /**
         * resets all figures to their starting positions
        */
        public void removeAll()
        {

            figlist.RemoveAll(AllPairs);

            projectileList.RemoveAll(AllPairs);


            //foreach (var fmPair in projectileList)
            //    projectileList.Remove(fmPair);

        }


        private static bool AllPairs(FigureMovementPair pair)
        {
            return true;
        }

        internal int Count()
        {
            return figlist.Count;
        }
    }

}