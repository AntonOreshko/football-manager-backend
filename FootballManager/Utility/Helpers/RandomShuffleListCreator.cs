using System;
using System.Collections.Generic;
using System.Linq;

namespace Utility.Helpers
{
    public class RandomShuffleListCreator<T>
    {
        private List<T> items;

        private readonly Random rnd = new Random();

        public RandomShuffleListCreator(List<T> items)
        {
            this.items = items;
            Shuffle();
        }

        public T Pop()
        {
            var item = items[0];
            items.Remove(item);
            return item;
        }

        public T Get()
        {
            var item = items[0];
            Shuffle();
            return item;
        }

        private void Shuffle()
        {
            items = items.OrderBy(item => rnd.Next()).ToList();
        }
    }
}
