using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.NN
{
    class Neuron
    {
        // For debug purposes to identify neurons
        public int Index
        {
            get;
            set;
        }

        public float Value
        {
            get;
            set;
        }

        public float Bias = -1;

        public float BiasWeight
        {
            get;
            set;
        }

        public IActivationFunction ActivationFunction
        {
            get;
            set;
        }

        private List<Synapse> Inputs;

        public Neuron(int index, float biasWeight)
        {
            Index = index;
            BiasWeight = biasWeight;
            Inputs = new List<Synapse>();

            // Default activation function shall be sigmoid
            ActivationFunction = new Sigmoid();
        }

        public Neuron(int index) : this(index, 0) {}
        
        public void AddSynapse(Neuron from, float weight)
        {
            Inputs.Add(new Synapse(from, weight));
        }

        public void Compute()
        {
            // If there are inputs, its not input neuron
            if (Inputs.Any())
            {
                Value = Inputs.Sum(synapse => synapse.From.Value * synapse.Weight);
            }

            Value += Bias * BiasWeight;
            Value = ActivationFunction.Compute(Value);
            Console.WriteLine(Index + ". neuron value is " + Value);
        }

    }
}
