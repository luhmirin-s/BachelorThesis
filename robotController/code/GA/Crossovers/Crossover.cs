
using RobotSimulationController.GA.Mutations;
using System;
using System.Collections.Generic;

namespace RobotSimulationController.GA.Crossovers
{
    abstract class Crossover
    {
        public abstract List<AbstractRobot> CreateNewPopulation(List<AbstractRobot> oldPopulation, Mutation mutation);
    }
}
