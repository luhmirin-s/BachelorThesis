using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Mutation
{
    interface IMutation
    {

        void Mutate(AbstractRobot robot);

    }
}
