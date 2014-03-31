using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace RobotSimulationController.DB
{
    class ExperimentContext : DbContext 
    {

        public DbSet<IndividModel> Individuals { get; set; }


    }
}
