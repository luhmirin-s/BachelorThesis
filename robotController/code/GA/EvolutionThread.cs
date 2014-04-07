using Moda;
using RobotSimulationController.DB;
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
    class EvolutionThread
    {

        private int MAX_GENERATIONS = Settings.Default.GenerationCount;

        public delegate void EvolutionStoppedDelegate();
        public event EvolutionStoppedDelegate EvolutionStoppedEvent;

        private Connection Connection;
        private Population Population;
        private FitnessFunction Fitness;
        private Crossover Crossover;
        private Mutation Mutation;

        private int GenerationCounter = 0;
        private DateTime Timestamp;

        private bool _shouldStop;

        public static EvolutionThread NewInstance()
        {
            return new EvolutionThread();
        }

        private EvolutionThread()
        {
            GenerationCounter = 0;
            Timestamp = System.DateTime.Now;
            Fitness = FitnessFunctionFactory.CreateDefaultFunction();
            Crossover = CrossoverFactory.CreateDefaultCrossover();
            Mutation = MutationFactory.CreateDefaultMutation();

        }

        // Parametr setters. ALL MANDATORY 
        public EvolutionThread WithPopulation(List<AbstractRobot> startingGeneration)
        {
            Population = new Population(startingGeneration);
            return this;
        }

        public EvolutionThread WithConnection(Moda.Connection connection)
        {
            Connection = connection;
            return this;
        }

        // Actual work

        public void DoWork()
        {
            ExperimentContext db = new ExperimentContext();
            while (!_shouldStop)
            {
                GenerationCounter++;
                float[] results = Population.evaluateGeneration(Connection, Fitness);
                // posting generation statistics
                float avg = results.Average();
                float max = results.Max();
                float min = results.Min();
                postGenerationResults(avg, max, min);

                if (_shouldStop || GenerationCounter >= MAX_GENERATIONS) break;
                // creating new population
                Population.createNewGeneration(Crossover, Mutation);

            }

            if (EvolutionStoppedEvent != null)
            {
                EvolutionStoppedEvent();
            }
        }

        private void postGenerationResults(float avg, float max, float min)
        {
            String s = GenerationCounter + ") avg=" + avg + " max=" + max + " min=" + min;
            Console.WriteLine(s);
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

    }
}
