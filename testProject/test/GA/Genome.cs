using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA
{
    class Genome
    {

        private List<Allel> Alleles;

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

        public float getWeight(int index)
        {
            return Alleles[index].getValue();
        }

        public float[] getWeights()
        {
            return Alleles.Select(a => a.getValue()).ToArray();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            getWeights().ToList().ForEach(f => sb.Append(f).Append(";"));
            return sb.ToString();
        }
    }
}
