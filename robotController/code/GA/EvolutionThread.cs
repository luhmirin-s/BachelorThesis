using RobotSimulationController.DB;
using RobotSimulationController.GA.Crossovers;
using RobotSimulationController.GA.Fitness;
using RobotSimulationController.GA.Mutations;
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

        public delegate void EvolutionStoppedDelegate();
        public event EvolutionStoppedDelegate EvolutionStoppedEvent;

        public delegate void GenerationEvaluatedDelegate(String text);
        public event GenerationEvaluatedDelegate GenerationFinishedEvent;


        Moda.Connection Connection;
        List<AbstractRobot> Population;
        FitnessFunction Fitness;
        Crossover Crossover;
        Mutation Mutation;

        int GenerationCounter = 0;
        DateTime Timestamp;

        private bool _shouldStop;

        Worker IndividThread;

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
        public EvolutionThread WithPopulation(List<AbstractRobot> population)
        {
            Population = population;
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
                Population.ForEach(robot =>
                {
                    // Execute individual
                    IndividThread = new Worker(robot, Connection);
                    Thread t = new Thread(IndividThread.DoWork);
                    t.Start();
                    Thread.Sleep(GENERATION_LIFE_TIME);
                    IndividThread.RequestStop();
                    // Evaluate individual
                    robot.FitnessValue = IndividThread.GetFitness(Fitness);


                    //IndividModel model = new IndividModel();
                    //model.Fitness = robot.FitnessValue;
                    //model.Generation = generationCounter;
                    //model.Weights = robot.getGenome().getWeights();
                    //model.ExperimentTimestamp = Timestamp;

                    //db.Individuals.Add(model);
                    //db.SaveChanges();

                });
                // posting generation statistics
                float avg = Population.Average(robot => robot.FitnessValue);
                float max = Population.Max(robot => robot.FitnessValue);
                float min = Population.Min(robot => robot.FitnessValue);
                postGenerationResults(avg, max, min);

                if (_shouldStop || GenerationCounter >= MAX_GENERATIONS) break;
                // creating new population
                Population = Crossover.CreateNewPopulation(Population, Mutation);

            }

            //var query = from b in db.Individuals
            //                            orderby b.Generation
            //                           select b;
            //  Console.WriteLine("All items in the database:");
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item.Generation + " generation " + item.Fitness + " fitness");
            //  Console.WriteLine("weights "  + item.Weights.ToString());
            //  Console.WriteLine("timestamp " + item.ExperimentTimestamp.ToLongTimeString());
            //}


            if (EvolutionStoppedEvent != null)
            {
                EvolutionStoppedEvent();
            }
        }

        private void postGenerationResults(float avg, float max, float min)
        {
            String s = GenerationCounter + ") avg=" + avg + " max=" + max + " min=" + min;
            if (GenerationFinishedEvent != null)
            {
                GenerationFinishedEvent(s);
            }
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

    }
}
