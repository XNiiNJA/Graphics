using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace prog3_nie_obe
{
    /**
     * Class to define movement patterns for figures
     */
    abstract class MovePattern
    {
        public const int MOVE_PATTERN_COUNT = 2;
        static public Random rand = new Random((int)DateTime.Now.Ticks);
      abstract public void Move(Figure fig);

        public static MovePattern getProjectile()
        {
            return new MovePatternProjectile();
        }

        /**
         * Returns a random movement pattern from a predetermined list of movement patterns
         */
        public static MovePattern getRandom()
        {

            Random rand = new Random((int)DateTime.Now.Ticks);

            int index = (int)(rand.NextDouble() * (double)MOVE_PATTERN_COUNT);
            //int index = 4;
            
            switch (index)
            {

/*                case 0:

                    return new QuantumRealm();

                    break;

                case 1:

                    return new MovePatternTwist();

                    break;*/

                case 0:

                    return new MovePatternSin();

                    break;

                case 1:

                    return new QuantumRealm();

                    break;

                default:

                    return new MovePatternMore();

                    break;

            }


        }



    }

    /**
     * First movement pattern
     * Scales and Rotates in a pulsating pattern
     */
    class QuantumRealm : MovePattern
    {
        // You can declare whatever state variables you need to define the move

        const float SCALE_RATE = 1.01f;

        const float ROTATE_RATE = 0.01f;

        const float COUNT_MAX = 50;
        
        int count = 0;

        bool grow = true;

        public override void Move(Figure fig)
        {

            float val = SCALE_RATE;

            float rot = ROTATE_RATE;

            if (!grow)
            {
                val = 1 / SCALE_RATE;
                rot = -rot;
            }

            fig.Scale(new Vector3(val, val, val));

            fig.RotateLocalX(rot);

            fig.RotateLocalY(rot);

            fig.RotateLocalZ(rot);

            count++;

            if (count == COUNT_MAX)
            {
                count = 0;
                grow = !grow;
            }


        }

    }

    /**
     * Orbits a set distance around the Z-axis
     */
    class MovePatternTwist : MovePattern
    {
        private bool firstPass = true;

        private const int RAND_RANGE = 10;
        

        public override void Move(Figure fig)
        {
            //Make sure we are orbiting the axis
            float orbitdist = (float)Math.Sqrt(Math.Pow(fig.CurrentCenter.X, 2.0f) + Math.Pow(fig.CurrentCenter.Y, 2.0f));

            if (firstPass)
            {
                


            }


            /*if (Math.Abs(orbitdist) < 4.0f)
            {

                //Push us out from the line a bit so we can perform an orbit.
                fig.Translate(new Vector3(0.1f, 0, 0));

            }
            else
            {*/

            //    fig.RotateGlobalZ(0.1f);

            fig.OrbitPoint(new Vector3(1, 0, 0), new Vector3(0, 0, -20), 0.1f);


            //}
        }

    }


    class MovePatternSin : MovePattern
    {
        bool firstPass = true;
        static Random rand = new Random((int)DateTime.Now.Ticks);

        int axis = (int)((float)rand.NextDouble() * 3.0f);

        public override void Move(Figure fig)
        {

            float orbitdist = (float)Math.Sqrt(Math.Pow(fig.CurrentCenter.Z, 2.0f) + Math.Pow(fig.CurrentCenter.X, 2.0f) + Math.Pow(fig.CurrentCenter.Y, 2.0f));


            if (orbitdist < 4)
            {
                firstPass = false;

                switch(axis)
                {
                    case 0:
                        fig.Translate(new Vector3(5, 0, 0));
                        break;

                    case 1:
                        fig.Translate(new Vector3(0, 5, 0));
                        break;

                    case 2:
                        fig.Translate(new Vector3(0, 0, 5));
                        break;

                    default:
                        fig.Translate(new Vector3(5, 0, 0));
                        break;
                }
            }
            fig.Rotate(new Vector3(1, 1, 1), 0.1f);

        }

    }


    class MovePatternMore : MovePattern
    {
        
        public override void Move(Figure fig)
        {
            
            fig.Translate(new Vector3(0.1f, 0, 0));
            fig.RotateLocalX(0.01f);
            fig.Scale(new Vector3(0.99f, 0.99f, 0.99f));
        }

    }

    class MovePatternProjectile : MovePattern
    {
        public override void Move(Figure fig)
        {
            fig.Translate(fig.forward);
        }
    }


}
