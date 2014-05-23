using Moda;
using RobotSimulationController.GA.Crossovers;
using RobotSimulationController.GA.Fitness;
using RobotSimulationController.GA.Mutations;
using RobotSimulationController.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotSimulationController.GA
{
    class Population
    {
        private int GENERATION_LIFE_TIME = Settings.Default.GenerationLifeTime; //ms

        public List<AbstractRobot> Generation
        {
            get;
            private set;
        }


        private Worker IndividThread;


        public Population(List<AbstractRobot> generation)
        {
            Generation = generation;
            
        }

        public float[] evaluateGeneration(Connection connection, FitnessFunction fitness)
        {

            Generation.ForEach(robot =>
            {
                // Execute individual
                IndividThread = new Worker(robot, connection);
                Thread t = new Thread(IndividThread.DoWork);
                t.Start();
                Thread.Sleep(GENERATION_LIFE_TIME);
                IndividThread.RequestStop();
                // Evaluate individual
              //  Console.WriteLine(robot.Genotype.ToString());
                robot.FitnessValue = IndividThread.GetFitness(fitness);

            });

            return Generation.Select(robot => robot.FitnessValue).ToArray();
        }

        public void createNewGeneration(Crossover crossover, Mutation mutation)
        {
            Generation = crossover.CreateNewPopulation(Generation, mutation);
        }

    }
}
