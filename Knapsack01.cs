using System;
using System.Collections.Generic;
namespace _PA3
{
	public class Knapsack01
	{
		public static int findOptimalProfit(int[] profits, int[] weights, int numElements, int capacity)
		{ 	// complete this function, yeah...
			// Initialize the memorization dictionary. Set to nothing -> there's nothing to memorize just yet
			Dictionary<int, int> weightsToProfitsPrev = new Dictionary<int, int>();

			// Add our default weight of 0 (which, of course, has a profit of 0)
			weightsToProfitsPrev[0] = 0;

			// Keeping track of our max possible profit
			int max = Int32.MinValue;

			for (int i = 0; i < numElements; i++) {
				// Make another memorization dictionary, for transferring reasons
				Dictionary<int, int> weightsToProfitsCurr = new Dictionary<int, int>();
				IEnumerator<int> it = weightsToProfitsPrev.Keys.GetEnumerator();

				// Transfer memorization values
				while(it.MoveNext()) {
					int w = it.Current, p = weightsToProfitsPrev[w];
					weightsToProfitsCurr[w] = p;
				}

				// Loop through what we've memorized already
				it = weightsToProfitsPrev.Keys.GetEnumerator();
				while(it.MoveNext()) {
					// Get weight and profit from a memorized weight/profit pair
					int w = it.Current, p = weightsToProfitsPrev[w];

					// Weight from a new item to our current weight
					int weightNew = w + weights[i];

					// If we have too much weight, then continue to the next memorized weight/profit pair
					if (weightNew > capacity)
						continue;
					
					// Profit from a new item to our current profit
					int profitNew = p + profits[i];

					// If we've already found a solution with the new weight
					if (weightsToProfitsCurr.ContainsKey(weightNew)) {
						int profitExisting = weightsToProfitsCurr[weightNew];

						// If our profit that we found was better than what we found before with the same weight
						if (profitExisting < profitNew)
							weightsToProfitsCurr[weightNew] = profitNew;
					}
					// We haven't found a solution for the new weight, so add it
					else
						weightsToProfitsCurr[weightNew] = profitNew;

					// If the profit for the current solution is higher than our max profit so far
					if (max < profitNew)
						max = profitNew;
				}

				// We finished our calculations when adding the new item, so update our memorization dictionary
				weightsToProfitsPrev = weightsToProfitsCurr;
			}

			return max;
		}
	}
}
