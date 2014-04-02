using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController
{

    enum NetworkType
    {
        OneLayer = 0
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
