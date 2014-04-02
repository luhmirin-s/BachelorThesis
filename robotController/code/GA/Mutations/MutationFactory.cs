using RobotSimulationController.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Mutations
{
    class MutationFactory
    {

        public static Mutation CreateDefaultMutation()
        {
            return CreateMutation((MutationType) Settings.Default.UsedMutation);
        }

        public static Mutation CreateMutation(MutationType type)
        {
            switch (type)
            {
                case MutationType.RandomSwap:
                    return new RandomBitFlip();
                default:
                    return new RandomBitFlip();
            }
        }

    }
}
