using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.NN
{
    class Synapse
    {

        public float Weight
        {
            get;
            set;
        }


        public Neuron From
        {
            get;
            set;
        }

        public Synapse(Neuron from, float weight)
        {
            From = from;
            Weight = weight;
        }

    }
}
