using Moda;
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
        MainForm MainForm;

        AbstractRobot Robot;

        Worker robotWorker;

        public ProcessController(MainForm form)
        {
            MainForm = form;
        }

        public void setRobot(RobotType type, RobotPHX phx)
        {
            switch (type)
            {
                case RobotType.SIMPLE_NN:
                    Robot = new SimpleNNRobot(phx);
                    break;
                default:
                    Robot = new StupidRobot(phx);
                    break;
            }

            SubscribeToCustomHandlers();
            Robot.InitDevices();
        }

        public bool IsRobotValid()
        {
            return Robot.IsValid();
        }
        
        public void start(Connection connection)
        {
            robotWorker = new Worker(Robot, connection);

            Thread t = new Thread(robotWorker.DoWork);
            t.Start();
        }

        public void stop()
        {
            if (robotWorker != null)
            {
                robotWorker.RequestStop();
            }
        }

        // Form interactions
        private void SubscribeToCustomHandlers()
        {
            Robot.MotorsChecked += new AbstractRobot.MotorsCheckedHandler(PostMotorCheckResult);
            Robot.SensorsChecked += new AbstractRobot.SensorsCheckedHandler(PostSensorCheckResults);
            Robot.PostSensorResults += new AbstractRobot.SensorResultHandler(PostSensorResults);
            Robot.PostMotorSpeed += new AbstractRobot.MotorSpeedHandler(PostMotorSpeed);
            Robot.PostCurrentPosition += new AbstractRobot.CurrentPositionHandler(PostCurrentPosition);
        }

        private void PostMotorCheckResult(bool checkResult)
        {
            MainForm.SetMotorCheckResults(checkResult);
            
        }

        private void PostSensorCheckResults(bool checkResult)
        {
            MainForm.SetSensorCheckResults(checkResult);
        }

        private void PostSensorResults(float ld, float rd)
        {
            MainForm.SetSensorResults(ld, rd);
        }

        private void PostMotorSpeed(float lm, float rm)
        {
            MainForm.SetMotorSpeed(lm, rm);
        }

        private void PostCurrentPosition(float positionX, float positionZ)
        {
            MainForm.SetCurrentPosition(positionX, positionZ);
        }


    }
}
