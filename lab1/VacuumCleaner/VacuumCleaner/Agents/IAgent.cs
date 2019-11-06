namespace VacuumCleaner.Agent
{
    public interface IAgent
    {
        string Name { get; }

        void Think(int time);
        
        int ConsumedEnergy { get; }
        int DirtyDegree { get; }
    }
}