public class Solution {
    public double FindMedianSortedArrays(int[] a, int[] b)
    {
        int totalLength = a.Length + b.Length;
        int answerIndex1 = (totalLength - 1) / 2;
        int answerIndex2 = (totalLength / 2);
        if (a.Length == 0)
        {
            return (b[answerIndex1] + b[answerIndex2]) / 2.0;
        }
        if (b.Length == 0)
        {
            return (a[answerIndex1] + a[answerIndex2]) / 2.0;
        }
        return (GetNthFrom2Arrays(a, b, answerIndex1) + GetNthFrom2Arrays(a, b, answerIndex2)) / 2.0;
    }

    public int GetNthFrom2Arrays(int[] a, int[] b, int index)
    {
        int left = 0;
        int right = a.Length - 1;
        while (true)
        {
            int currentIndexA = (left + right) / 2;
            int j = index - currentIndexA - 1;

            if (j >= b.Length)
            {
                left = currentIndexA + 1; // j too big, search right part (cA increase then j decrease)
            }
            else if (j < -1)
            {
                right = currentIndexA - 1;
            }
            else if (j == -1)
            {
                if (a[currentIndexA] <= b[0])
                {
                    return a[currentIndexA];
                }
                else
                {
                    right = currentIndexA - 1;
                }
            }
            else // j valid
            {
                if (a[currentIndexA] >= b[j])
                {
                    // if a[cA] >= b[j]  && a[cA] <= b[j+1], then a[cA] is the answer
                    if (j == b.Length - 1 || a[currentIndexA] <= b[j + 1])
                    {
                        return a[currentIndexA];
                    }
                    else // a[cA] is greater than answer
                    {
                        // find in left part in a[]
                        right = currentIndexA - 1;
                    }
                }
                else // a[cA] is smaller than answer
                {
                    // find in right part in a[]
                    left = currentIndexA + 1;
                }
            }

            if (left > right) // answer not in a
            {
                return GetNthFrom2Arrays(b, a, index);
            }
        }
    }
}
