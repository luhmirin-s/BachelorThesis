using RobotSimulationController.GA.Fitness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController
{
    class Worker
    {
        public AbstractRobot Robot
        {
            get;
            private set;
        }
        Moda.Connection Connection;

        private volatile bool _shouldStop;

        public Worker(AbstractRobot robot, Moda.Connection connection)
        {
            Robot = robot;
            Connection = connection;
        }

        public void DoWork()
        {
            Robot.InitDevices();
            Robot.PositionRobotAtStart();
            while (!_shouldStop)
            {
                Robot.ComputeStep();
                Connection.Sleep(100);
            }
            Robot.Stop();

            // TODO post some results here

        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

        public float getFitness(FitnessFunction function)
        {
            return function.Calculate(Robot, new float[] {});
        }

    }
}
