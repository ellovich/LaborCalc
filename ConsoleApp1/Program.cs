//using (ApplicationContext db = new ApplicationContext())
//{
//    // создаем два объекта User
//    User tom = new User { Name = "Tom", Age = 33 };
//    User alice = new User { Name = "Alice", Age = 26 };

//    // добавляем их в бд
//    db.Users.Add(tom);
//    db.Users.Add(alice);
//    db.SaveChanges();
//    Console.WriteLine("Объекты успешно сохранены");

//    // получаем объекты из бд и выводим на консоль
//    var users = db.Users.ToList();
//    Console.WriteLine("Список объектов:");
//    foreach (User u in users)
//    {
//        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
//    }
//}

using Newtonsoft.Json;

public class Product
{
    public static string s_file = "product.json";

    public string Name { get; set; }
    public DateTime ExpiryDate { get; set; }
    public double Price { get; set; }
    public string[] Sizes { get; set; }

    public void Load()
    {
        // this = JsonConvert.DeserializeObject<Product>(s_file);
    }

    public void Save()
    {
        string output = JsonConvert.SerializeObject(this);
        using (StreamWriter sw = new StreamWriter(s_file))
            sw.WriteLine(output);
    }

    public override string ToString()
    {
        return Name;
    }
}

class Program
{
    public static void Main()
    {

        Product product = new Product();

        product.Name = "Apple";
        product.ExpiryDate = new DateTime(2008, 12, 28);
        product.Price = 3.99;
        product.Sizes = new string[] { "Small", "Medium", "Large" };

        product.Save();

        Product deserializedProduct = JsonConvert.DeserializeObject<Product>(Product.s_file);
        Console.WriteLine(deserializedProduct);
    }
}