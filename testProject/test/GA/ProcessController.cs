using Moda;
using RobotSimulationController.GA;
using RobotSimulationController.GA.Crossover;
using RobotSimulationController.GA.Fitness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotSimulationController
{

    enum RobotType
    {
        STUPID,
        SIMPLE_NN
    }

    class ProcessController
    {
        const int POPULATION_SIZE = 10;

        MainForm MainForm;

        List<AbstractRobot> Population;
        FitnessFunction FitnessFunction = new FinalPosition();
        CrossoverMechanism Crossover = new CrossoverMechanism();

        EvolutionThread Evolution;

        public ProcessController(MainForm form)
        {
            MainForm = form;
        }

        public void SetRobotType(RobotType type, RobotPHX phx)
        {
            Population = new List<AbstractRobot>();
            
            switch (type)
            {
                case RobotType.SIMPLE_NN:
                    for (int ii = 0; ii < POPULATION_SIZE; ii++)
                    {
                        Population.Add(new SimpleNNRobot(phx));
                    }
                    break;
                default:
                    for (int ii = 0; ii < POPULATION_SIZE; ii++)
                    {
                        Population.Add(new StupidRobot(phx));
                    }
                    break;
            }
        }
                
        public void start(Connection connection)
        {
            Console.WriteLine("### started evolution ###");

            Evolution = EvolutionThread.newInstance()
                .withConnection(connection)
                .withPopulation(Population)
                .withFitnessFunction(FitnessFunction)
                .withCrossover(Crossover);

            Evolution.EvolutionStopped += new EvolutionThread.EvolutionStoppedHandler(EvolutionStopped);
            Evolution.GenerationFinished += new EvolutionThread.GenerationEvaluatedHandler(GenerationFinished);

            Thread t = new Thread(Evolution.DoWork);
            t.Start();
        }

        public void stop()
        {
            if (Evolution != null)
            {
                Evolution.RequestStop();
            }
        }

        // Form interactions
        private void EvolutionStopped()
        {
            MainForm.EvolutionStop();
        }

        private void GenerationFinished(String s)
        {
            MainForm.AddGenerationInfo(s);
        }
    }
}
