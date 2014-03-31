using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.NN
{
    class SimpleNN : AbstractNN
    {
        /*
         * Simple network containing N neurons: 2 input(0,1), 2 output(N-1, N) and else in hidden layer.
         * Each in input layer is connected to each in hidden layer.
         * Each in hidden layer is connected with each in output layer. 
         * 12 connections in total.
         */
        public const int HIDDEN_NEURON_COUNT = 5;
        public const int NEURON_COUNT = 2 + HIDDEN_NEURON_COUNT + 2;

        public const int LINK_COUNT = 2 * HIDDEN_NEURON_COUNT * 2;

        public SimpleNN()
        {
            Weights = getRandomizedWeights();
            InitNetwork();
        }

        public SimpleNN(float[] weights)
        {
            Weights = weights;
            InitNetwork();
        }

        public static float[] getRandomizedWeights()
        {
            float[] tmp = new float[LINK_COUNT]; 
            // randomize weights
            for (int ii = 0; ii < LINK_COUNT; ii++)
            {
                tmp[ii] = (float)(Rand.NextDouble());
            }
            return tmp;
        }

        protected override void InitNetwork()
        {
            // Creating neurons
            for (int ii = 0; ii < NEURON_COUNT; ii++)
            {
                Neurons.Add(new Neuron(ii));
            }
            // Adding link btween neurons
            int jj = 0;
            // input to hidden layer
            for (int kk = 0; kk < HIDDEN_NEURON_COUNT; kk++)
            {
                CreateSynapse(Neurons[0], Neurons[2 + kk], jj++);
            }
            for (int kk = 0; kk < HIDDEN_NEURON_COUNT; kk++)
            {
                CreateSynapse(Neurons[1], Neurons[2 + kk], jj++);
            }
            // hidden layer to input
            for (int kk = 0; kk < HIDDEN_NEURON_COUNT; kk++)
            {
                CreateSynapse(Neurons[2 + kk], Neurons[NEURON_COUNT - 2], jj++);
            }
            for (int kk = 0; kk < HIDDEN_NEURON_COUNT; kk++)
            {
                CreateSynapse(Neurons[2 + kk], Neurons[NEURON_COUNT - 1], jj++);
            }
        }

    }
}
