using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balo
{
    class Item
    {
        public double Weight { get; set; }
        public double Value { get; set; }

        public Item(double weight, double value)
        {
            Weight = weight;
            Value = value;
        }

        public double ValuePerWeight()
        {
            return Value / Weight;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>
        {
            new Item(15, 70),
            new Item(28, 100),
            new Item(34, 115)
        };

            double maxWeight = 60;

            double maxValue = FractionalKnapsack(items, maxWeight);

            Console.WriteLine("Gia tri toi da cua balo: " + maxValue);
        }

        static double FractionalKnapsack(List<Item> items, double maxWeight)
        {
            items.Sort((x, y) => y.ValuePerWeight().CompareTo(x.ValuePerWeight()));

            double totalValue = 0;
            double currentWeight = 0;

            foreach (var item in items)
            {
                if (currentWeight + item.Weight <= maxWeight)
                {
                    currentWeight += item.Weight;
                    totalValue += item.Value;
                }
                else
                {
                    double remainWeight = maxWeight - currentWeight;
                    totalValue += item.ValuePerWeight() * remainWeight;
                    break;
                }
            }

            return totalValue;
        }
    }
}
