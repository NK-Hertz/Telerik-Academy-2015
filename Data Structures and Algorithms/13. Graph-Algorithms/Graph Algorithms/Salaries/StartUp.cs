namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class StartUp
    {
        public static void Main()
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());
            var symbols = new string[numberOfEmployees];
            for (int i = 0; i < numberOfEmployees; i++)
            {
                symbols[i] = Console.ReadLine();
            }

            var graph = new List<int>[numberOfEmployees];
            for (int i = 0; i < numberOfEmployees; i++)
            {
                for (int j = 0; j < numberOfEmployees; j++)
                {
                    if (symbols[i][j] == 'Y')
                    {
                        if (graph[i] == null)
                        {
                            graph[i] = new List<int>();
                        }

                        graph[i].Add(j);
                    }
                }
            }

            var sorted = TopologicalSort(graph);
            var result = CalculateTotalSumOfSalaries(sorted, graph);
            Console.WriteLine(result);
        }

        private static IList<int> TopologicalSort(List<int>[] graph)
        {
            var sorted = new List<int>();
            var visited = new Dictionary<int, bool>();
            for (var i=0; i < graph.Length; i++)
            {
                Visit(i, graph, graph[i], sorted, visited);
            }

            return sorted;
        }

        private static void Visit(int item, List<int>[] graph, List<int> dependencies, List<int> sorted, Dictionary<int, bool> visited)
        {
            bool inProcess;
            var alreadyVisited = visited.TryGetValue(item, out inProcess);
            if (alreadyVisited)
            {
                if (inProcess)
                {
                    throw new ArgumentException("Cyclic dependency found");
                }
            }
            else
            {
                visited[item] = true;

                if (dependencies != null)
                {
                    foreach (var dependency in dependencies)
                    {
                        Visit(dependency, graph, graph[dependency], sorted, visited);
                    }
                }

                visited[item] = false;
                sorted.Add(item);
            }
        }

        private static long CalculateTotalSumOfSalaries(IList<int> sorted, List<int>[] graph)
        {
            var salaries = new long[graph.Length];
            for (int item = 0; item < sorted.Count; item++)
            {
                if (graph[sorted[item]] == null)
                {
                    salaries[sorted[item]] = 1;
                }
                else
                {
                    var dependencyIndex = 0;
                    long sumOfDependenciesSalaries = 0;
                    while (graph[sorted[item]] != null && dependencyIndex < graph[sorted[item]].Count)
                    {
                        sumOfDependenciesSalaries += salaries[graph[sorted[item]][dependencyIndex]];
                        dependencyIndex++;
                    }

                    salaries[sorted[item]] = sumOfDependenciesSalaries;
                }
            }

            return salaries.Sum();
        }
    }
}
