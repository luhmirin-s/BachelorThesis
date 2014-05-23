using RobotSimulationController.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.NN
{
    class NetworkFactory
    {
        
        private static Random Rand = new Random();

        public static AbstractNN CreateDefaultNetwork(float[] weights)
        {
            return CreateNetwork((NetworkType)Settings.Default.UsedNN, weights);
        }

        public static AbstractNN CreateNetwork(NetworkType type, float[] weights)
        {
            AbstractNN result;
            switch (type)
            {
                case NetworkType.OneLayerPerceptron:
                    result = new OneLayerPerceptron();
                    break;
                case NetworkType.TwoLayerPerceptron:
                    result = new TwoLayerPerceptron();
                    break;
                case NetworkType.ThreeLayerPerceptron:
                    result = new ThreeLayerPerceptron();
                    break;
                case NetworkType.ElmanNetwork:
                    result = new ElmanNetwork();
                    break;
                case NetworkType.HopfieldNetwork:
                    result = new HopfieldNetwork();
                    break;
                default:
                    result = null;
                    break;
            }

            // Making sure, that network recives correct amount of weight values.
            if (weights.Count() == 0)
            {
                result.Weights = GetRandomizedWeights(result.LinkCount);
            }
            else if (weights.Count() < result.LinkCount)
            {
                int diff = result.LinkCount - weights.Count();
                result.Weights = weights.Concat(GetRandomizedWeights(diff)).ToArray();
            }
            else if (weights.Count() > result.LinkCount)
            {
                result.Weights = weights.Take(result.LinkCount).ToArray();
            }
            else if (weights.Count() == result.LinkCount)
            {
                result.Weights = weights;
            }

            result.InitNetwork();

            return result;
        }


        public static float[] GetRandomizedWeights(int count)
        {
            float[] tmp = new float[count];
            // randomize weights
            for (int ii = 0; ii < count; ii++)
            {
                tmp[ii] = (float)(2 * Rand.NextDouble() - 1);
            }
            return tmp;
        }

    }
}
