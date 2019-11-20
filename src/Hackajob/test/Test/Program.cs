using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    using System;

    public enum Army
    {
        SevenKingdom,
        WhiteWalker
    }

    public interface IArmyStatus
    {
        bool IsAlive();

        int Damage();
    }

    public class SevenKingdomArmyStatus : IArmyStatus
    {
        public const int DefenceDragon = 600;
        public const int DefenceInfantry = 2;

        public int Dragons { get; set; }

        public int Infantry { get; set; }

        public SevenKingdomArmyStatus(int dragons)
        {
            if (dragons < 0)
            {
                throw new ArgumentException();
            }


            Dragons = dragons;
            Infantry = 5000;
        }

        public bool IsAlive()
        {
            return Dragons > 0 || Infantry > 0;
        }

        public int Damage()
        {
            return Dragons * 600 + Infantry * 2;
        }
    }

    public class WhiteWalkerArmyStatus : IArmyStatus
    {
        public const int DefenceLord = 100;
        public const int DefenceWalker = 3;

        public int Lords { get; set; }

        public int Walkers { get; set; }

        public WhiteWalkerArmyStatus(int lords)
        {
            if (lords < 0)
            {
                throw new ArgumentException();
            }

            Lords = lords;
            Walkers = 10000;
        }

        public bool IsAlive()
        {
            return Lords > 0 || Walkers > 0;
        }


        public int Damage()
        {
            return Lords * 50 + Walkers * 1;
        }
    }

    public interface IGameStrategy
    {
        void RunNextTurn(SevenKingdomArmyStatus sevenKingdomArmyStatus,
                    WhiteWalkerArmyStatus whiteWalkerArmyStatus);
    }

    public class WhiteWalkerGameStrategy : IGameStrategy
    {
        public void RunNextTurn(SevenKingdomArmyStatus sevenKingdomArmyStatus,
                           WhiteWalkerArmyStatus whiteWalkerArmyStatus)
        {
            var damageLeft = whiteWalkerArmyStatus.Damage();

            var possibleAmountOfDragonsToBeKilled = damageLeft / SevenKingdomArmyStatus.DefenceDragon;

            var actualAmountOfDragonsKilled = Math.Min(possibleAmountOfDragonsToBeKilled,
                sevenKingdomArmyStatus.Dragons);

            damageLeft -= SevenKingdomArmyStatus.DefenceDragon * actualAmountOfDragonsKilled;
            sevenKingdomArmyStatus.Dragons -= actualAmountOfDragonsKilled;

            var possibleAmountInfantryKilled = damageLeft / SevenKingdomArmyStatus.DefenceInfantry;

            var actualAmountInfantryKilled = Math.Min(possibleAmountInfantryKilled,
                sevenKingdomArmyStatus.Infantry);

            sevenKingdomArmyStatus.Infantry -= actualAmountInfantryKilled;
        }

    }

    public class SevenKingdomGameStrategy : IGameStrategy
    {
        public void RunNextTurn(SevenKingdomArmyStatus sevenKingdomArmyStatus,
                           WhiteWalkerArmyStatus whiteWalkerArmyStatus)
        {

            var damageLeft = sevenKingdomArmyStatus.Damage();

            var possibleAmountOfLordsToBeKilled = damageLeft / WhiteWalkerArmyStatus.DefenceLord;

            var actualAmountOfLordsToBeKilled = Math.Min(possibleAmountOfLordsToBeKilled,
                whiteWalkerArmyStatus.Lords);

            damageLeft -= WhiteWalkerArmyStatus.DefenceLord * actualAmountOfLordsToBeKilled;
            whiteWalkerArmyStatus.Lords -= actualAmountOfLordsToBeKilled;

            var possibleAmountWalkersKilled = damageLeft / WhiteWalkerArmyStatus.DefenceWalker;

            var actualAmountWalkersKilled = Math.Min(possibleAmountWalkersKilled,
                whiteWalkerArmyStatus.Walkers);

            whiteWalkerArmyStatus.Walkers -= actualAmountWalkersKilled;

        }
    }

    public class StrategyPicker
    {
        public IGameStrategy GetStrategy(Army currentTurn)
        {
            switch (currentTurn)
            {
                case Army.SevenKingdom:
                    return new SevenKingdomGameStrategy();
                case Army.WhiteWalker:
                    return new WhiteWalkerGameStrategy();
                default:
                    throw new ArgumentException();
            }
        }
    }

    public class Game
    {
        private readonly SevenKingdomArmyStatus _sevenKingdomArmyStatus;
        private readonly WhiteWalkerArmyStatus _whiteWalkerArmyStatus;

        public Tuple<Army, int> Simulate(Army firstTurn, int dragons, int lords)
        {
            if (dragons < 0)
            {
                throw new ArgumentException();
            }
            if (lords < 0)
            {
                throw new ArgumentException();
            }

            var sevenKingdomArmyStatus = new SevenKingdomArmyStatus(dragons);
            var whiteWalkerArmyStatus = new WhiteWalkerArmyStatus(lords);
            int turnsAmount = 0;
            Army currentTurn = firstTurn;
            var strategyPicker = new StrategyPicker();
            while (sevenKingdomArmyStatus.IsAlive() && whiteWalkerArmyStatus.IsAlive())
            {
                var strategy = strategyPicker.GetStrategy(currentTurn);
                strategy.RunNextTurn(sevenKingdomArmyStatus, whiteWalkerArmyStatus);

                currentTurn = currentTurn == Army.SevenKingdom
                        ? Army.WhiteWalker
                        : Army.SevenKingdom;
                turnsAmount++;
            }

            return sevenKingdomArmyStatus.IsAlive()
                ? new Tuple<Army, int>(Army.SevenKingdom, turnsAmount)
                : new Tuple<Army, int>(Army.WhiteWalker, turnsAmount);
        }
    }


    public class Solution
    {
        private const string SevenKingdomArmy = "Seven Kingdom Army";
        private const string WhiteWalkerArmy = "White Walker Army";
        private const string InvalidParameterOutput = "Invalid parameter provided";


        static public string Run(string first_strike_army_name, int no_of_dragons, int no_of_white_lords)
        {
            //
            // Some work here; return type and arguments should be according to the problem's requirements
            //

            Army firstStrikeArmy;
            if (!TryParseFirstStrikeArmy(first_strike_army_name, out firstStrikeArmy) ||
                no_of_dragons < 0 || no_of_white_lords < 0)
            {
                return InvalidParameterOutput;
            }

            var game = new Game();

            var result = game.Simulate(firstStrikeArmy, no_of_dragons, no_of_white_lords);
            return (result.Item1 == Army.SevenKingdom ? SevenKingdomArmy : WhiteWalkerArmy) +
            "|" + result.Item2.ToString();
        }

        static private bool TryParseFirstStrikeArmy(string firstStrikeArmy, out Army result)
        {
            if (firstStrikeArmy == SevenKingdomArmy)
            {
                result = Army.SevenKingdom;
                return true;
            }
            else if (firstStrikeArmy == WhiteWalkerArmy)
            {
                result = Army.WhiteWalker;
                return true;
            }
            else
            {
                result = default(Army);
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.Run("Seven Kingdom Army", 10, 10));
        }
    }
}
