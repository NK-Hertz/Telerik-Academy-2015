using System;

public class CSharpExam : Exam
{
    private static readonly int Min_Score = 0;
    private static readonly int Max_Score = 100;
    private int score;
   
    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score 
    {
        get { return this.score; }
        private set
        {
            if (value < Min_Score || Max_Score < value)
            {
                throw new ArgumentOutOfRangeException("Score can not be smaller than: " + Min_Score + " or bigger than: " + Max_Score);
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, Min_Score, Max_Score, "Exam results calculated by score.");
    }
}
