using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Mutations
{
    class RandomBitFlip : Mutation
    {

        public const int MAX_MUTATED_GENES = 5;
        public const double BIT_FLIP_PROBABILITY = 0.1;

        private Random Random = new Random();

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
                if (Random.NextDouble() < BIT_FLIP_PROBABILITY)
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
