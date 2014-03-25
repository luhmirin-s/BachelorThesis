using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Crossover
{
    class CrossoverMechanism
    {
        const float PERCENT_OF_BEST = 0.4f;
        const float MAX_CHILD_COUNT = 10;

        Random rand = new Random();

        public List<AbstractRobot> createNewPopulation(List<AbstractRobot> oldPopulation)
        {
            SortPopulation(oldPopulation);
            oldPopulation = ChooseNewParents(oldPopulation);

            List<AbstractRobot> newPopulation = new List<AbstractRobot>();

            CreateNewPopulation(oldPopulation, newPopulation);

            return newPopulation;
        }

        private void CreateNewPopulation(List<AbstractRobot> oldPopulation, List<AbstractRobot> newPopulation)
        {
            Console.WriteLine("Starting crossover " + oldPopulation.Count);
            for (int ii = 0; ii < oldPopulation.Count; ii++)
            {
                if (newPopulation.Count >= MAX_CHILD_COUNT) break;

                for (int jj = 1; jj < oldPopulation.Count; jj++)
                {
                    if (newPopulation.Count >= MAX_CHILD_COUNT) break;
                    Console.WriteLine("mating " + ii + " with " + jj);
                    AbstractRobot child = (AbstractRobot)oldPopulation[0].Clone();
                    child.setGenome(makeCrossover(oldPopulation[ii], oldPopulation[jj]));
                    newPopulation.Add(child);
                }
            }
        }

        private Genome makeCrossover(AbstractRobot robot1, AbstractRobot robot2)
        {
            
            
            float[] genome1 = robot1.getGenome().getWeights();
            float[] genome2 = robot2.getGenome().getWeights();

            Console.WriteLine("from");
            Console.WriteLine(robot1.getGenome().ToString());
            Console.WriteLine(robot2.getGenome().ToString());

            float[] newGenome = new float[genome1.Length];

            for (int ii = 0; ii < genome1.Length; ii++)
            {
                newGenome[ii] = ((rand.NextDouble() > 0.5) ? genome1[ii] : genome2[ii]);
            }
            Genome result = new Genome(newGenome);

            Console.WriteLine("New genome created");
            Console.WriteLine(result.ToString());
            
            Console.WriteLine("##################");

            return result;
        }

        private static List<AbstractRobot> ChooseNewParents(List<AbstractRobot> oldPopulation)
        {
            int newParentsCount = (int)(oldPopulation.Count * PERCENT_OF_BEST);
            oldPopulation = oldPopulation.GetRange(0, newParentsCount);
            oldPopulation.ForEach(robot => Console.WriteLine("fitness " + robot.FitnessValue));

            return oldPopulation;
        }

        private static void SortPopulation(List<AbstractRobot> oldPopulation)
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
