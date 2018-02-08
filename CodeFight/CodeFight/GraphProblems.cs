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
        int[] citiesConquering(int n, int[][] roads)
        {
            bool[] checkIfConquered = new bool[n];
            int[] result = new int[n];
            Dictionary<int, int> counter = new Dictionary<int, int>();
            bool conqueredNewCities = true;
            int count = 1;
            while (conqueredNewCities)
            {
                counter = new Dictionary<int, int>();
                for (int i = 0; i < roads.Length; i++)
                {
                    if (checkIfConquered[roads[i][0]] == false && checkIfConquered[roads[i][1]] == false)
                    {
                        if (!counter.ContainsKey(roads[i][0]))
                        {
                            counter.Add(roads[i][0], 1);
                        }
                        else
                        {
                            counter[roads[i][0]] += 1;
                        }
                        if (!counter.ContainsKey(roads[i][1]))
                        {
                            counter.Add(roads[i][1], 1);
                        }
                        else
                        {
                            counter[roads[i][1]] += 1;
                        }
                    }
                }
                conqueredNewCities = false;
                for (int i = 0; i < n; i++)
                {
                    if (checkIfConquered[i] != true)
                    {
                        if (counter.ContainsKey(i))
                        {
                            if (counter[i] == 1)
                            {
                                conqueredNewCities = true;
                                checkIfConquered[i] = true;
                                result[i] = count;
                            }
                        }
                        else
                        {
                            conqueredNewCities = true;
                            checkIfConquered[i] = true;
                            result[i] = count;
                        }
                    }
                }
                count++;
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 0)
                {
                    result[i] = -1;
                }
            }
            return result;
        }
        bool[][] mergingCities(bool[][] roadRegister)
        {
            bool[][] result;
            if (roadRegister.Length < 1)
            {
                return roadRegister;
            }
            List<int> merge = new List<int>();
            for (int i = 0; i <= roadRegister.Length + 1 / 2; i += 2)
            {
                try
                {
                    if (roadRegister[i][i + 1] == true)
                    {
                        merge.Add(i);
                    }
                }
                catch (Exception)
                {

                }
            }
            result = new bool[roadRegister.Length - merge.Count][];
            int counter = -1;
            for (int j = 0; j < roadRegister.Length; j++)
            {
                counter++;
                result[counter] = new bool[roadRegister.Length - merge.Count];
                if (merge.Contains(j))
                {
                    int count = 0;
                    for (int i = 0; i < roadRegister[j].Length; i++)
                    {
                        if (i == j)
                        {
                            result[counter][count] = false;
                            i++;
                        }
                        else if (merge.Contains(i))
                        {
                            if (roadRegister[j][i] == true || roadRegister[j + 1][i] == true || roadRegister[j][i + 1] == true || roadRegister[j + 1][i + 1] == true)
                            {
                                result[counter][count] = true;
                            }
                            else
                                result[counter][count] = false;
                            i++;
                        }
                        else if (roadRegister[j][i] == true || roadRegister[j + 1][i] == true)
                        {
                            result[counter][count] = true;
                        }
                        else
                            result[counter][count] = false;
                        count++;

                    }
                    j++;
                }
                else
                {
                    int count = 0;
                    for (int i = 0; i < roadRegister.Length; i++)
                    {
                        if (!merge.Contains(i))
                        {
                            result[counter][count] = roadRegister[j][i];
                            count++;
                        }
                        else
                        {
                            if (roadRegister[j][i] == true || roadRegister[j][i + 1] == true)
                            {
                                result[counter][count] = true;
                                count++;
                                i++;
                            }
                        }
                    }
                }
            }
            return result;
        }
        bool[][] livingOnTheRoads(bool[][] roadRegister)
        {
            List<Tuple<int, int>> roads = new List<Tuple<int, int>>();

            for (int x = 0; x < roadRegister.Length; x++)
            {
                for (int y = x; y < roadRegister.Length; y++)
                {
                    if (roadRegister[x][y])
                    {
                        roads.Add(new Tuple<int, int>(x, y));
                    }
                }
            }

            bool[][] result = new bool[roads.Count][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new bool[roads.Count];
            }
            for (int i = 0; i < roads.Count; i++)
            {
                int fromA = roads[i].Item1;
                int toA = roads[i].Item2;
                for (int j = 0; j < roads.Count; j++)
                {
                    int fromB = roads[j].Item1;
                    int toB = roads[j].Item2;
                    if (i != j)
                    {
                        if (fromA == toB || fromA == fromB || fromB == toA || fromB == fromA || toB == toA)
                        {
                            result[i][j] = true;
                            result[j][i] = true;
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// https://codefights.com/arcade/graphs-arcade/kingdom-roads
        /// 
        /// Solution to the graph challenges of Contours of Everything from codefights
        /// </summary>
        /// <param name="roadRegister"></param>
        /// <returns></returns>
    }
}
