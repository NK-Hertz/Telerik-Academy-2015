using System;
// Task 1. Class Size in C&#35;

public class Size
{
    private double width;
	private double height;
			
    public Size(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }
			
	public double Width
	{
		get
		{
			return this.width;
		}
		set
		{
			this.width = value;
		}
	}
	public double Height
	{
		get
		{
			return this.height;
		}
		set
		{
			this.height = value;
		}
	}
			
    public static Size GetRotatedSize(Size size, double angle)
    {
		var absoluteValueOfCosineOfAngle = Math.Abs(Math.Cos(angle));
		var absoluteValueOfSineOfAngle = Math.Abs(Math.Sin(angle));
		var rotatedWidth = (absoluteValueOfCosineOfAngle * size.Width) + 
                (absoluteValueOfSineOfAngle * size.Height);
		var rotatedHeight = (absoluteValueOfSineOfAngle *size.Width) + 
                (absoluteValueOfCosineOfAngle * size.Height);
        return new Size(rotatedWidth, rotatedHeight);
    }
}
