namespace OfficeSpace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    // check if order of tasks has the reight index for cost ?
    public class StartUp
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var costs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            // or List<int>[N]
            var dependencies = new List<int>[N + 1];
            //var set = new SortedSet<int>();
            for (int i = 1; i < dependencies.Length; i++)
            {
                var currentDependencies = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                //dependencies[i] = new s
                foreach (var dep in currentDependencies)
                {
                    if (dependencies[i] == null)
                    {
                        dependencies[i] = new List<int>();
                    }

                    dependencies[i].Add(dep);
                }
            }
            
            var minTimeNeeded = CalculateMinimumMinutesNeeded(costs, dependencies);
            Console.WriteLine(minTimeNeeded);
        }

        private static long CalculateMinimumMinutesNeeded(int[] costs, List<int>[] dependencies)
        {
            var areTasksIndependent = true;
            var areTaskImpossible = true;
            long minimumTimeNeeded = 0;

            for (int i = 0; i < dependencies.Length; i++)
            {
                foreach (var subdependency in dependencies[i])
                {
                    if (subdependency != 0)
                    {
                        areTasksIndependent = false;
                        //break;
                    }
                    else
                    {
                        // will be repeated unnecessary amount of times
                        areTaskImpossible = false;
                    }
                }
            }

            if (areTasksIndependent)
            {
                minimumTimeNeeded = costs[0];
                for (int i = 1; i < costs.Length; i++)
                {
                    if (minimumTimeNeeded < costs[i])
                    {
                        minimumTimeNeeded = costs[i];
                    }
                }
            }
            else
            {
                if (areTaskImpossible)
                {
                    minimumTimeNeeded = -1;
                }
                else
                {
                    var sortedDependencies = TopologicalSort(dependencies);
                    
                    // under construction
                    //var resultCosts = ....??????
                    //// now the fun starts
                    //// count of zeros ?       
                    //// Max from zeros and the given time for the dependent
                    //// 0 - 0 - 1 2 = Max(4, 8) + 16 = 24

                    //var resultCosts = new long[costs.Length];
                    //for (int i = 0; i < dependencies.Length; i++)
                    //{
                    //    if (dependencies[i].Count > 1)
                    //    {
                    //        long currentCost = 0;
                    //        foreach (var dep in dependencies[i])
                    //        {
                    //            currentCost += costs[dep - 1];
                    //        }

                    //        //resultCosts[i] = Math.Min(costs[i], currentCost);
                    //        resultCosts[i] = costs[i];
                    //    }
                    //    else
                    //    {
                    //        if (dependencies[i].First() == 0)
                    //        {
                    //            resultCosts[i] = 0;
                    //        }
                    //        else
                    //        {
                    //            resultCosts[i] = costs[i];
                    //        }
                    //    }
                    //}

                    //var anyIndependentTasksLeft = false;
                    //var independentTasks = new List<int>();
                    //for (int i = 0; i < resultCosts.Length; i++)
                    //{
                    //    // multidependent task ?
                    //    if (dependencies[i].First() == 0)
                    //    {
                    //        anyIndependentTasksLeft = true;
                    //        independentTasks.Add(i);
                    //    }
                    //}

                    //if (anyIndependentTasksLeft)
                    //{
                    //    var maxTimeForIndependentTasks = costs[independentTasks.First()];
                    //    foreach (var task in independentTasks)
                    //    {
                    //        if (maxTimeForIndependentTasks < costs[task])
                    //        {
                    //            maxTimeForIndependentTasks = costs[task];
                    //        }
                    //    }

                    //    minimumTimeNeeded = resultCosts.Sum();
                    //    minimumTimeNeeded += maxTimeForIndependentTasks;
                    //}
                    //// useless
                    //else
                    //{
                    //    minimumTimeNeeded = resultCosts.Sum();
                    //}
                }
            }

            return minimumTimeNeeded;
        }

        private static IList<int> TopologicalSort(List<int>[] graph)
        {
            var sorted = new List<int>();
            var visited = new Dictionary<int, bool>();
            for (var i = 1; i < graph.Length; i++)
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
    }
}
