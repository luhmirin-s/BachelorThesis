using RobotSimulationController.GA.Mutation;
using System;
using System.Collections.Generic;

namespace RobotSimulationController.GA.Crossover
{
    interface ICrossoverMechanism
    {
        List<AbstractRobot> CreateNewPopulation(List<AbstractRobot> oldPopulation, IMutation mutation);
    }
}
