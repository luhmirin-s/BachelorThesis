using Moda;
using RobotSimulationController.GA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSimulationController
{
    abstract class AbstractRobot
    {
        // Used to post robots device status
        public delegate void MotorsCheckedDelegate(bool checkResult);
        public event MotorsCheckedDelegate MotorsCheckedEvent;
        public delegate void SensorsCheckedDelegate(bool checkResult);
        public event SensorsCheckedDelegate SensorsCheckedEvent;

        // Used to post current sensor readings
        public delegate void SensorResultDelegate(float ld, float rd);
        public event SensorResultDelegate PostSensorResultsEvent;

        // Used to post current robot position
        public delegate void CurrentPositionDelegate(float positionX, float positionZ);
        public event CurrentPositionDelegate PostCurrentPositionEvent;

        // Used to post new motor speeds
        public delegate void MotorSpeedDelegate(float lm, float rm);
        public event MotorSpeedDelegate PostMotorSpeedEvent;

        // Robot instance
        protected RobotPHX Robot;

        // Robots distance sensors
        protected DeviceDistance LeftSensor;
        protected DeviceDistance RightSensor;

        // Robots motors
        protected DeviceMotor LeftMotor;
        protected DeviceMotor RightMotor;

        // Robot base geometry to retrieve and set position
        protected Geom RobotGeometry;

        // Some fitness function evaluation result for this robot
        public float FitnessValue { get; set; }

        public virtual Genome Genotype { get; set; }

        protected AbstractRobot()
        {
            Robot = null;
        }

        protected AbstractRobot(RobotPHX robot)
        {
            Robot = robot;
        }

        /*
         * Initializes robots devices - motors and sensors. 
         * Initialization results are posted with corresponding events.
         */
        public void InitDevices()
        {
            LeftMotor = Robot.QueryDeviceMotor(Constants.LEFT_MOTOR);
            RightMotor = Robot.QueryDeviceMotor(Constants.RIGHT_MOTOR);
            if (MotorsCheckedEvent != null)
            {
                MotorsCheckedEvent(LeftMotor != null && RightMotor != null);
            }

            LeftSensor = Robot.QueryDeviceDistance(Constants.RIGHT_SENSOR);
            RightSensor = Robot.QueryDeviceDistance(Constants.LEFT_SENSOR);
            if (SensorsCheckedEvent != null)
            {
                SensorsCheckedEvent(LeftSensor != null && RightSensor != null);
            }

            RobotGeometry = Robot.QueryGeom(Constants.BASE);
        }

        /*
         * Check if all devices are in place.
         */
        public bool IsValid()
        {
            return LeftMotor != null && RightMotor != null && LeftSensor != null && RightSensor != null && RobotGeometry != null;
        }

        /*
         * Sets starting position for robot.
         * Currently starting position is some random location in 0.5m at the beginning of coordinate plane.
         * Starting direction is directly to finish line. (180°)
         */
        public void PositionRobotAtStart()
        {
            // setting position in starting lane
            Vector3 position = RobotGeometry.GetPosition();
            position.Y = 0.20f;
            position.X = 0.25f;
            position.Z = (float)((new Random().NextDouble() * 2.5) + 0.25);

            // setting correct direction 
            Matrix matrix = RobotGeometry.GetMatrixAbsolute();
            matrix.SetMatrixRotationY((float)Math.PI);

            RobotGeometry.SetMatrixAbsolute(matrix, false);
            RobotGeometry.SetPosition(position);
        }

        /*
         * Wrapper method for position posting.
         */
        protected void PostPosition()
        {
            Vector3 position = RobotGeometry.GetPosition();
            if (PostCurrentPositionEvent != null)
            {
                PostCurrentPositionEvent(position.X, position.Z);
            }
        }

        /*
         * Wrapper method for sensor reading posting.
         */
        protected void PostSensorReadings(float ld, float rd)
        {
            if (PostSensorResultsEvent != null)
            {
                PostSensorResultsEvent(ld, rd);
            }
        }

        /*
         * This should be called to change motor speed.
         * It also posts new motor speeds.
         */
        protected void SetNewMotorSpeeds(float[] speeds)
        {
            const float MAX_SPEED = 360f; // 2 rotations per second
            float lm = speeds[0] * MAX_SPEED;
            float rm = speeds[1] * MAX_SPEED;

            if (PostMotorSpeedEvent != null)
            {
                PostMotorSpeedEvent(lm, rm);
            }
            LeftMotor.SetVelocityDPS(lm);
            RightMotor.SetVelocityDPS(rm);
        }


        /**
         * Used to compute new motor speed based on sensor readings.
         * Should call postMotorSpeed(lm, rm) when all computation is over.
         */
        public abstract void ComputeStep();

        /*
         * Stops the robot.
         */
        public void Stop()
        {
            SetNewMotorSpeeds(new float[] {0, 0});
        }


        protected float[] GetSensorReadings()
        {
            float ld = LeftSensor.GetMeasure();
            float rd = RightSensor.GetMeasure();

            // Here we send sensor results to form.
            PostSensorReadings(ld, rd);

            return new float[] { ld, rd };
        }

        public virtual String GetWeightsAsString()
        {
            return "N/A";
        }

        public Vector3 GetPosition()
        {
            return RobotGeometry.GetPosition();
        }

        public abstract AbstractRobot Clone();
    }
}