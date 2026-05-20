namespace TravelAgency.Domain;

public class Room
{
    public int Number { get; set; }
    public string Type { get; set; } 
    public decimal BasePrice { get; set; }

    public Room() { }

    public Room(int number, string type, decimal basePrice)
    {
        Number = number;
        Type = type;
        BasePrice = basePrice;
    }

    public virtual decimal GetPrice()
    {
        return BasePrice;
    }
}