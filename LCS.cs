using System;
namespace _PA3
{
	public class LCS
	{
		public static String longestCommonSubsequence(String x, String y)
		{   // complete this function
			// Get length of the x and y string
			int lenx = x.Length, leny = y.Length;

			// Creating sumthing that we will use
			int[,] length = new int[lenx + 1, leny + 1];

			for (int i = 0; i <= lenx; i++)
				length[i, 0] = '\0';

			for (int j = 0; j <= leny; j++)
				length[0, j] = '\0';

			for (int i = 1; i <= lenx; i++)
				for (int j = 1; j <= leny; j++) {
					if (x[i - 1] == y[j - 1])
						length[i, j] = length[i - 1, j - 1] + 1;
					else if (length[i - 1, j] > length[i, j - 1])
						length[i, j] = length[i - 1, j];
					else
						length[i, j] = length[i, j - 1];
				}

			String answer = "";

			while (lenx > 0 && leny > 0) {
				if (x[lenx - 1] == y[leny - 1]) {
					answer += x[lenx - 1];
					lenx--; leny--;
				}
				else if (length[lenx - 1, leny] > length[lenx, leny - 1])
					lenx--;
				else
					leny--;
			}

			return reverse(answer);
		}

		private static String reverse(String str)
		{
			String rev = "";
			for (int i = str.Length - 1; i >= 0; i--)
			{
				rev += str[i];
			}
			return rev;
		}
	}
}
