using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.NN
{
    abstract class AbstractNN
    {

        protected List<Neuron> Neurons = new List<Neuron>();

        public float[] Weights { get; set; }

        public int NeuronCount { get; protected set; }
        public int LinkCount { get; protected set; }

        public AbstractNN() {}
        
        public abstract void InitNetwork();

        protected void CreateSynapse(Neuron from, Neuron to, int indexWeight)
        {
            to.AddSynapse(from, Weights[indexWeight]);
        }

        public float[] SetInputValuesAndCompute(float[] values)
        {
            Neurons[0].Value = values[0];
            Neurons[1].Value = values[1];
            return ComputeResult();
        }

        private float[] ComputeResult()
        {
            Neurons.ForEach(neuron => neuron.Compute());
            return new float[] { Neurons[Neurons.Count - 2].Value, Neurons[Neurons.Count - 1].Value };
        }

        public void SetActivationFunction(ActivationFunction function)
        {
            Neurons.ForEach(neuron => neuron.ActivationFunction = function);
        }

    }
}
