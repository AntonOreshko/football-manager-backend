using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Helpers
{
    public class RandomShuffleListCreator<T>
    {
        private List<T> items { get; set; }

        public RandomShuffleListCreator(List<T> items)
        {
            this.items = items;

            var rnd = new Random();

            this.items = items.OrderBy(item => rnd.Next()).ToList();
        }

        public T Get()
        {
            var item = items[0];
            items.Remove(item);
            return item;
        }
    }
}
