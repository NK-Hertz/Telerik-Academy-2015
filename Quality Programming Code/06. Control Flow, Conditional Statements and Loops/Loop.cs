// Task 3. Refactor the following loop

for (int i = 0; i < 100; i++) 
{
	var currentValue = array[i];
	Console.WriteLine(currentValue);
	var isITens = i % 10 == 0;
	if (isITens)
	{			
		var isCurrentValueEqualToExpected = array[i] == expectedValue;
		if (isCurrentValueEqualToExpected) 
		{
			Console.WriteLine("Value Found");
		}
	}
}