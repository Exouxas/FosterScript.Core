namespace FosterScriptLib
{
    public class Creature
    {
        /// <summary>
        /// Amount of food stored in the creature. Limited by the maxFoodStorage variable.
        /// </summary>
        public double FoodStorage
        {
            get { return foodStorage; }
            set 
            {
                if (value < 0)
                {
                    foodStorage = 0;
                }
                else if(foodStorage > maxFoodStorage)
                {
                    foodStorage = maxFoodStorage;
                }
                else
                {
                    foodStorage = value;
                }
            }
        }
        private double foodStorage;
        private double maxFoodStorage; // no limit


        /// <summary>
        /// The cost of doing a movement action.
        /// </summary>
        public double MovementCost
        {
            get 
            { 
                return maxFoodStorage * maxMovementSpeed * foodStorage; 
            }
        }
        private double maxMovementSpeed; // no limit


        /// <summary>
        /// The cost of looking.
        /// </summary>
        public double VisionCost
        {
            get 
            {
                return visionLength * visionWidth;

            }
        }
        private double visionLength; // no limit
        private double visionWidth; // no limit


        /// <summary>
        /// The cost of attacking.
        /// </summary>
        public double AttackCost
        {
            get 
            {
                return attackStrength * attackLength * attackWidth;
            }
        }
        private double attackStrength; // no limit
        private double attackLength; // no limit
        private double attackWidth; // no limit


        /// <summary>
        /// The cost of eating.
        /// </summary>
        public double EatCost 
        {
            get
            {
                return (veggieReward + 1) * (meatReward + 1);
            }
        }
        private double veggieReward; // 0 to 1
        private double meatReward; // 0 to 1


        /// <summary>
        /// The cost of releasing pheromones.
        /// </summary>
        public double PheromoneCost 
        { 
            get 
            {
                return pheromoneRange * pheromoneTime;
            }
        }
        private double pheromoneRange; // no limit
        private double pheromoneTime; // no limit


        /// <summary>
        /// The cost of smelling.
        /// </summary>
        public double SmellCost 
        { 
            get
            {
                return smellRange * smellRange;
            }
        }
        private double smellRange; // no limit


        /// <summary>
        /// The forced cost for the round.
        /// </summary>
        public double TurnCost
        {
            get 
            { 
                return initiative / timerFrequency;
            }
        }
        private int timerFrequency;
        private double initiative;


        private double stealth; // How stealthy the creature can be
        private double attraction; // How flashy and attractive the creature is
    }
}