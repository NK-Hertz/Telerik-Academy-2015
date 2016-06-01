namespace _5.MyHashSet
{
    using System;

    public class MyHashSetStartUp
    {
        static void Main()
        {
            var mySet = new HashedSet<string>();
            mySet.Add("string");
            mySet.Add("str");
            //mySet.Add(null);
            mySet.Add("strength");
            mySet.Add("string");

            //var strength = mySet.Find("strength");
            //Console.WriteLine(strength);

            //var isStringRemoved = mySet.Remove("string");
            //Console.WriteLine(isStringRemoved);

            var mySecondSet = new HashedSet<string>();
            mySecondSet.Add("strength");
            mySecondSet.Add("dexterity");
            mySecondSet.Add("intelligence");

            mySet.Union(mySecondSet);
            //mySet.Intersect(mySecondSet);
            foreach (var item in mySet)
            {
                Console.WriteLine(item);
            }
        }
    }
}
