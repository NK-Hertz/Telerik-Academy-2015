// Task 2. Refactor the following if statements

Potato potato;
//... 
if (potato != null)
{
	if(potato.HasBeenPeeled && potato.IsEdible)
	{
		Cook(potato);
	}
}

// and

var xIsWithinGivenRange = MIN_X <= x && x <= MAX_X;
var yIsWithinGivenRange = MIN_Y <= y && y <= MAX_Y;
var paramsAreWithinRange = xIsWithinGivenRange && yIsWithinGivenRange;
if (paramsAreWithinRange && shouldVisitCell)
{
    VisitCell();
}