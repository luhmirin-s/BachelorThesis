using Moda;
using OfficeOpenXml;
using RobotSimulationController.DB;
using RobotSimulationController.GA.Crossovers;
using RobotSimulationController.GA.Fitness;
using RobotSimulationController.GA.Mutations;
using RobotSimulationController.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotSimulationController.GA
{
    class EvolutionThread
    {

        private int MAX_GENERATIONS = Settings.Default.GenerationCount;

        public delegate void EvolutionStoppedDelegate();
        public event EvolutionStoppedDelegate EvolutionStoppedEvent;

        private Connection Connection;
        private Population Population;
        private FitnessFunction Fitness;
        private Crossover Crossover;
        private Mutation Mutation;

        private int GenerationCounter = 0;
        private DateTime Timestamp;

        private bool _shouldStop;

        public static EvolutionThread NewInstance()
        {
            return new EvolutionThread();
        }

        private EvolutionThread()
        {
            GenerationCounter = 0;
            Timestamp = System.DateTime.Now;
            Fitness = FitnessFunctionFactory.CreateDefaultFunction();
            Crossover = CrossoverFactory.CreateDefaultCrossover();
            Mutation = MutationFactory.CreateDefaultMutation();

        }

        // Parametr setters. ALL MANDATORY 
        public EvolutionThread WithPopulation(List<AbstractRobot> startingGeneration)
        {
            Population = new Population(startingGeneration);
            return this;
        }

        public EvolutionThread WithConnection(Moda.Connection connection)
        {
            Connection = connection;
            return this;
        }

        // Actual work

        public void DoWork()
        {
            List<GenerationModel> generations = new List<GenerationModel>();
                       
            while (!_shouldStop)
            {
                GenerationCounter++;
                float[] results = Population.evaluateGeneration(Connection, Fitness);
                // posting generation statistics
                float avg = results.Average();
                float max = results.Max();
                float min = results.Min();
                postGenerationResults(avg, max, min);


                GenerationModel model = new GenerationModel();
                model.GenerationId = GenerationCounter;
                model.FitnessValues = results;
                generations.Add(model);


                if (_shouldStop || GenerationCounter >= MAX_GENERATIONS) break;
                // creating new population
                Population.createNewGeneration(Crossover, Mutation);

            }
           
            CreateExcelReport(generations);

            if (EvolutionStoppedEvent != null)
            {
                EvolutionStoppedEvent();
            }
        }

        private void CreateExcelReport(List<GenerationModel> generations)
        {
            int generationsSize = generations[0].FitnessValues.Length + Settings.Default.EliteSize;
   
            ExcelPackage package = new ExcelPackage();
            package.Workbook.Worksheets.Add("Generation landscapes");
            ExcelWorksheet sheet = package.Workbook.Worksheets[1];
           
            sheet.Cells[1, 1].Value = "Gen.";
                      
            for (int i = 0; i < generationsSize; i++)
            {
                sheet.Cells[i + 2, 1].Value = i;
            }

            foreach (GenerationModel generation in generations) 
            {
                int rowIndex = generation.GenerationId + 1;
                sheet.Cells[rowIndex, 1].Value = generation.GenerationId;

                for (int i = 0; i < generation.FitnessValues.Length; i++)
                {
                    sheet.Cells[rowIndex, i + 2].Value = generation.FitnessValues[i];
                }
            }

            Byte[] bin = package.GetAsByteArray();
            string file = AppDomain.CurrentDomain.BaseDirectory + "finished_" + DateTime.Now.ToString("dd.MM.yyyy_h:mm:ss")+ ".xlsx";
            File.WriteAllBytes(file, bin);
            Console.WriteLine("Wrote results to " + file);

        }

        private void postGenerationResults(float avg, float max, float min)
        {
            String s = GenerationCounter + ") avg=" + avg + " max=" + max + " min=" + min;
            Console.WriteLine(s);
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

    }
}
