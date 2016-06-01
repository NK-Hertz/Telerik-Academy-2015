## Data Structures, Algorithms and Complexity Homework

1. **What is the expected running time of the following C# code?**
  - Explain why using Markdown.
  - Assume the array's size is `n`.

  ```cs
  long Compute(int[] arr)
  {
      long count = 0;
      for (int i=0; i<arr.Length; i++)
      {
          int start = 0, end = arr.Length-1;
          while (start < end)
              if (arr[start] < arr[end])
                  { start++; count++; }
              else 
                  end--;
      }
      return count;
  }
  ```
 
  **Answer:**
  Looping from 0 to arr.Length gives us 'n'. The while loop also gives us 'n' since it goes from start = 0,
  same as before and end = arr.Length - 1, again same as before. But because the while is nested in the for 
  loop we get multiplication between the 'n's.
  
  The equation looks like this: 
  _n*n = n^2_

2. **What is the expected running time of the following C# code?**
  - Explain why using Markdown.
  - Assume the input matrix has size of `n * m`.

  ```cs
  long CalcCount(int[,] matrix)
  {
      long count = 0;
      for (int row=0; row<matrix.GetLength(0); row++)
          if (matrix[row, 0] % 2 == 0)
              for (int col=0; col<matrix.GetLength(1); col++)
                  if (matrix[row,col] > 0)
                      count++;
      return count;
  }
  ```
  
  **Answer:**
  We have two loops, one of which is nested so we have multiplication between their values. First itterates 
  through all its elements, but only steps inside the if at 'n'/2 times at average and 'n' times at worst. 
  For each time the if clause is satisfied it itterates 'm' times.
  
  The equation looks like this: 
  _n * m_ || _ (n / 2) * m_

3. **(*) What is the expected running time of the following C# code?**
  - Explain why using Markdown.
  - Assume the input matrix has size of `n * m`.

  ```cs
  long CalcSum(int[,] matrix, int row)
  {
      long sum = 0;
      for (int col = 0; col < matrix.GetLength(0); col++) 
          sum += matrix[row, col];
      if (row + 1 < matrix.GetLength(1)) 
          sum += CalcSum(matrix, row + 1);
      return sum;
  }
  
  Console.WriteLine(CalcSum(matrix, 0));
  ```

  **Answer:**
  After formatting the code in the method will look like
  
  ```cs
	for (int col = 0; col < matrix.GetLength(0); col++)
	{
		sum += matrix[row, col];
	}
	
	if (row + 1 < matrix.GetLength(1)) 
	{
		sum += CalcSum(matrix, row + 1);
	}
    
	return sum;
  ```
  
  The code will sum each time the check clause in the for loop is satisfied. The check clause checks if 
  the **int col** value is lesser than **matrix.GetLength(0)** = n(the length of the first dimension of the array). 
  So basicly we are doing a loop until we reach n. The if clause if satisfied is executed once but recursively and 
  then the result of the sum returned. 
  
  The equation looks like: 
  _for n = m => n * (m - 1)_
  
  _for n < m || n > m => n * min(n, m)_ cuz of index out of range