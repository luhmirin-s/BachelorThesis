using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Fitness
{
    class EvaluationStatistics
    {

        public List<float> MotorLeftValues
        {
            get;
            private set;
        }
        public List<float> MotorRightValues
        {
            get;
            private set;
        }
        public List<float> SensorLeftValues
        {
            get;
            private set;
        }
        public List<float> SensorRightValues
        {
            get;
            private set;
        }
        public List<float> Position
        {
            get;
            private set;
        }

        public EvaluationStatistics()
        {
            MotorLeftValues = new List<float>();
            MotorRightValues = new List<float>();
            SensorLeftValues = new List<float>();
            SensorRightValues = new List<float>();
            Position = new List<float>();
        }

        public void AddMotorSpeed(float left, float right)
        {
            MotorLeftValues.Add(left);
            MotorRightValues.Add(right);
        }

        public void AddSensorReadings(float left, float right)
        {
            SensorLeftValues.Add(left);
            SensorRightValues.Add(right);
        }

        public void AddPosition(float x)
        {
            Position.Add(x);
        }

        public float GetAverageLeftSpeed()
        {
            return MotorLeftValues.Average();
        }

        public float GetAverageRightSpeed()
        {
            return MotorRightValues.Average();
        }

        public float GetAverageMotorSpeedOnStep(int i)
        {
            return (MotorLeftValues[i] + MotorRightValues[i]) / 2;
        }

        public int Size()
        {
            return Position.Count;
        }
    }
}
