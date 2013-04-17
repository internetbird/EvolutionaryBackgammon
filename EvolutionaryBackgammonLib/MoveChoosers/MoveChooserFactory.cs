using EvolutionaryBackgammonLib.MoveChoosers;

namespace EvolutionaryBackgammonLib
{
    public class MoveChooserFactory
    {
        internal static IMoveChooser Create(NucleotideType nucleotideType)
        {
            IMoveChooser moveChooser = new DefaultMoveChooser();

            switch (nucleotideType)
            {
                    case NucleotideType.BuildWallsOnStonesAtRisk:
                    moveChooser = new BuildWallsOnStonesAtRiskMoveChooser();
                    break;

                    case NucleotideType.HitOpponentStones:
                    moveChooser = new HitOpponentStonesMoveChooser();
                    break;

                    case NucleotideType.MaximizeNumberOfWalls:
                    moveChooser = new MaximizeNumOfWallsMoveChooser();
                    break;

                    case NucleotideType.MinimizeNumberOfStepsToRemoveAllStones:
                    moveChooser = new MinimizeNumberOfStepsMoveChooser();
                    break;

            }

            return moveChooser;
        }
    }
}