using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController
{
    class Constants
    {
        public const String DEFAULT_IP = "127.0.0.1";

        public const String ROBOT_PHX = "/phx0";

        public const String LEFT_MOTOR = "hinge_left/a1/mymotor";
        public const String RIGHT_MOTOR = "hinge_right/a1/mymotor";

        public const String LEFT_SENSOR = "zone_left/device0";
        public const String RIGHT_SENSOR = "zone_right/device0";

        public const String BASE = "robot_base";

        public const float DISTANCE_TO_FINISH = 10f;
    
    }
}
