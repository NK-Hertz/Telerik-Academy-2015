using System;
// Task 2. Method PrintStatistics in C&#35;
public double GetMaxNumber(double[] collecton, int count)
{
	double max = collection[0];
    for (int i = 0; i < count; i++)
    {
        if (collection[i] > max)
        {
            max = collection[i];
        }
    }
			
	return max;
}

public double GetMinNumber(double[] collection, int count)
{
	double min = collection[0];
    for (int i = 0; i < count; i++)
    {
        if (collection[i] < min)
        {
            min = collection[i];
        }
    }
			
	return min;
}
		
public double GetAverageValue(double[] collection, int count);
{
	double sum = 0;
    for (int i = 0; i < count; i++)
    {
        sum += collection[i];
    }
			
	double average = sum / count;
			
	return average;
}
		
public void PrintStatisticsForFirstNElements(double[] collection, int count)
{
	var max = GetMaxNumber(collection, count);
    PrintMax(max);
           
	var min = GetMinNumber(collection, count);
    PrintMin(min);

    var average = GetAverageValue(collection, count);
    PrintAverage(average);
}