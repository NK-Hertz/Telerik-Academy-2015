namespace UnitsOfWork
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ReverseComparer<T> : Comparer<T>
    {
        private Comparer<T> inputComparer;
        public ReverseComparer(Comparer<T> inputComparer)
        {
            this.inputComparer = inputComparer;
        }

        public override int Compare(T x, T y)
        {
            return inputComparer.Compare(y, x);
        }
    }

    public class Unit : IComparable<Unit>
    {
        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Attack { get; set; }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }

        public int CompareTo(Unit other)
        {
            //var result = 0;
            //if (this.Attack > other.Attack)
            //{
            //    result = -1;
            //}
            //else if (this.Attack < other.Attack)
            //{
            //    result = 1;
            //}
            //else
            //{
            //    result = 0;
            //}

            //return result;

            return this.Name.CompareTo(other.Name);
        }
    }

    public class StartUp
    {
        public static void Main()
        {
            var sb = new StringBuilder();
            var unitNames = new HashSet<string>();
            var allUnits = new List<Unit>();
            var unitsSortedByType = new Dictionary<string, List<Unit>>();
            //var powerOverwhelming = new OrderedBag<Unit>();
            var powerOverwhelming = new OrderedDictionary<int, SortedSet<Unit>>(new ReverseComparer<int>(Comparer<int>.Default));

            var parameters = Console.ReadLine().Split(' ').ToArray();
            while (parameters.Length != 3 && parameters[0] != "end")
            {
                switch (parameters[0])
                {
                    case "add":
                        var currentUnit = new Unit(parameters[1], parameters[2], int.Parse(parameters[3]));

                        if (!unitNames.Contains(currentUnit.Name))
                        {
                            if (!unitsSortedByType.ContainsKey(currentUnit.Type))
                            {
                                unitsSortedByType[currentUnit.Type] = new List<Unit>();
                            }

                            if (!powerOverwhelming.ContainsKey(currentUnit.Attack))
                            {
                                powerOverwhelming[currentUnit.Attack] = new SortedSet<Unit>();
                            }

                            powerOverwhelming[currentUnit.Attack].Add(currentUnit);
                            unitsSortedByType[currentUnit.Type].Add(currentUnit);
                            unitNames.Add(currentUnit.Name);
                            allUnits.Add(currentUnit);

                            sb.AppendFormat("SUCCESS: {0} added!", currentUnit.Name);
                        }
                        else
                        {
                            sb.AppendFormat("FAIL: {0} already exists!", currentUnit.Name);
                        }

                        sb.AppendLine();

                        break;
                    case "remove":
                        var unitNameToRemove = parameters[1];
                        if (unitNames.Contains(unitNameToRemove))
                        {
                            var removedUnit = allUnits.Where(x => x.Name == unitNameToRemove).First();

                            unitNames.Remove(unitNameToRemove);
                            allUnits.Remove(removedUnit);
                            unitsSortedByType[removedUnit.Type].Remove(removedUnit);
                            powerOverwhelming[removedUnit.Attack].Remove(removedUnit);

                            sb.AppendFormat("SUCCESS: {0} removed!", unitNameToRemove);
                        }
                        else
                        {
                            sb.AppendFormat("FAIL: {0} could not be found!", unitNameToRemove);
                        }

                        sb.AppendLine();

                        break;
                    case "power":
                        var numberOfUnits = int.Parse(parameters[1]);
                        sb.Append("RESULT: ");

                        var currentNumberOfUnits = 0;
                        while (currentNumberOfUnits < numberOfUnits)
                        {
                            foreach (var pair in powerOverwhelming)
                            {
                                var value = pair.Value;
                                foreach (var val in value)
                                {
                                    if (currentNumberOfUnits < numberOfUnits)
                                    {
                                        sb.AppendFormat("{0}", val);

                                        if (currentNumberOfUnits != numberOfUnits - 1)
                                        {
                                            sb.Append(", ");
                                        }

                                        currentNumberOfUnits++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                if(currentNumberOfUnits == numberOfUnits)
                                {
                                    break;
                                }
                            }
                        }

                        sb.AppendLine();

                        break;
                    case "find":
                        sb.Append("RESULT: ");

                        if (unitsSortedByType.ContainsKey(parameters[1]))
                        {
                            var result = unitsSortedByType[parameters[1]].OrderByDescending(x => x.Attack).ThenBy(x => x.Name)
                                .Take(10).ToList();

                            var totalUnitsNeeded = 0;
                            while (totalUnitsNeeded < result.Count)
                            {
                                foreach (var unit in result)
                                {
                                    sb.AppendFormat("{0}", unit);

                                    if (totalUnitsNeeded != result.Count - 1)
                                    {
                                        sb.Append(", ");
                                    }

                                    totalUnitsNeeded++;
                                }
                            }
                        }

                        sb.AppendLine();

                        break;
                    default:
                        parameters = Console.ReadLine().Split(' ').ToArray();
                        break;
                }

                parameters = Console.ReadLine().Split(' ').ToArray();
            }

            Console.WriteLine(sb.ToString());
            //System.IO.File.WriteAllText(@"D:\WriteText.txt", sb.ToString());
        }
    }
}
