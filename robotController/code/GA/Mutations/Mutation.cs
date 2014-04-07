using RobotSimulationController.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Mutations
{
    abstract class Mutation
    {

        protected int MAX_MUTATED_GENES = Settings.Default.MaxMutatedGenes;
        protected double MUTATION_PROBABILITY = Settings.Default.MutationProbability;

        protected Random Random = new Random();

        public abstract void Mutate(AbstractRobot robot);

    }
}
