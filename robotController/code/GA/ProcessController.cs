using Moda;
using RobotSimulationController.GA;
using RobotSimulationController.GA.Crossovers;
using RobotSimulationController.GA.Fitness;
using RobotSimulationController.GA.Mutations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotSimulationController
{

    enum RobotType
    {
        SIMPLE_NN
    }

    class ProcessController
    {

        public const int POPULATION_SIZE = 20;

        MainForm MainForm;

        List<AbstractRobot> Population;

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
                        Population.Add(new RobotNN(phx));
                    }
                    break;
                default:
                    break;
            }
        }

        public void Start(Connection connection)
        {
            Console.WriteLine("### started evolution ###");

            Evolution = EvolutionThread.NewInstance()
                .WithConnection(connection)
                .WithPopulation(Population);


            Evolution.EvolutionStoppedEvent += new EvolutionThread.EvolutionStoppedDelegate(EvolutionStopped);
            Evolution.GenerationFinishedEvent += new EvolutionThread.GenerationEvaluatedDelegate(GenerationFinished);

            Thread t = new Thread(Evolution.DoWork);
            t.Start();
        }

        public void Stop()
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
