using System;

public class ExamResult
{
    private static readonly int Min_Grade = 0;
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade 
    {
        get { return this.grade; }
        private set
        {
            if (value < Min_Grade)
            {
                throw new ArgumentOutOfRangeException("Grade can not be lesser than: " + Min_Grade);
            }

            this.grade = value;
        }
    }

    public int MinGrade 
    {
        get { return this.minGrade; }
        private set
        {
            if (value < Min_Grade)
            {
                throw new ArgumentOutOfRangeException("Min Grade can not be smaller than: " + Min_Grade);
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade 
    {
        get { return this.maxGrade; }
        private set
        {
            if (value <= minGrade)
            {
                throw new ArgumentOutOfRangeException("Max Grade can not be smaller or equal to min grade(" + this.MinGrade + ")");
            }

            this.maxGrade = value;
        }
    }

    public string Comments 
    {
        get { return this.comments; }
        private set
        {
            if (value == null )
            {
                throw new ArgumentNullException("Comments can not be null!");
            }

            if (value == String.Empty)
            {
                throw new ArgumentException("Comments can not be empty!");
            }

            this.comments = value;
        }
    }
}
