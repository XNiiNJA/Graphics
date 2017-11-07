using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace prog3_nie_obe
{
    
    abstract class MovePattern
    {
        public const int MOVE_PATTERN_COUNT = 4;

        abstract public void Move(Figure fig);

        public static MovePattern getRandom()
        {

            Random rand = new Random((int)DateTime.Now.Ticks);

            int index = (int)(rand.NextDouble() * (double)MOVE_PATTERN_COUNT);

            switch (index)
            {

                case 0:

                    return new QuantumRealm();

                    break;

                case 1:

                    return new MovePatternTwist();

                    break;

                case 2:

                    return new MovePatternSin();

                    break;

                case 3:

                    return new MovePatternMore();

                    break;

                default:

                    return new QuantumRealm();

                    break;

            }


        }



    }

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


    class MovePatternTwist : MovePattern
    {
        // You can declare whatever state variables you need to define the move

        bool first = true;

        public override void Move(Figure fig)
        {
            // Want rotates, scales, translates - clever moves!
            // As an example of a start - move a little in the X.

            if(first)
            {
                //First pass
                fig.Translate(new Vector3(0, 0, 4));
                first = false;
            }

            fig.RotateGlobalX(0.1f);


        }

    }


    class MovePatternSin : MovePattern
    {
        // You can declare whatever state variables you need to define the move

        public override void Move(Figure fig)
        {
            // Want rotates, scales, translates - clever moves!
            // As an example of a start - move a little in the X.

            //fig.Translate(new Vector3(0.1f, 0.1f, 0.1f));

            fig.RotateLocalX(0.01f);

            fig.RotateLocalY(0.04f);

            fig.RotateLocalZ(0.02f);

        }

    }


    class MovePatternMore : MovePattern
    {
        // You can declare whatever state variables you need to define the move

        public override void Move(Figure fig)
        {
            // Want rotates, scales, translates - clever moves!
            // As an example of a start - move a little in the X.

            fig.Translate(new Vector3(0.1f, 0, 0));

        }

    }


}
