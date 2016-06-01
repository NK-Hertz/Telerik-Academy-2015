namespace Pesho_sFriendsAdjacencyList
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class StartUp
    {
        private static List<KeyValuePair<int, int>>[] Graph;
        private static int[] Distance;

        private static void Dijkstra(List<KeyValuePair<int, int>>[] graph, int hospital)
        {
            var nodes = new Queue<KeyValuePair<int, int>>();
            nodes.Enqueue(new KeyValuePair<int, int>(hospital, 0));

            for (int i = 1, len = Distance.Length; i < len; i++)
            {
                Distance[i] = int.MaxValue;
            }

            Distance[hospital] = 0;

            while (nodes.Count != 0)
            {
                var minDistanceNode = nodes.Dequeue();

                foreach (var neighbour in graph[minDistanceNode.Key])
                {
                    var currentDistance = Distance[minDistanceNode.Key] + neighbour.Value;
                    if (currentDistance >= Distance[neighbour.Key])
                    {
                        continue;
                    }

                    Distance[neighbour.Key] = currentDistance;
                    nodes.Enqueue(new KeyValuePair<int, int>(neighbour.Key, currentDistance));
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

            Graph = new List<KeyValuePair<int, int>>[numberOfPoints + 1];
            for (int i = 0; i < numberOfStreets; i++)
            {
                if (Graph[streets[i, 0]] == null)
                {
                    Graph[streets[i, 0]] = new List<KeyValuePair<int, int>>();
                }

                if (Graph[streets[i, 1]] == null)
                {
                    Graph[streets[i, 1]] = new List<KeyValuePair<int, int>>();
                }

                Graph[streets[i, 0]].Add(new KeyValuePair<int, int>(streets[i, 1], streets[i, 2]));
                Graph[streets[i, 1]].Add(new KeyValuePair<int, int>(streets[i, 0], streets[i, 2]));
            }

            var minMoves = int.MaxValue;

            for (int i = 0; i < numberOfHospitals; i++)
            {
                Distance = new int[Graph.GetLength(0)];

                List<int> hospitals = new List<int>();

                if (numberOfHospitals == 1)
                {
                    hospitals.Add(int.Parse(pointsHospitalInput));
                    Dijkstra(Graph, hospitals[0]);
                }
                else
                {
                    //Console.WriteLine(pointsHospitalInput.Length);
                    hospitals = pointsHospitalInput.Split(' ').Select(int.Parse).ToList();
                    Dijkstra(Graph, hospitals[i]);
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
