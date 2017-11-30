using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace prog4_nie_obe
{
    class Class1
    {
        public static void Main()
        {
            Vector4 r1 = new Vector4(1, 2, 3, 4);
            Vector4 r2 = new Vector4(5, 6, 7, 8);
            Vector4 r3 = new Vector4(8, 9, 10, 11);
            Vector4 r4 = new Vector4(12, 13, 14, 15);

            Matrix4 reg = new Matrix4(r1, r2, r3, r4);

            Matrix4 inv = reg;
            inv.Invert();

            Matrix4 trans = reg;
            trans.Transpose();

            Matrix4 invTrans = reg;
            invTrans.Invert();
            invTrans.Transpose();

            Matrix4 TransInv = reg;
            TransInv.Transpose();
            TransInv.Invert();

            Console.WriteLine("The Narwhal Bacons at Midnight");

        }


        
    }
}
