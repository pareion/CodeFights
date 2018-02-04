using System;
using System.Collections.Generic;

namespace CodeFight
{
    class GraphProblems
    {

        /// <summary>
        /// https://codefights.com/arcade/graphs-arcade/kingdom-roads
        /// 
        /// Solution to the graph challenges of the Kingdom Roads from codefights
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
            int[][] result = new int[roads.Length][];
            for (int i = 0; i < roads.Length; i++)
            {
                result[roads[i][2]] = roads[i];
            }
            List<int> previous = new List<int>();
            foreach (var item in result)
            {
                if (previous.Contains(item[0]) || previous.Contains(item[1]))
                {
                    return false;
                }
                else
                {
                    previous.Clear();
                    previous.Add(item[0]);
                    previous.Add(item[1]);
                }
            }
            return true;
        }
        bool[][] greatRenaming(bool[][] roadRegister)
        {
            bool[][] result = new bool[roadRegister.Length][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new bool[roadRegister[i].Length];
            }
            for (int x = 0; x < roadRegister.Length; x++)
            {
                for (int y = 0; y < roadRegister[x].Length; y++)
                {
                    int tempX = x;
                    int tempY = y;
                    if (roadRegister[x][y] == true)
                    {
                        if (x == roadRegister.Length - 1)
                        {
                            tempX = 0;
                        }
                        else
                        {
                            tempX++;
                        }
                        if (y == roadRegister[x].Length - 1)
                        {
                            tempY = 0;
                        }
                        else
                        {
                            tempY++;
                        }
                        result[tempX][tempY] = true;
                    }
                }
            }
            return result;
        }
        //TODO not finished
        int[] citiesConquering(int n, int[][] roads)
        {
            int[] result = new int[n];

            bool newCities = true;
            List<int> singles = new List<int>();
            List<int> removeThis = new List<int>();

            int count = 1;
            int previous = 0;
            while (newCities)
            {
                singles = new List<int>();
                for (int i = 0; i < roads.Length; i++)
                {
                    if (!removeThis.Contains(roads[i][0]))
                    {
                        if (singles.Contains(roads[i][0]))
                        {
                            removeThis.Add(roads[i][0]);
                        }
                        else
                        {
                            singles.Add(roads[i][0]);
                        }
                    }
                    if (!removeThis.Contains(roads[i][1]))
                    {
                        if (singles.Contains(roads[i][1]))
                        {
                            removeThis.Add(roads[i][1]);
                            singles.Remove(roads[i][1]);
                        }
                        else
                        {
                            singles.Add(roads[i][1]);
                        }
                    }
                }
                if (removeThis.Count != previous)
                {
                    foreach (var item in removeThis)
                    {
                        if (result[item] == 0)
                        {

                            result[item] = count;
                        }
                    }
                    count++;
                    previous = removeThis.Count;
                }
                else
                {
                    for (int x = 0; x < singles.Count; x++)
                    {
                        if (result[singles[x]] == 0)
                        {
                            result[singles[x]] = -1;
                        }
                    }
                    newCities = false;
                }
            }
            return result;
        }



    }
}
