using Moda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSimulationController
{
    class StupidRobot : AbstractRobot
    {

        public StupidRobot(RobotPHX robot)
        {
            Robot = robot;
        }

        public override void ComputeStep()
        {
            const float LARGE = 0.75f;
            const float MEDIUM = 0.5f;

            const int MAXSPEED = 720;
            const int MEDIUMSPEED = 360;

            uint PerformWait = 0;

            float lm, rm;

            float ld = LeftSensor.GetMeasure();
            float rd = RightSensor.GetMeasure();

            // Here we send sensor results to form.
            PostSensorReadings(ld, rd);

            if ((ld >= LARGE) && (rd >= LARGE))
            {
                lm = MAXSPEED;
                rm = MAXSPEED;
            }
            else
            {
                if ((ld >= MEDIUM) && (rd >= MEDIUM))
                {
                    PerformWait = 200;
                    if (ld > rd)
                    {
                        lm = MEDIUMSPEED;
                        rm = MAXSPEED;
                    }
                    else
                    {
                        rm = MEDIUMSPEED;
                        lm = MAXSPEED;
                    }
                }
                else
                {
                    if (ld > rd)
                    {
                        lm = -MEDIUMSPEED;
                        rm = MEDIUMSPEED;
                    }
                    else
                    {
                        lm = MEDIUMSPEED;
                        rm = -MEDIUMSPEED;
                    }
                    PerformWait = 250;
                }
            }

            // Here we send motor speeds to form.
            SetNewMotorSpeeds(new float[] { lm / MAXSPEED, rm / MAXSPEED });
            PostPosition();

            if (PerformWait != 0)
            {
                Robot.GetConnection().Sleep(PerformWait);
            }

        }
    }
}