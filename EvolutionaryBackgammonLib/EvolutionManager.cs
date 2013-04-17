using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    public delegate void GenerationCompletedEventHandler(object sender, GenerationCompletedEventArgs args);
    public delegate void GenerationStartededEventHandler(object sender, GenerationStartededEventArgs args);
    public delegate void GenerationGameSetCompletedEventHandler(object sender, GenerationGameSetCompletedEventArgs args);

    /// <summary>
    /// Handles the main evolutionary algorithm functions.
    /// </summary>
    public class EvolutionManager
    {
        private List<Player> m_population;
        private readonly int m_numofGenerations;
        private readonly int m_numOfGamesPerGeneration;
        private readonly double m_mutationProbability;
        private readonly double m_crossoverProbability;
        private readonly int m_populationSize;
        private readonly Random m_random;
        private bool m_stopEvolution;

        public event GenerationCompletedEventHandler GenerationCompleted;
        public event GenerationStartededEventHandler GenerationStarted;
        public event GenerationGameSetCompletedEventHandler GenerationGameSetCompleted;

        /// <summary>
        /// Initializes a new instance of the <see cref="EvolutionManager" /> class.
        /// </summary>
        /// <param name="populationSize">Size of the population.</param>
        /// <param name="numofGenerations">The numof generations.</param>
        /// <param name="numOfGamesPerGeneration">The num of games per generation.</param>
        /// <param name="mutationProbability">The mutation probability.</param>
        /// <param name="crossoverProbability">The crossover probability.</param>
        public EvolutionManager(int populationSize, int numofGenerations, int numOfGamesPerGeneration, double mutationProbability, double crossoverProbability)
        {
            m_populationSize = populationSize;
            m_population = EvolutionHelper.CreateRandomPopulation(populationSize, PlayerColor.White);
            m_numofGenerations = numofGenerations;
            m_numOfGamesPerGeneration = numOfGamesPerGeneration;
            m_mutationProbability = mutationProbability;
            m_crossoverProbability = crossoverProbability;

            m_random = new Random(DateTime.Now.Millisecond);
        }

        /// <summary>
        /// Starts the evolution.
        /// </summary>
        public void StartEvolution()
        {
            for (int i = 0; i < m_numofGenerations; i++)
            {
                OnGenerationStarted(i + 1);

                for (int j = 0; j < m_populationSize; j++)
                {
                    
                    for (int k = 0; k < m_numOfGamesPerGeneration; k++)
                    {
                        Player opponent = EvolutionHelper.CreateRandomPlayer(PlayerColor.Black);

                        var game = new Game(m_population[j], opponent);

                        Player winner = game.Play();

                        if (winner == m_population[j])
                        {
                            m_population[j].NumOfWins++;
                        }

                        if (m_stopEvolution) return;
                    }

                    OnGenerationGameSetCompleted(j + 1);

                }

                OnGenerationCompleted(i + 1);
                GenerateNextGenerationPopulation();
            }

        }

        private void OnGenerationGameSetCompleted(int playerNum)
        {
            if (GenerationGameSetCompleted != null)
            {
                GenerationGameSetCompleted(this, new GenerationGameSetCompletedEventArgs
                                               {
                                                   GenerationPrecentCompleted = playerNum*100/m_populationSize
                                               });
            }
        }

        /// <summary>
        /// Called when [generation started].
        /// </summary>
        /// <param name="generationNumber">The generation number.</param>
        private void OnGenerationStarted(int generationNumber)
        {
            if (GenerationStarted != null)
            {
                GenerationStarted(this, new GenerationStartededEventArgs {GenerationNumber = generationNumber});
            }
        }

        /// <summary>
        /// Called when [generation completed].
        /// </summary>
        /// <param name="generationNumber">The generation number.</param>
        private void OnGenerationCompleted(int generationNumber)
        {
            if (GenerationCompleted != null)
            {
                GenerationCompleted(this, CalculateGenerationCompletedEventArgs(generationNumber));
            }
        }

        /// <summary>
        /// Calculates the generation completed event args.
        /// </summary>
        /// <param name="generationNumber">The generation number.</param>
        /// <returns></returns>
        private GenerationCompletedEventArgs CalculateGenerationCompletedEventArgs(int generationNumber)
        {

            var args = new GenerationCompletedEventArgs
                {
                    GenerationNumber = generationNumber,
                    BestFitness = m_population.Max(player => player.NumOfWins)*100/m_numOfGamesPerGeneration,
                    WorstFitness = m_population.Min(player => player.NumOfWins)*100/ m_numOfGamesPerGeneration,
                    AverageFitness = m_population.Sum(player => player.NumOfWins)*100/(m_numOfGamesPerGeneration * m_populationSize),
                    BestPlayerChromosomeStructure = GetBestPlayerChromosomeStructure()
                };

            return args;
        }

        /// <summary>
        /// Gets the best player's chromosome structure.
        /// </summary>
        /// <returns></returns>
        private Dictionary<NucleotideType, int> GetBestPlayerChromosomeStructure()
        {
            Player bestPlayer = m_population.OrderByDescending(player => player.NumOfWins).First();

            var chromosomeStructure = new Dictionary<NucleotideType, int>();

            for (int i = 0; i < Chromosome.Length; i++)
            {
               NucleotideType type =  bestPlayer.Chromosome[i].Type;

                if (chromosomeStructure.ContainsKey(type))
                {
                    chromosomeStructure[type]++;
                }
                else
                {
                    chromosomeStructure.Add(type, 1);
                    
                }

            }

            return chromosomeStructure;
        }

        /// <summary>
        /// Generates the next generation population.
        /// </summary>
        private void GenerateNextGenerationPopulation()
        {
            var newPopulation = new List<Player>();

            while (newPopulation.Count < m_populationSize)
            {
                Tuple<Player, Player> parents = ChooseParents();

                Player offspring = GenerateOffspring(parents);

                newPopulation.Add(offspring);
            }

            m_population = newPopulation;
        }

        /// <summary>
        /// Generates an offspring from the given 2 parents.
        /// Makes a crossover and mutation according to the relevant probabilities. 
        /// 
        /// </summary>
        /// <param name="parents">The parents.</param>
        /// <returns>The result offspring</returns>
        private Player GenerateOffspring(Tuple<Player, Player> parents)
        {
            Player offspring = null;

            if (DoCrossover())
            {
                var crossoverPosition = m_random.Next(1, Chromosome.Length - 2);

                var parent1ChromosomePart = parents.Item1.Chromosome.GetNucleotides(0, crossoverPosition);
                var parent2ChromosomePart = parents.Item2.Chromosome.GetNucleotides(crossoverPosition + 1, Chromosome.Length - 1);

                var nucleotides = parent1ChromosomePart.Concat(parent2ChromosomePart).ToArray();

                for (int i = 0; i < Chromosome.Length; i++)
                {
                    if (DoMutation())
                    {
                        nucleotides[i] = EvolutionHelper.GetRandomNeucleotide();
                    }
                    
                }

                var chromosome = new Chromosome(nucleotides);

                offspring = new Player(parents.Item1.Color, chromosome);
            }
            else
            {
                offspring = parents.Item1.Clone();
            }

            return offspring;
        }

        /// <summary>
        /// Decides whether to do a mutation based on the mutation probability.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        private bool DoMutation()
        {
            var rand = m_random.Next(101);
            return rand <= m_mutationProbability*100;
        }

        /// <summary>
        /// Decides whether to do a crossover based on the crossover probability.
        /// </summary>
        /// <returns></returns>
        private bool DoCrossover()
        {
            var rand = m_random.Next(101);
            return rand <= m_crossoverProbability*100;

        }

        /// <summary>
        /// Chooses the parents.
        /// </summary>
        /// <returns></returns>
        private Tuple<Player, Player> ChooseParents()
        {

            Player parent1 = ChooseParent();
            Player parent2 = null;

            while (parent2 == null)
            {
                Player temp = ChooseParent();
                if (temp != parent1)
                {
                    parent2 = temp;
                }
            }

            return new Tuple<Player, Player>(parent1, parent2);

        }

        /// <summary>
        /// Chooses a parent based on roulette selection principle.
        /// </summary>
        /// <returns></returns>
        private Player ChooseParent()
        {
            var totalPopulationWins = m_population.Sum(player => player.NumOfWins);

            int rand = m_random.Next(totalPopulationWins);
            int rouletteValue = 0;

            for (int i = 0; i < m_populationSize; i++)
            {
                rouletteValue += m_population[i].NumOfWins;

                if (rouletteValue >= rand)
                {
                    return m_population[i];
                }

            }

            return m_population[m_populationSize - 1];

        }

        public void StopEvolution()
        {
            m_stopEvolution = true;
        }
    }
}
