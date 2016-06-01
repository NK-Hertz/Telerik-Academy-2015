namespace BiDictionaryTask
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            // for keys from the same type it(find) doesn`t work
            var myDict = new BiDictionary<string, int, int>();
            var twitchKeyWord = "twitch";
            var threeKeyWord = 3;
            myDict.Add(twitchKeyWord, threeKeyWord, 1);
            myDict.Add(twitchKeyWord, threeKeyWord, 2);
            myDict.Add(twitchKeyWord, threeKeyWord, 3);

            var registerKeyWord = "register";
            var fourKeyWord = 4;
            myDict.Add(registerKeyWord, fourKeyWord, 1);
            myDict.Add(registerKeyWord, fourKeyWord, 2);
            myDict.Add(registerKeyWord, fourKeyWord, 3);
            myDict.Add(registerKeyWord, fourKeyWord, 4);
            myDict.Add(registerKeyWord, fourKeyWord, 5);

            //var resultFromFirstKeySearch = myDict.Find(myDictFirstSectionFirstKey);
            //Console.WriteLine(resultFromFirstKeySearch.Count);

            var myOtherDict = new BiDictionary<string, int, int>();
            var baseKeyWord = "base";
            var oneKeyNumber = 1;
            myOtherDict.Add(baseKeyWord, oneKeyNumber, 1);
            myOtherDict.Add(baseKeyWord, oneKeyNumber, 2);
            myOtherDict.Add(baseKeyWord, oneKeyNumber, 3);
            myOtherDict.Add(baseKeyWord, oneKeyNumber, 4);

            var airKeyWord = "air";
            var twoKeyNumber = 2;
            myOtherDict.Add(airKeyWord, twoKeyNumber, 1);
            myOtherDict.Add(airKeyWord, twoKeyNumber, 17);
            myOtherDict.Add(airKeyWord, twoKeyNumber, 3);
            myOtherDict.Add(airKeyWord, twoKeyNumber, 5);
            myOtherDict.Add(airKeyWord, twoKeyNumber, 11);

            var resultFromOneKeyWordSearch = myOtherDict.Find(airKeyWord);
            Console.WriteLine(string.Join(", ", resultFromOneKeyWordSearch));

            var resultFromTwoKeyWordsSearch = myOtherDict.Find(airKeyWord, twoKeyNumber);
            Console.WriteLine(string.Join(", ", resultFromTwoKeyWordsSearch));

            // throws error
            //var resultFromTwoKeyWordSearchWrongSecondKey = myOtherDict.Find(airKeyWord, fourKeyWord);
        }
    }
}
