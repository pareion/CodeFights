using System;
using System.Collections.Generic;

namespace CodeFight
{
    class GraphProblems
    {

        /// <summary>
        /// https://codefights.com/arcade/graphs-arcade/kingdom-roads
        /// 
        /// Solution to the first challenge of the Kingdom Roads from codefights
        /// </summary>
        /// <param name="roadRegister"></param>
        /// <returns></returns>
        bool newRoadSystem(bool[][] roadRegister)
        {
            int countOneWay = 0;
            int countOtherWay = 0;

            for (int x = 0; x < roadRegister[0].Length; x++)
            {
                for (int y = 0; y < roadRegister[x].Length; y++)
                {
                    countOneWay += roadRegister[x][y] ? 1 : 0;
                    countOtherWay += roadRegister[y][x] ? 1 : 0;
                }
                if (countOneWay != countOtherWay)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// https://codefights.com/arcade/graphs-arcade/kingdom-roads
        /// 
        /// Solution to the second challenge of the Kingdom Roads from codefights
        /// </summary>
        /// <param name="roadRegister"></param>
        /// <returns></returns>
        int[][] roadsBuilding(int cities, int[][] roads)
        {
            int[][] newRoads = new int[(cities * (cities - 1)) / 2][];
            List<int[]> createdRoads = new List<int[]>();
            int[,] allRoads = new int[cities, cities];
            int counter = 0;
            for (int x = 0; x < roads.Length; x++)
            {
                allRoads[roads[x][0], roads[x][1]] = 1;
            }

            for (int x = 0; x < cities; x++)
            {
                for (int y = 0; y < cities; y++)
                {
                    if (allRoads[x, y] != 1 && allRoads[y, x] != 1)
                        if (x != y)
                        {
                            if (!createdRoads.Exists(z => z[0] == x && z[1] == y) && !createdRoads.Exists(z => z[0] == y && z[1] == x))
                            {
                                if (y > x)
                                {
                                    newRoads[counter] = new int[2] { x, y };
                                    createdRoads.Add(new int[2] { x, y });
                                    counter++;
                                }
                                else
                                {
                                    newRoads[counter] = new int[2] { y, x };
                                    createdRoads.Add(new int[2] { y, x });
                                    counter++;
                                }
                            }
                        }
                }
            }
            int[][] result = new int[counter][];
            Array.Copy(newRoads, result, counter);
            return result;
        }
        /// <summary>
        /// https://codefights.com/arcade/graphs-arcade/kingdom-roads
        /// 
        /// Solution to the third challenge of the Kingdom Roads from codefights
        /// </summary>
        /// <param name="roadRegister"></param>
        /// <returns></returns>
        bool efficientRoadNetwork(int n, int[][] roads)
        {
            if (n == 1)
            {
                return true;
            }
            int[,] availableRoads = new int[n, n];

            foreach (int[] item in roads)
            {
                availableRoads[item[0], item[1]] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                List<int> visited = new List<int>();
                for (int x = 0; x < n; x++)
                {
                    if (availableRoads[i, x] == 1 || availableRoads[x, i] == 1)
                    {
                        if (!visited.Contains(i))
                        {
                            visited.Add(i);
                        }
                        if (!visited.Contains(x))
                        {
                            visited.Add(x);
                        }
                    }
                }
                List<int> allVisited = new List<int>(visited);

                for (int v = 0; v < visited.Count; v++)
                {
                    for (int x2 = 0; x2 < n; x2++)
                    {
                        if (availableRoads[visited[v], x2] == 1 || availableRoads[x2, visited[v]] == 1)
                        {
                            if (!allVisited.Contains(visited[v]))
                            {
                                allVisited.Add(visited[v]);
                            }
                            if (!allVisited.Contains(x2))
                            {
                                allVisited.Add(x2);
                            }
                        }
                    }
                }
                if (allVisited.Count != n)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// https://codefights.com/arcade/graphs-arcade/kingdom-roads
        /// 
        /// Solution to the fourth challenge of the Kingdom Roads from codefights
        /// </summary>
        /// <param name="roadRegister"></param>
        /// <returns></returns>
        bool[][][] financialCrisis(bool[][] roadRegister)
        {
            bool[][][] result = new bool[roadRegister[0].Length][][];
            int xC = 0;
            int yC = 0;
            for (int cities = 0; cities < roadRegister[0].Length; cities++)
            {
                xC = 0;
                yC = 0;
                //create matrix with missing 'cities'
                bool[][] city = new bool[roadRegister[0].Length - 1][];
                for (int x = 0; x < roadRegister[0].Length; x++)
                {
                    bool[] vertical = new bool[roadRegister[0].Length - 1];
                    for (int y = 0; y < roadRegister[0].Length; y++)
                    {
                        if (x != cities && y != cities)
                        {
                            vertical[xC] = roadRegister[x][y];
                            xC++;
                        }
                    }
                    if (xC == roadRegister[0].Length - 1)
                    {
                        city[yC] = vertical;
                        yC++;
                    }
                    xC = 0;
                }
                result[cities] = city;
            }
            return result;
        }
   
        bool namingRoads(int[][] roads)
        {
            
            Dictionary<int, int[]> cityRoadLookUp = new Dictionary<int, int[]>();
            for (int road = 0; road < roads.Length; road++)
            {
                if (!cityRoadLookUp.ContainsKey(roads[road][0]))
                {
                    cityRoadLookUp.Add(roads[road][0], new int[roads.Length]);
                }
                if (!cityRoadLookUp.ContainsKey(roads[road][1]))
                {
                    cityRoadLookUp.Add(roads[road][1], new int[roads.Length]);
                }

                cityRoadLookUp[roads[road][0]][(roads[road][2])] = (roads[road][2]);
                cityRoadLookUp[roads[road][1]][(roads[road][2])] = (roads[road][2]);

                
            }

            for (int x = 0; x < roads.Length; x++)
            {
                try
                {
                        if (cityRoadLookUp[roads[x][0]][roads[x][2] - 1] == roads[x][2] - 1)
                        {
                            return false;
                        }
                 
                        if (cityRoadLookUp[roads[x][1]][roads[x][2] + 1] == roads[x][2] + 1)
                        {
                            return false;
                        }
                    
                }
                catch (Exception)
                {
                    
                }
                
            }
            
            return true;

        }

    }
}
