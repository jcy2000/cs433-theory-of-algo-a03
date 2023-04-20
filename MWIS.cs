using System;
using System.Collections.Generic;

namespace _PA3
{
	public class MWIS : Tree
	{
		public int[] computedSum;
		public bool[] isIncludedSumLarger;
		public bool[] isInSet;

		public MWIS(String filePath) : base(filePath)
		{
			computedSum = new int[numNodes];
			isIncludedSumLarger = new bool[numNodes];
			isInSet = new bool[numNodes];
			for (int i = 0; i < numNodes; i++)
			{
				computedSum[i] = Int32.MinValue;
				isIncludedSumLarger[i] = false;
				isInSet[i] = false;
			}
		}

		public int computeSum(int node)
		{   // complete this function, yes

			// If we've already computed the excl and incl for this node, then just return it
			if (computedSum[node] != Int32.MinValue)
				return computedSum[node];
			
			// Instantiate the excl and incl
			int excl = 0, incl = weights[node];

			// Find the children of the node, needed for finding out the value of excl
			List<int> children = adjList[node];

			foreach (int child in children) {
				excl += computeSum(child);

				// Find the grandchildren of the child, needed for finding out the value of incl
				List<int> grandChildren = adjList[child];

				foreach (int grandChild in grandChildren)
					incl += computeSum(grandChild);
			}

			// If incl is higher, then that's the computedSum for the current node
			if (incl > excl) {
				computedSum[node] = incl;
				isIncludedSumLarger[node] = true;
			}
			// excl is the computedSum for the current node
			else
				computedSum[node] = excl;

			return computedSum[node];
		}

		public void computeSet(int root)
		{   // complete this function, ok sure
			// If the included sum is larger than the excluded sum, then make sure to note that in the isInSet array
			if (isIncludedSumLarger[root])
				isInSet[root] = true;

			// Get the children of the root
			List<int> children = adjList[root];

			// Figure out if the children should be included or not
			foreach (int child in children)
				computeSetHelper(child, root);
		}

		private void computeSetHelper(int node, int parent)
		{   // complete this function, only cause you asked
			if (isIncludedSumLarger[node] && !isInSet[parent])
				isInSet[node] = true;

			// Get the children of the node
			List<int> children = adjList[node];

			// Figure out if the children should be included or not
			foreach (int child in children)
				computeSetHelper(child, node);
		}
	}
}
