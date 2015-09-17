# Variables, Data, Expressions and Constants Homework

## Task 1. Class Size in C&#35;
*	Refactor the following code to use proper variable naming and simplified expressions:

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


## Task 2. Method PrintStatistics in C&#35;
*	Refactor the following code to apply variable usage and naming best practices:
		
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