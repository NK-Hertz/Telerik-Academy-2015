namespace _4.MyHashTable
{
    using System;
    using System.Collections.Generic;

    public class MyHashTableStartUp
    {
        static void Main()
        {
            var myhashTable = new HashTable<string, int>();
            myhashTable.Add("flosd", 123);
            myhashTable.Add("gosu", 15);
            myhashTable.Add("mush", 15);
            myhashTable.Add("mush", 12);
            myhashTable.Add("mush", 14);

            var keys = myhashTable.Keys;
            Console.WriteLine("Keys: ");
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }

            //var gosu = myhashTable.Find("gosu");
            //Console.WriteLine(gosu);
            //var removedMushSuccessfully = myhashTable.Remove("mush");
            //Console.WriteLine(removedMushSuccessfully);
            //var remocevGosuSuccessfully = myhashTable.Remove("gosu");
            //Console.WriteLine(remocevGosuSuccessfully);

            var firstList = new LinkedList<KeyValuePair<string, int>>();
            firstList.AddLast(new LinkedListNode<KeyValuePair<string, int>>(new KeyValuePair<string, int>("yas", 123)));
            firstList.AddLast(new LinkedListNode<KeyValuePair<string, int>>(new KeyValuePair<string, int>("yan", 12)));
            firstList.AddLast(new LinkedListNode<KeyValuePair<string, int>>(new KeyValuePair<string, int>("yap", 14)));

            myhashTable[0] = firstList;

            Console.WriteLine("Key-value pairs: ");
            foreach (var item in myhashTable)
            {
                Console.WriteLine(item);
            }
        }
    }
}
