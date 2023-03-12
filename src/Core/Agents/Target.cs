namespace FosterScript.Core.Agents
{
    public struct Target
    {
        public Target(Actor actor, double distance)
        {
            Actor = actor;
            Distance = distance;
        }

        public Actor Actor { get; }
        public double Distance { get; }

        public override string ToString()
        {
            return $"({Actor}, distance: {Distance})";
        }
    }
}