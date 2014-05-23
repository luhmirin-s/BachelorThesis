using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController
{

    enum RobotType
    {
        SIMPLE_NN
    }

    enum NetworkType
    {
        OneLayerPerceptron = 0,
        TwoLayerPerceptron = 1,
        ThreeLayerPerceptron = 2,
        ElmanNetwork = 3,
        HopfieldNetwork = 4        
    }

    enum ActivationFuctionType
    {
        ClassicSigmoid = 0,
        Sigmoid = 1
    }

    enum FitnessFunctionType
    {
        PositionToEnd = 0
    }

    enum MutationType
    {
        RandomSwap = 0
    }

    enum CrossoverType
    {
        UniformWithElite = 0
    }
}
