using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController
{
    class Worker
    {
        AbstractRobot Robot;
        Moda.Connection Connection;

        private volatile bool _shouldStop;

        public Worker(AbstractRobot robot, Moda.Connection connection)
        {
            Robot = robot;
            Connection = connection;
        }

        public void DoWork()
        {
            Robot.PositionRobotAtStart();
            while (!_shouldStop)
            {
                Robot.ComputeStep();
                Connection.Sleep(100);
            }
            Robot.Stop();

        }
        public void RequestStop()
        {
            _shouldStop = true;
        }

    }
}
