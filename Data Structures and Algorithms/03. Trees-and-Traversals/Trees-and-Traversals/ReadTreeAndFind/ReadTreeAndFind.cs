namespace ReadTreeAndFind
{
    using System;
    using System.Collections.Generic;

    public class ReadTreeAndFind
    {
        static void Main()
        {
            //Console.WriteLine("Enter number of nodes: ");
            //var numberOfNodes = int.Parse(Console.ReadLine());

            //for (int i = 0, len = numberOfNodes; i < len; i++)
            //{
            //    Console.WriteLine("Parent: ");
            //    var key = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Child: ");
            //    var value = int.Parse(Console.ReadLine());
            //    nodes.Add(key, value);
            //}

            var parents = new List<int>();
            var children = new List<int>();
            parents.Add(2);
            children.Add(4);

            parents.Add(3);
            children.Add(2);

            parents.Add(5);
            children.Add(0);

            parents.Add(3);
            children.Add(5);

            parents.Add(5);
            children.Add(6);

            parents.Add(5);
            children.Add(1);

            parents.Add(4);
            children.Add(7);

            var tree = new Tree<int>();

            while (parents.Count > 0)
            {
                var rootElements = GetTopParentNodes(parents, children);

                foreach (var root in rootElements)
                {
                    Console.WriteLine(root);
                    var rootChildren = GetChildrenOf(root, parents, children);
                    foreach (var child in rootChildren)
                    {
                        tree.Add(root, child);
                    }

                    var index = 0;
                    while (parents.Contains(root))
                    {
                        parents.Remove(root);
                        children.Remove(rootChildren[index]);
                        index++;
                    }
                }
            }
            // TO DO:
            // get the root - add HasPerant prop
            // each element 
            // middle nodes = as of row? - add counter, when end is reached traverse till end/2 - cycle
            // traverse through tree with counter depth, save it, and if any deeper branch is found, replace the saved one
            Console.WriteLine();
        }

        public static List<int> GetChildrenOf(int rootParent, List<int> allParents, List<int> allChildren)
        {
            var childrenOfParent = new List<int>();

            for (int i = 0, len = allParents.Count ; i < len; i++)
            {
                if (allParents[i] == rootParent)
                {
                    childrenOfParent.Add(allChildren[i]);
                }
            }

            return childrenOfParent;
        }

        public static List<int> GetTopParentNodes(List<int> allParents, List<int> allChildren)
        {
            var topParents = new List<int>();

            foreach (var parent in allParents)
            {
                bool parentHasParent = false;
                foreach (var child in allChildren)
                {
                    if (parent == child)
                    {
                        parentHasParent = true;
                        break;
                    }
                }

                if (parentHasParent == false)
                {
                    if (!topParents.Contains(parent))
                    {
                        topParents.Add(parent);
                    }
                }
            }

            return topParents;
        }
    }
}
