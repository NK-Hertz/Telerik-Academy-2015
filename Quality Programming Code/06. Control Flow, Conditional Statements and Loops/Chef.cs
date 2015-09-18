using System;

// Task 1. Class Chef in C&#35;

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
