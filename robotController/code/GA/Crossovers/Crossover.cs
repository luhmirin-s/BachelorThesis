
using RobotSimulationController.GA.Mutations;
using RobotSimulationController.Properties;
using System;
using System.Collections.Generic;

namespace RobotSimulationController.GA.Crossovers
{
    abstract class Crossover
    {

        protected int ELITE_SIZE = Settings.Default.EliteSize;
        protected int MAX_CHILD_COUNT = Settings.Default.PopulationSize;

        protected Random Random = new Random();
        protected Mutation Mutation;

        public abstract List<AbstractRobot> CreateNewPopulation(List<AbstractRobot> oldPopulation, Mutation mutation);
    }
}
