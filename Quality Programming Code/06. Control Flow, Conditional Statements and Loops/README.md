# Control Flow, Conditional Statements and Loops Homework

## Task 1. Class Chef in C&#35;
*	Refactor the following class using best practices for organizing straight-line code:

        public class Chef
        {
            private Bowl GetBowl()
            {   
                //... 
            }
			
            private Carrot GetCarrot()
            {
                //...
            }
			
			private Potato GetPotato()
            {
                //...
            }
			
			private void Cut(Vegetable potato)
            {
                //...
            } 
			
            public void Cook()
            {
                Potato potato = GetPotato();
				Peel(potato);
                Cut(potato);
				
                Carrot carrot = GetCarrot();
                Peel(carrot);
                Cut(carrot);
				
                Bowl bowl = GetBowl();
				bowl.Add(potato);
                bowl.Add(carrot);
            }
        }

## Task 2. Refactor the following if statements

    Potato potato;
    //... 
    if (potato != null)
	{
		if(potato.HasBeenPeeled && potato.IsEdible)
		{
			Cook(potato);
		}
	}

and

	var xIsWithinGivenRange = MIN_X <= x && x <= MAX_X;
	var yIsWithinGivenRange = MIN_Y <= y && y <= MAX_Y;
	var paramsAreWithinRange = xIsWithinGivenRange && yIsWithinGivenRange;
    if (paramsAreWithinRange && shouldVisitCell)
    {
       VisitCell();
    }

## Task 3. Refactor the following loop

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

## Task 4*. Refactor your C# 1 exam solutions

*   Using best practices for Variables, Data, Expressions, Constants, Control Flow, Conditional Statements and Loops refactor all your solutions sent during the first C# practical exam this year