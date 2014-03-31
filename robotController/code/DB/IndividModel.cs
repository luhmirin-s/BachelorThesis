using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.DB
{
    class IndividModel
    {

        public int IndividModelId 
        { 
            get; 
            set; 
        }

        public DateTime ExperimentTimestamp
        {
            get;
            set;
        }

        public int Generation
        {
            get;
            set;
        }

        public float Fitness
        {
            get;
            set;
        }

        public float[] Weights
        {
            get;
            set;
        }


    }
}
