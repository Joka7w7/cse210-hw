public class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public int GetQuantity()
    {
        return quantity;
    }

    public double GetUnitPrice()
    {
        return price;
    }

    public string GetFullPackingInfo()
    {
        return $"{name} (ID: {productId}) - Qty: {quantity}, Unit Price: ${price:F2}, Subtotal: ${GetTotalCost():F2}";
    }
}
