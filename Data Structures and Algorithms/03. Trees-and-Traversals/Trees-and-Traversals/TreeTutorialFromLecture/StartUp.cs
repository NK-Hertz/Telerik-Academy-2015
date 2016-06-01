namespace TreeTutorialFromLecture
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var tree = new Tree<int>();

            tree.Add(13);
            tree.Add(18);
            tree.Add(5);
            tree.Add(20);
            tree.Add(15);
            tree.Add(5);
            tree.Add(9);
            tree.Add(3);
            tree.Add(17);
            tree.Add(10);

            foreach (var item in tree)
            {
                Console.WriteLine("{0}", item);
            }

            tree.Remove(13);

            foreach (var item in tree)
            {
                Console.WriteLine("{0}", item);
            }
        }
    }
}
