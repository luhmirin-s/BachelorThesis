using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Mutations
{
    abstract class Mutation
    {

        public abstract void Mutate(AbstractRobot robot);

    }
}
