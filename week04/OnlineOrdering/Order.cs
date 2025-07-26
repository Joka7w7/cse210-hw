using System.Collections.Generic;
using System.Text;

public class Order
{
    private Customer customer;
    private List<Product> products;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetShippingCost()
    {
        return customer.LivesInUSA() ? 5.0 : 35.0;
    }

    public double GetProductTotal()
    {
        double total = 0;
        foreach (Product p in products)
        {
            total += p.GetTotalCost();
        }
        return total;
    }

    public double GetTotalPrice()
    {
        return GetProductTotal() + GetShippingCost();
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder("Packing Label:\n");
        foreach (Product p in products)
        {
            label.AppendLine(p.GetFullPackingInfo());
        }
        return label.ToString();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFormattedAddress()}";
    }
}
