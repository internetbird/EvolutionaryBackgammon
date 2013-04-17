using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EvolutionaryBackgammon.Properties;
using EvolutionaryBackgammonLib;

namespace EvolutionaryBackgammon
{
    public partial class Form1 : Form
    {
        private EvolutionManager m_evolutionManager;

        public Form1()
        {
            InitializeComponent();

            cmbPopulationSize.SelectedIndex = 0;
            cmbNumOfGenerations.SelectedIndex = 0;
            cmbNumOfGamesPerGen.SelectedIndex = 0;
            cmbMutationProbability.SelectedIndex = 0;
            cmbCrossoverProbability.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the btnRunAlgorithm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnRunAlgorithm_Click(object sender, EventArgs e)
        {

            if (btnRunAlgorithm.Text == Resources.Stop)
            {
                m_evolutionManager.StopEvolution();

                generationProgressBar.Visible = false;
                btnRunAlgorithm.Text = Resources.RunAlgorithm;
                lblAlgorithmStatus.Text = string.Empty;
                return;
            }

            var populationSize = int.Parse(cmbPopulationSize.SelectedItem.ToString());
            var numOfGamesPerGeneration = int.Parse(cmbNumOfGamesPerGen.SelectedItem.ToString());
            var numOfGenerations = int.Parse(cmbNumOfGenerations.SelectedItem.ToString());
            var mutationProbability = double.Parse(cmbMutationProbability.SelectedItem.ToString());
            var crossoverProbability = double.Parse(cmbCrossoverProbability.SelectedItem.ToString());

            m_evolutionManager = new EvolutionManager(populationSize, numOfGenerations, numOfGamesPerGeneration, mutationProbability, crossoverProbability);
            m_evolutionManager.GenerationCompleted += OnGenerationCompleted;
            m_evolutionManager.GenerationStarted += OnGenerationStarted;
            m_evolutionManager.GenerationGameSetCompleted += OnGenerationGameSetCompleted;

            generationProgressBar.Visible = true;
            tbSummary.Text = string.Empty;

            ClearChartsPoints();

            Task.Factory.StartNew(() => m_evolutionManager.StartEvolution());

            btnRunAlgorithm.Text = Resources.Stop;

        }

        /// <summary>
        /// Clears the charts points.
        /// </summary>
        private void ClearChartsPoints()
        {
            chart1.Series["BestGenFitness"].Points.Clear();
            chart1.Series["WorstGenFitness"].Points.Clear();
            chart1.Series["AverageGenFitness"].Points.Clear();

            chart2.Series["MaximizeNumOfWalls"].Points.Clear();
            chart2.Series["MinimizeNumOfSteps"].Points.Clear();
            chart2.Series["HitOpponentStones"].Points.Clear();
            chart2.Series["BuildWallsOnStonesAtRisk"].Points.Clear();
            chart2.Series["ChooseRandomMove"].Points.Clear();
        }

        /// <summary>
        /// Called when [generation game set completed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="GenerationGameSetCompletedEventArgs" /> instance containing the event data.</param>
        private void OnGenerationGameSetCompleted(object sender, GenerationGameSetCompletedEventArgs args)
        {
            generationProgressBar.Invoke((Action)(() => generationProgressBar.Value = args.GenerationPrecentCompleted));
            generationProgressBar.Invoke((Action)(() => generationProgressBar.Refresh()));
        }

        /// <summary>
        /// Called when [generation started].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="GenerationStartededEventArgs" /> instance containing the event data.</param>
        private void OnGenerationStarted(object sender, GenerationStartededEventArgs args)
        {
            lblAlgorithmStatus.Invoke((Action)(() => lblAlgorithmStatus.Text = string.Format("Calculation generation:{0}", args.GenerationNumber)));
            lblAlgorithmStatus.Invoke((Action)(() => lblAlgorithmStatus.Refresh()));

        }

        /// <summary>
        /// Called when [generation completed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="GenerationCompletedEventArgs" /> instance containing the event data.</param>
        private void OnGenerationCompleted(object sender, GenerationCompletedEventArgs args)
        {

            chart1.Invoke((Action)(() => chart1.Series["BestGenFitness"].Points.AddXY(args.GenerationNumber, args.BestFitness)));
            chart1.Invoke((Action)(() => chart1.Series["WorstGenFitness"].Points.AddXY(args.GenerationNumber, args.WorstFitness)));
            chart1.Invoke((Action)(() => chart1.Series["AverageGenFitness"].Points.AddXY(args.GenerationNumber, args.AverageFitness)));


            chart2.Invoke((Action)(() =>
                    {
                        chart2.Series["MaximizeNumOfWalls"].Points.AddXY(args.GenerationNumber,GetChromosomeStructureValue(NucleotideType.MaximizeNumberOfWalls,args.BestPlayerChromosomeStructure));
                        chart2.Series["MinimizeNumOfSteps"].Points.AddXY(args.GenerationNumber,GetChromosomeStructureValue(NucleotideType.MinimizeNumberOfStepsToRemoveAllStones,args.BestPlayerChromosomeStructure));
                        chart2.Series["HitOpponentStones"].Points.AddXY(args.GenerationNumber, GetChromosomeStructureValue(NucleotideType.HitOpponentStones,args.BestPlayerChromosomeStructure));
                        chart2.Series["BuildWallsOnStonesAtRisk"].Points.AddXY(args.GenerationNumber,GetChromosomeStructureValue(NucleotideType.BuildWallsOnStonesAtRisk,args.BestPlayerChromosomeStructure));
                        chart2.Series["ChooseRandomMove"].Points.AddXY(args.GenerationNumber,GetChromosomeStructureValue(NucleotideType.ChooseRandomMove,args.BestPlayerChromosomeStructure));
                    }));


            WriteSummary(args);

            chart1.Invoke((Action)(() => chart1.Refresh()));
            chart2.Invoke((Action)(() => chart2.Refresh()));

        }

        /// <summary>
        /// Writes the generation summary info.
        /// </summary>
        /// <param name="args">The <see cref="GenerationCompletedEventArgs" /> instance containing the event data.</param>
        private void WriteSummary(GenerationCompletedEventArgs args)
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("-------------Generation {0} Summary-------------", args.GenerationNumber));
            sb.AppendLine(string.Format("Average Fitness:{0}", args.AverageFitness));
            sb.AppendLine(string.Format("Best Fitness:{0}", args.BestFitness));
            sb.AppendLine(string.Format("Worst Fitness:{0}", args.WorstFitness));

            sb.AppendLine("-------------Best Player Chromosome Structure-------------");
            foreach (var key in args.BestPlayerChromosomeStructure.Keys)
            {
                sb.AppendLine(string.Format("{0} :{1}%", key, args.BestPlayerChromosomeStructure[key]));
            }

            tbSummary.Invoke((Action)(() => tbSummary.Text = sb.ToString()));
            tbSummary.Invoke((Action)(() => tbSummary.Refresh()));

        }

        /// <summary>
        /// Gets the chromosome structure value.
        /// </summary>
        /// <param name="nucleotideType">Type of the nucleotide.</param>
        /// <param name="chromosozeStructure">The chromosoze structure.</param>
        /// <returns></returns>
        private int GetChromosomeStructureValue(NucleotideType nucleotideType, Dictionary<NucleotideType, int> chromosozeStructure)
        {
            if (!chromosozeStructure.ContainsKey(nucleotideType))
            {
                return 0;
            }

            return chromosozeStructure[nucleotideType];
        }
    }
}
