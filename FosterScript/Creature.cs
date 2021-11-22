namespace FosterScript
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


        public double VisionCost
        {
            get 
            {
                return visionLength * visionWidth;

            }
        }
        private double visionLength; // no limit
        private double visionWidth; // no limit


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


        public double EatCost 
        {
            get
            {
                return (veggieReward + 1) * (meatReward + 1);
            }
        }
        private double veggieReward; // 0 to 1
        private double meatReward; // 0 to 1


        public double PheromoneCost 
        { 
            get 
            {
                return pheromoneRange * pheromoneTime;
            }
        }
        private double pheromoneRange; // no limit
        private double pheromoneTime; // no limit


        public double SmellCost 
        { 
            get
            {
                return smellRange * smellRange;
            }
        }
        private double smellRange; // no limit



        public double TurnCost
        {
            get 
            { 
                return initiative / timerFrequency;
            }
        }
        private int timerFrequency;
        private double initiative;


        private double stealth; // How stealthy it can be
        private double attraction; // How flashy and attractive it is
    }
}