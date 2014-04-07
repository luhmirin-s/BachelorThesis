using RobotSimulationController.GA.Mutations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Crossovers
{
    class UniformWithElite : Crossover
    {

        public const int ELITE_SIZE = 2;
        public const int MAX_CHILD_COUNT = ProcessController.POPULATION_SIZE;

        protected Random Random = new Random();
        private Mutation Mutation;

        public override List<AbstractRobot> CreateNewPopulation(List<AbstractRobot> oldPopulation, Mutation mutation)
        {
            Mutation = mutation;

            SortPopulation(oldPopulation);
            oldPopulation = ChooseBestIndividual(oldPopulation);

            List<AbstractRobot> offsprings = GenerateOffsprings(oldPopulation);

            addElite(oldPopulation, offsprings);

            return offsprings;
        }

        private void addElite(List<AbstractRobot> oldPopulation, List<AbstractRobot> newPopulation)
        {
            newPopulation.AddRange(oldPopulation.GetRange(0, ELITE_SIZE));
        }

        private List<AbstractRobot> GenerateOffsprings(List<AbstractRobot> oldPopulation)
        {
            List<AbstractRobot> newPopulation = new List<AbstractRobot>();

            AbstractRobot prototype = oldPopulation[0];

            Console.WriteLine("Starting crossover " + oldPopulation.Count);
            for (int ii = 0; ii < oldPopulation.Count; ii++)
            {
                if (newPopulation.Count >= MAX_CHILD_COUNT) break;

                for (int jj = 1; jj < oldPopulation.Count; jj++)
                {
                    if (newPopulation.Count >= MAX_CHILD_COUNT) break;
                    AbstractRobot child = prototype.Clone();
                    child.Genotype = MakeCrossover(oldPopulation[ii], oldPopulation[jj]);
                    Mutation.Mutate(child);
                    newPopulation.Add(child);
                }
            }


            return newPopulation;
        }

        private Genome MakeCrossover(AbstractRobot robot1, AbstractRobot robot2)
        {
           
            float[] genome1 = robot1.Genotype.GetWeights();
            float[] genome2 = robot2.Genotype.GetWeights();

            Console.WriteLine("from");
            Console.WriteLine(robot1.Genotype.ToString());
            Console.WriteLine(robot2.Genotype.ToString());

            float[] newGenome = new float[genome1.Length];

            for (int ii = 0; ii < genome1.Length; ii++)
            {
                newGenome[ii] = ((Random.NextDouble() > 0.5) ? genome1[ii] : genome2[ii]);
            }
            Genome result = new Genome(newGenome);

            Console.WriteLine("New genome created");
            Console.WriteLine(result.ToString());
            
            Console.WriteLine("##################");

            return result;
        }

        private List<AbstractRobot> ChooseBestIndividual(List<AbstractRobot> oldPopulation)
        {
            
            int newParentsCount = 2;
            while (newParentsCount * (newParentsCount - 1) < oldPopulation.Count)
            {
                newParentsCount++;
            }

            oldPopulation = oldPopulation.GetRange(0, newParentsCount);
            oldPopulation.ForEach(robot => Console.WriteLine("fitness " + robot.FitnessValue));

            return oldPopulation;
        }

        private void SortPopulation(List<AbstractRobot> oldPopulation)
        {
            oldPopulation.Sort(delegate(AbstractRobot x, AbstractRobot y)
            {
                if (x.FitnessValue == y.FitnessValue) return 0;
                else if (x.FitnessValue < y.FitnessValue) return 1;
                else return -1;
            });
        }


    }
}
