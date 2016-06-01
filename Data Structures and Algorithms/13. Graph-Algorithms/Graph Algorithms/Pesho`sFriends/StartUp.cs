namespace Pesho_sFriends
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    // Numbers (TV series)
    // CHOPIN - NOCTURNE NO.20 IN C-SHARP MINOR OP.POSTH
    // Etude Tableaux - Моника Паскалева, RockSchool (Rachmaninoff)

    // try with adjacency list - list<keyvaluepair<int, int>[]
    class StartUp
    {
        private static int[] Distance;
        private static HashSet<int> SetOfNodes;

        public static void Dijkstra(int[,] graph, int hospital)
        {
            for (int i = 1; i < graph.GetLength(0); i++)
            {
                Distance[i] = int.MaxValue;
                SetOfNodes.Add(i);
            }

            Distance[hospital] = 0;

            while (SetOfNodes.Count != 0)
            {
                int minNode = int.MaxValue;

                minNode = SetOfNodes.Min();
                foreach (var node in SetOfNodes)
                {
                    if (Distance[minNode] > Distance[node])
                    {
                        minNode = node;
                    }
                }

                SetOfNodes.Remove(minNode);

                for (int i = 0, len = graph.GetLength(0); i < len; i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int potentialDistance = Distance[minNode] + graph[minNode, i];
                        if (potentialDistance < Distance[i])
                        {
                            Distance[i] = potentialDistance;
                        }
                    }
                }
            }
        }

        static void Main()
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            // N
            var numberOfPoints = input[0];
            // M
            var numberOfStreets = input[1];
            // H
            var numberOfHospitals = input[2];

            // H numbers
            var pointsHospitalInput = Console.ReadLine(); 
            
            // M numbers
            var streets = new int[numberOfStreets, 3];
            for (int i = 0; i < numberOfStreets; i++)
            {
                var currentStreet = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0, len = streets.GetLength(1); j < len; j++)
                {
                    streets[i, j] = currentStreet[j];
                }
            }

            var graph = new int[numberOfPoints + 1, numberOfPoints + 1];
            for (int i = 1; i <= numberOfPoints; i++)
            {
                for (int j = 1; j <= numberOfPoints; j++)
                {
                    for (int k = 0; k < numberOfStreets; k++)
                    {
                        if (i == streets[k, 0] && j == streets[k, 1])
                        {
                            graph[i, j] = streets[k, 2];
                            graph[j, i] = streets[k, 2];
                        }
                    }
                }
            }

            var minMoves = int.MaxValue;

            for (int i = 0; i < numberOfHospitals; i++)
            {
                Distance = new int[graph.GetLength(0)];
                SetOfNodes = new HashSet<int>();

                List<int> hospitals = new List<int>();

                if (numberOfHospitals == 1)
                {
                    hospitals.Add(int.Parse(pointsHospitalInput));
                    Dijkstra(graph, hospitals[0]);
                }
                else
                {
                    //Console.WriteLine(pointsHospitalInput.Length);
                    hospitals = pointsHospitalInput.Split(' ').Select(int.Parse).ToList();
                    Dijkstra(graph, hospitals[i]);
                }

                foreach (var hospital in hospitals)
                {
                    Distance[hospital] = 0;
                }

                int currentMinMoves = Distance.Sum();

                if (currentMinMoves < minMoves)
                {
                    minMoves = currentMinMoves;
                }
            }

            Console.WriteLine(minMoves);
        }
    }
}
