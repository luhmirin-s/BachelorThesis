using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA
{
    class Genome
    {

        public List<Allel> Alleles
        {
            get;
            private set;
        }

        public Genome(float[] weights)
        {
            Alleles = new List<Allel>();
            foreach (float f in weights)
            {
                Alleles.Add(new Allel(f));
            }
        }
        
        public Genome(List<Allel> alleles)
        {
            Alleles = alleles.ToList();
        }

        public float GetWeight(int index)
        {
            return Alleles[index].getValue();
        }

        public float[] GetWeights()
        {
            return Alleles.Select(a => a.getValue()).ToArray();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            GetWeights().ToList().ForEach(f => sb.Append(f).Append(";"));
            return sb.ToString();
        }
    }
}
