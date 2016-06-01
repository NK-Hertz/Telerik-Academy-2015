    namespace ColorfulRabbits
    {
        using System;
        using System.Collections.Generic;
    
        public class ColorfulRabbits
        {
            private static int minimumNumberOfRabbits;

            public static void Main()
            {
                minimumNumberOfRabbits = 0;
                int numberOfRabbitsAsked = int.Parse(Console.ReadLine());
                var rabbitAnswers = new List<int>();
                for (int i = 0; i < numberOfRabbitsAsked; i++)
                {
                    rabbitAnswers.Add(int.Parse(Console.ReadLine()));
                }

                CountRabbits(rabbitAnswers);
            }

            private static void CountRabbits(List<int> answers)
            {
                if (answers.Count == 0)
                {
                    Console.WriteLine(minimumNumberOfRabbits);
                }
                else
                {
                    var currentAnswerCount = 1;
                    var currentAnswer = answers[0];
                    if (currentAnswer != 0)
                    {
                        for (int i = 1; i < answers.Count; i++)
                        {
                            if (currentAnswer == answers[i])
                            {
                                currentAnswerCount++;
                                if (currentAnswerCount == currentAnswer + 1)
                                {
                                    break;
                                }
                            }
                        }
                    }

                    if (answers.Count == 1)
                    {
                        minimumNumberOfRabbits += (currentAnswer + 1);
                        answers.Remove(currentAnswer);
                    }
                    else
                    {
                        minimumNumberOfRabbits += (currentAnswer + 1);
                        for (int i = 0; i < currentAnswerCount; i++)
                        {
                            answers.Remove(currentAnswer);
                        }
                    }

                    CountRabbits(answers);
                }
            }
        }
    }
