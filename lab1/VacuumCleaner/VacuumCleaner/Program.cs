using System;
using VacuumCleaner.Agent;

namespace VacuumCleaner
{
    internal class Program
    {
        private long dirtyDegree, consumedEnergy;
        
        public static void Main(string[] args)
        {
            Environment map = new Environment(3);
            
            RandomAgent agent1 = new RandomAgent(map, 1, 1);
            agent1.Think(500);

            Console.WriteLine(agent1.ToString());
            
            /*ReflexAgent agent1 = new ReflexAgent(map, 1, 1);
            agent1.Think(100);

            Console.WriteLine(agent1.ToString());
            
           /* ReflexModelAgent agent1 = new ReflexModelAgent(map, 1, 1);
            agent1.Think(2000);

            Console.WriteLine(agent1.ToString());*/

            Console.Read();
        }
    }
}