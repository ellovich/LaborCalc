using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Item
    {
        public string Name { get; set; }
        public double Val { get; set; }

        public Item(string name, double val)
        {
            Name = name;
            Val = val;
        }

        public override string ToString()
        {
            return $"{Name}: {Val}";
        }
    }

    public class Table
    {
        static int i = 0; // счетчик для вызова конструкторов

        public string Name { get; set; }
        public List<Item> TableItems { get; set; } // нужен именно список

        // почему-то не вызывается
        [JsonConstructor]
        public Table()
        {
            Console.WriteLine($"------------------------------->{++i} вызов Table");
        }

        public Table(string name, List<Item> tableItems)
        {
            Console.WriteLine($"------------------------------->{++i} вызов Table");

            Name = name;
            TableItems = new List<Item>(tableItems);
        }

        public override string ToString()
        {
            string str = $"### {Name} ###\n";
            if (TableItems != null)
            {
                foreach (var item in TableItems)
                    str += item + "\n";
            }
            return str;
        }
    }
}