using RobotSimulationController.DB;
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
        DateTime Timestamp;

        private bool _shouldStop;

        Worker IndividThread;

        public static EvolutionThread newInstance()
        {
            return new EvolutionThread();
        }

        private EvolutionThread()
        {
            generationCounter = 0;
            Timestamp = System.DateTime.Now;
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
            ExperimentContext db = new ExperimentContext();
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
                
                if (_shouldStop || generationCounter >= MAX_GENERATIONS) break;
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
