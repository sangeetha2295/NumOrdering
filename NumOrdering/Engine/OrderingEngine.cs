using NumOrdering.Contract;

namespace NumOrdering.Engine
{
    public class OrderingEngine : IOrderingEngine
    {
        public IList<int> SortBubble(IList<int> num, int count)
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = count; j > i; j--)
                {
                    if (((IComparable)num[j - 1]).CompareTo(num[j]) > 0)
                    {
                        int temp = num[j - 1];
                        num[j - 1] = num[j];
                        num[j] = temp;
                    }
                }
            }

            return num;
        }

        public IList<int> SortInsertion(IList<int> num, int count)
        {
            int i, j, val, flag;
            for (i = 1; i < count; i++)
            {
                val = num[i];
                flag = 0;
                for (j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val < num[j])
                    {
                        num[j + 1] = num[j];
                        j--;
                        num[j + 1] = val;
                    }
                    else flag = 1;
                }
            }

            return num;
        }
        public IList<int> SortMerge(IList<int> numbers)
        {
            if (numbers.Count <= 1)
                return numbers;

            IList<int> left = new List<int>();
            IList<int> right = new List<int>();

            int middle = numbers.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(numbers[i]);
            }
            for (int i = middle; i < numbers.Count; i++)
            {
                right.Add(numbers[i]);
            }

            left = SortMerge(left);
            right = SortMerge(right);
            return Merge(left, right);

        }

        public List<int> Merge(IList<int> left, IList<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}
