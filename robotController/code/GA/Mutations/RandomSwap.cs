using RobotSimulationController.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Mutations
{
    class RandomBitFlip : Mutation
    {

        public override void Mutate(AbstractRobot robot)
        {
            Genome genes = robot.Genotype;
            PerformBitFlip(genes);
        }

        private void PerformBitFlip(Genome genes)
        {

            int mutatedGenes = 0;
            for (int ii = 0; ii < genes.Alleles.Count; ii++) 
            {
                if (Random.NextDouble() < MUTATION_PROBABILITY)
                {
                    bool inLowerByte = Random.NextDouble() > 0.5;
                    int index = Random.Next(8);
                    genes.Alleles[ii].FlipBit(inLowerByte, index);
                    mutatedGenes++;
                }
                
                if (mutatedGenes == MAX_MUTATED_GENES) break;
            }


        }

        
    }
}
