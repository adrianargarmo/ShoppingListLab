/* Shopping List Lab
 * Adriana Garmo
 * 5/9/2023
 */

List<string> shoppingList = new List<string>();
Dictionary<string, double> shoppingCart = new Dictionary<string, double>();

Dictionary<string, double> menu = new Dictionary<string, double>()
{
    { "carrots", 1.99 },
    { "green beans", 1.99 },
    { "broccoli", 2.49 },
    { "spinach", 3.79 },
    { "white onions", 0.99 },
    { "red onions", 0.99 },
    { "sweet onions", 0.99 },
    { "butternut squash", 3.29 }
};

Console.WriteLine("Welcome to Chirpus Market!");
Console.WriteLine("");

bool addMore = true;

while (addMore = true)
{
    foreach (KeyValuePair<string, double> item in menu)
    {
        double price = item.Value;
        Console.WriteLine($"{item.Key} costs {price,0:C}");
    }
    Console.WriteLine("");
    Console.Write("What item would you like to order? ");
    string input = Console.ReadLine();

    if (menu.ContainsKey(input.ToLower()))
    {
        shoppingList.Add(input);
        addMore = true;

        Console.Write("Would you like to order anything else? (y/n) ");
        input = Console.ReadLine();

        if (input != "y")
        {
            foreach (string item in shoppingList)
            {
                if (menu.ContainsKey(item))
                {
                    shoppingCart.Add(item, menu[item]);
                }
            }

            Console.Write($"The total cost of your cart is ");
            Console.WriteLine(CartCost(shoppingCart));

            break;
        }
    }
    else
    {
        Console.Write("This item is not available, would you like to order anything else? (y/n) ");
        input = Console.ReadLine();

        if (input != "y")
        {
            break;
        }
        else { continue; }
    }
}

static double CartCost(Dictionary<string, double> cart)
{
    double total = 0;
    total = cart.Values.Sum(x => x);
    return total;
}