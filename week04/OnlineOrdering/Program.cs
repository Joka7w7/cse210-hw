using System;

class Program
{
    static void Main(string[] args)
    {
        // Example 1: Domestic (USA)
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("USB Cable", "UC123", 5.99, 2));
        order1.AddProduct(new Product("Bluetooth Speaker", "BS456", 25.50, 1));

        Console.WriteLine("=== Order 1 ===");
        DisplayOrderDetails(order1);
        Console.WriteLine();

        // Example 2: International
        Address address2 = new Address("10 Downing St", "London", "England", "UK");
        Customer customer2 = new Customer("James Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Keyboard", "KB789", 45.00, 1));
        order2.AddProduct(new Product("Monitor", "MN321", 150.00, 1));

        Console.WriteLine("=== Order 2 ===");
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());

        double productTotal = order.GetProductTotal();
        double shipping = order.GetShippingCost();
        double total = order.GetTotalPrice();

        Console.WriteLine($"\nSubtotal: ${productTotal:F2}");
        Console.WriteLine($"Shipping: ${shipping:F2} {(order.GetShippingCost() == 5 ? "(Domestic)" : "(International)")}");
        Console.WriteLine($"Total Price: ${total:F2}");
    }
}
