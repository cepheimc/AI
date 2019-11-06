using System;
using System.Threading;

namespace VacuumCleaner.Agent
{
    public class ReflexModelAgent : IAgent
    {
        private Environment map;
        private Random rnd = new Random();
        private int x1, x2, y1, y2;
        private bool isChecked = true;

        public ReflexModelAgent(Environment map, int x, int y)
        {
            this.map = map;
            x1 = x;
            y1 = y;
            x2 = x;
            y2 = y;
        }
        
        private bool IsPrevious(int x, int y)
        {
            if (x == x2 && y == y2 && isChecked)
            {
                isChecked = false;
                return true;
            } else
            {
                isChecked = true;
                return false;
            }
        }

        public void Think(int time)
        {
            for (int i = 0; i < time; i++)
            {
                if (map.IsRubbish(x1, y1))
                {
                    map.ClearRubbish(x1, y1);
                }
                else
                {
                    int newX = 0;
                    int newY = 0;

                    do
                    {
                        ActionType action = (ActionType) (rnd.Next() % 4) + 1;

                        switch (action)
                        {
                            case ActionType.Up:
                                if (x1 > 0)
                                {
                                    newX = x1 - 1;
                                    newY = y1;
                                }

                                break;
                        
                            case ActionType.Down:
                                if (x1 > 0 && x1 < 9)
                                {
                                    newX = x1 + 1;
                                    newY = y1;
                                }

                                break;
                        
                            case ActionType.Right:
                                if (y1 > 0 && y1 < 9)
                                {
                                    newX = x1;
                                    newY = y1 + 1;
                                }

                                break;
                        
                            case ActionType.Left:
                                if (y1 > 0)
                                {
                                    newX = x1;
                                    newY = y1 - 1;
                                }

                                break;
                        }
                    } while (newX == 0 || newY == 0 || IsPrevious(newX, newY) 
                             || map.states[newX, newY] == "!");
                    

                    if (map.CanMove(newX, newY))
                    {
                        x1 = newX;
                        y1 = newY;
                    }
                    else
                    {
                        map.states[newX, newY] = "!";
                    }
                }
                
                //Thread.Sleep(40);
                if(rnd.NextDouble() < 0.2)
                    map.AddRubbish();
                //map.Print(x1, y1);
            }
        }
        
        public int ConsumedEnergy => map.consumedEnergy;

        public int DirtyDegree => map.dirtyDegree;
        public string Name => "ReflexModelAgent";

        public override string ToString()
        {
            return $"Name {Name} \n consumed energy {ConsumedEnergy}\n dirty degree {DirtyDegree}";
        }
    }
}