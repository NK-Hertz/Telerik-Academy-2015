using System;

public class SimpleMathExam : Exam
{
    private static readonly int Min_Problems_Solved = 0;
    private static readonly int Max_Problems_Solved = 10;
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved 
    {
        get { return this.problemsSolved; }
        private set
        {
            if (value < Min_Problems_Solved)
            {
                value = Min_Problems_Solved;
            }
            if (value > Max_Problems_Solved)
            {
                value = Max_Problems_Solved;
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
    }
}
