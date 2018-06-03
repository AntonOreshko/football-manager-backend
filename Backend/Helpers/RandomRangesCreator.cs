using System;
using System.Collections.Generic;

namespace Backend.Helpers
{
    public class RandomRangesCreator<T>
    {
        protected List<KeyValuePair<T, KeyValuePair<int, int>>> Ranges;

        public RandomRangesCreator(List<T> types, List<int> ranges)
        {
            int sum;

            if (CheckRanges(ranges, out sum))
            {
                Ranges = new List<KeyValuePair<T, KeyValuePair<int, int>>>();

                int currentDownLimit = 0;
                int idx = 0;
                foreach (var r in ranges)
                {
                    if (r > 0)
                    {
                        Ranges.Add(new KeyValuePair<T, KeyValuePair<int, int>>(types[idx], new KeyValuePair<int, int>(currentDownLimit, currentDownLimit + r)));
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
            T result = default(T);

            for (int i = 0; i < Ranges.Count; i++)
            {
                if (Ranges[i].Value.Key <= randomVal && Ranges[i].Value.Value > randomVal)
                {
                    result = Ranges[i].Key;
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
