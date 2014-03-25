using RobotSimulationController.GA.Crossover;
using RobotSimulationController.GA.Fitness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotSimulationController.GA
{
    class EvolutionThread
    {
        public delegate void EvolutionStoppedHandler();
        public event EvolutionStoppedHandler EvolutionStopped;

        public delegate void GenerationEvaluatedHandler(String text);
        public event GenerationEvaluatedHandler GenerationFinished;


        Moda.Connection Connection;
        List<AbstractRobot> Population;
        FitnessFunction Fitness;
        CrossoverMechanism Crossover;

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
        
        public EvolutionThread withCrossover(CrossoverMechanism crossover)
        {
            Crossover = crossover;
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
                    Console.WriteLine("loaded individual ");
                    IndividThread = new Worker(robot, Connection);
                    Thread t = new Thread(IndividThread.DoWork);
                    t.Start();
                    Thread.Sleep(1000);
                    IndividThread.RequestStop();
                    
                    // Evaluate individual
                    robot.FitnessValue = IndividThread.getFitness(Fitness);
                    Console.WriteLine("evaluated individual " + robot.FitnessValue);
                });
                // posting generation statistics
                float avg = Population.Average(robot => robot.FitnessValue);
                float max = Population.Max(robot => robot.FitnessValue);
                float min = Population.Min(robot => robot.FitnessValue);
                String s = generationCounter + ") avg=" + avg + " max=" + max + " min=" + min;
                if (GenerationFinished != null)
                {
                    GenerationFinished(s);
                }
                
                if (_shouldStop) break;
                // creating new population
                Population = Crossover.createNewPopulation(Population);
                Console.WriteLine("Created new population " + Population.Count);

            }

            if (EvolutionStopped != null)
            {
                EvolutionStopped();
            }
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

    }
}
