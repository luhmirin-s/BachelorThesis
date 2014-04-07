using Moda;
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

        private EvaluationStatistics Statistics;

        private Connection Connection;

        private volatile bool _shouldStop;

        public Worker(AbstractRobot robot, Moda.Connection connection)
        {
            Robot = robot;
            Connection = connection;
            Statistics = new EvaluationStatistics();
        }

        public void DoWork()
        {
            Robot.InitDevices();
            if (Robot.IsValid())
            {
                Robot.PositionRobotAtStart();
                Robot.PostMotorSpeedEvent +=
                    new AbstractRobot.MotorSpeedDelegate(MotorSpeedsObtained);
                Robot.PostSensorResultsEvent +=
                    new AbstractRobot.SensorResultDelegate(SensorResultsObtained);
                Robot.PostCurrentPositionEvent +=
                    new AbstractRobot.CurrentPositionDelegate(CurrentPositionObtained);
            }
            else
            {
                throw new Exception();
            }

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

        public float GetFitness(FitnessFunction function)
        {
            return function.Calculate(Statistics);
        }

        private void MotorSpeedsObtained(float lm, float rm)
        {
            Statistics.AddMotorSpeed(lm, rm);
        }

        private void CurrentPositionObtained(float positionX, float positionZ)
        {
            Statistics.AddPosition(positionX);
        }

        private void SensorResultsObtained(float ld, float rd)
        {
            Statistics.AddSensorReadings(ld, rd);
        }

    }
}
