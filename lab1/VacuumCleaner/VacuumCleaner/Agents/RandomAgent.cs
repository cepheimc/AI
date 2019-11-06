using System;
using System.Threading;

namespace VacuumCleaner.Agent
{
    public class RandomAgent : IAgent
    {
        private Environment map;
        private Random rnd = new Random();
        private int x, y;

        public RandomAgent(Environment map, int x, int y)
        {
            this.map = map;
            this.x = x;
            this.y = y;
        }

        public void Think(int time)
        {
            for (int i = 0; i < time; i++)
            {
                
                int newX = 0;
                int newY = 0;

                ActionType action = (ActionType) (rnd.Next() % 5) + 1;

                switch (action)
                {
                    case ActionType.Up:
                        if (x > 0)
                        {
                            newX = x - 1;
                            newY = y;
                        }

                        break;
                        
                    case ActionType.Down:
                        if (x > 0 && x < 9)
                        {
                            newX = x + 1;
                            newY = y;
                        }

                        break;
                        
                    case ActionType.Right:
                        if (y > 0 && y < 9)
                        {
                            newX = x;
                            newY = y + 1;
                        }

                        break;
                        
                    case ActionType.Left:
                        if (y > 0)
                        {
                            newX = x;
                            newY = y - 1;
                        }

                        break;
                    
                    case ActionType.Suck:
                        if (!map.IsRubbish(x, y))
                            map.dirtyDegree++;
                        map.ClearRubbish(x, y);

                        break;
                    }

                    if (newX != 0 && newY != 0 && map.CanMove(newX, newY))
                    {
                        x = newX;
                        y = newY;

                        map.consumedEnergy++;
                    }

                Thread.Sleep(40);
                if(rnd.NextDouble() < 0.015)
                    map.AddRubbish();
                map.Print(x, y);
            }
        }

        public int ConsumedEnergy => map.consumedEnergy;

        public int DirtyDegree => map.dirtyDegree;

        public string Name => "RandomAgent";

        public override string ToString()
        {
            return $"\n\nName {Name} \n consumed energy {ConsumedEnergy}\n dirty degree {DirtyDegree}";
        }

    }
}