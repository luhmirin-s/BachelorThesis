using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.NN
{
    class TwoLayerPerceptron : AbstractNN
    {
        /*
         * Simple network containing N neurons: 2 input(0,1), 2 output(N-1, N) and else in several hidden layers.
         * 2-6 - first layer, 7-11 - second layer
         * 
         * Each in input layer is connected to each in hidden layer.
         * Each in hidden layer is connected with each in output layer. 
         * Each hidden neuron is connected to each in next layer.
         * 2 hidden layers.
         * 2*5 + 5*5 + 5*2 = 5 * (2 + 2 + 5) = 5 * 9 = 45 connections in total.
         */
        public const int HIDDEN_NEURON_COUNT = 5;
        
        public TwoLayerPerceptron()
        {
            NeuronCount = 2 + HIDDEN_NEURON_COUNT * 2 + 2;
            LinkCount = HIDDEN_NEURON_COUNT * ( 4 + HIDDEN_NEURON_COUNT);
        }

        public override void InitNetwork()
        {
            // Creating neurons
            for (int ii = 0; ii < NeuronCount; ii++)
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
            // 1st hidden layer to 2nd
            for (int kk = 0; kk < HIDDEN_NEURON_COUNT; kk++)
            {
                for (int nn = 0; nn < HIDDEN_NEURON_COUNT; nn++)
                {
                    CreateSynapse(Neurons[2 + kk], Neurons[7 + nn], jj++);
                }
            }
            // 2rd hidden layer to output
            for (int kk = 0; kk < HIDDEN_NEURON_COUNT; kk++)
            {
                CreateSynapse(Neurons[7 + kk], Neurons[NeuronCount - 2], jj++);
            }
            for (int kk = 0; kk < HIDDEN_NEURON_COUNT; kk++)
            {
                CreateSynapse(Neurons[7 + kk], Neurons[NeuronCount - 1], jj++);
            }
        }

    }
}
