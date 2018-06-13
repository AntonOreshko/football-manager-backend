using System;
using System.Collections.Generic;

namespace Utility.Helpers
{
    public class RandomRangesCreator<T>
    {
        protected readonly List<KeyValuePair<T, KeyValuePair<int, int>>> ranges;

        public RandomRangesCreator(IReadOnlyList<T> types, List<int> ranges)
        {
            if (CheckRanges(ranges, out var sum))
            {
                this.ranges = new List<KeyValuePair<T, KeyValuePair<int, int>>>();

                int currentDownLimit = 0;
                int idx = 0;
                foreach (var r in ranges)
                {
                    if (r > 0)
                    {
                        this.ranges.Add(new KeyValuePair<T, KeyValuePair<int, int>>(types[idx], new KeyValuePair<int, int>(currentDownLimit, currentDownLimit + r)));
                        currentDownLimit += r;
                    }
                    idx++;
                }
            }
            else
            {
                throw new Exception("Ranges sum must be 100, but sum = " + sum);
            }
        }

        public T GetRandom()
        {
            var rnd = new Random();
            var randomVal = rnd.Next(0, 101);
            var result = default(T);

            foreach (var t in ranges)
            {
                if (t.Value.Key <= randomVal && t.Value.Value > randomVal)
                {
                    result = t.Key;
                    break;
                }
            }

            return result;
        }

        private bool CheckRanges(List<int> ranges, out int totalSum)
        {
            var sum = 0;

            foreach (var r in ranges)
            {
                sum += r;
            }

            totalSum = sum;

            return sum == 100;
        }
    }
}
