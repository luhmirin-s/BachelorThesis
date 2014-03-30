using RobotSimulationController.GA.Crossover;
using RobotSimulationController.GA.Fitness;
using RobotSimulationController.GA.Mutation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotSimulationController.GA
{
    class EvolutionThread
    {

        public const int MAX_GENERATIONS = 100;
        public const int GENERATION_LIFE_TIME = 1000; //ms

        public delegate void EvolutionStoppedHandler();
        public event EvolutionStoppedHandler EvolutionStopped;

        public delegate void GenerationEvaluatedHandler(String text);
        public event GenerationEvaluatedHandler GenerationFinished;


        Moda.Connection Connection;
        List<AbstractRobot> Population;
        FitnessFunction Fitness;
        ICrossoverMechanism Crossover;
        IMutation Mutation;

        int generationCounter = 0;

        private bool _shouldStop;

        Worker IndividThread;

        public static EvolutionThread newInstance()
        {
            return new EvolutionThread();
        }

        private EvolutionThread()
        {
            generationCounter = 0;
        }

        // Parametr setters. ALL MANDATORY 
        public EvolutionThread withPopulation(List<AbstractRobot> population)
        {
            Population = population;
            return this;
        }

        public EvolutionThread withConnection(Moda.Connection connection)
        {
            Connection = connection;
            return this;
        }

        public EvolutionThread withFitnessFunction(FitnessFunction function)
        {
            Fitness = function;
            return this;
        }

        public EvolutionThread withCrossover(ICrossoverMechanism crossover)
        {
            Crossover = crossover;
            return this;
        }

        public EvolutionThread withMutation(IMutation mutation)
        {
            Mutation = mutation;
            return this;
        }

        // Actual work

        public void DoWork()
        {
            while (!_shouldStop)
            {
                generationCounter++;
                Population.ForEach( robot =>
                {
                    // Execute individual
                    IndividThread = new Worker(robot, Connection);
                    Thread t = new Thread(IndividThread.DoWork);
                    t.Start();
                    Thread.Sleep(GENERATION_LIFE_TIME);
                    IndividThread.RequestStop();
                    
                    // Evaluate individual
                    robot.FitnessValue = IndividThread.getFitness(Fitness);
                });
                // posting generation statistics
                float avg = Population.Average(robot => robot.FitnessValue);
                float max = Population.Max(robot => robot.FitnessValue);
                float min = Population.Min(robot => robot.FitnessValue);
                postGenerationResults(avg, max, min);
                
                if (_shouldStop || generationCounter >= MAX_GENERATIONS) break;
                // creating new population
                Population = Crossover.CreateNewPopulation(Population, Mutation);

            }

            if (EvolutionStopped != null)
            {
                EvolutionStopped();
            }
        }

        private void postGenerationResults(float avg, float max, float min)
        {
            String s = generationCounter + ") avg=" + avg + " max=" + max + " min=" + min;
            if (GenerationFinished != null)
            {
                GenerationFinished(s);
            }
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

    }
}
