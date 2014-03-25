using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA
{
    class Allel
    {
        const int MAX = 0xFFFF;
        const int HALF = 0xFF;

        public byte[] Genes
        {
            get;
            private set;
        }

        public Allel(float value)
        {
            Genes = new byte[2];
            int tmp = (int)(MAX * value);
            // high byte
            Genes[0] = (byte)(tmp >> 8) ;
            //low byte
            Genes[1] = (byte)tmp;
        }

        public float getValue()
        {
            int tmp = (Genes[1] | ((int)Genes[0] << 8));
            return (float)tmp / MAX;
        }

    }
}
