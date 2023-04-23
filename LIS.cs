using System;
using System.Collections.Generic;

namespace _PA3
{
    public class LIS
    {
		public static List<int> longestIncreasingSequence(int[] arr, int len)
		{ 	// complete this method, yas
			// Declaring our helper arrays
			int[] length = new int[len];
			int[] pred = new int[len];

			// Set up our length and pred arrays
			for (int i = 0; i < len; i++) {
				// These are out default values
				length[i] = 1;
				pred[i] = -1;

				// Iternate through values before index of i
				for (int j = 0; j < i; j++) {

					// If the value before i is less than index of i and it's length + 1 is greater
					if (arr[j] < arr[i] && length[j] + 1 > length[i]) {
						// We found our new length and pred values for i
						length[i] = length[j] + 1;
						pred[i] = j;
					}
				}
			}

			// Get our index of our highest length
			int lisIndex = 0;
			for (int i = 1; i < length.Length; i++)
				if (length[i] > length[lisIndex])
					lisIndex = i;
			
			// Create a dynamic answer array
			List<int> martin = new List<int>();

			// Fill the answer array
			while(lisIndex >= 0) {
				martin.Add(arr[lisIndex]);
				lisIndex = pred[lisIndex];
			}
			
			reverse(martin);
			return martin;
		}

		private static void reverse(List<int> list)
		{
			for (int i = 0, j = list.Count - 1; i < j; i++, j--)
			{
				int temp = list[j];
				list[j] = list[i];
				list[i] = temp;
			}
		}
	}
}
