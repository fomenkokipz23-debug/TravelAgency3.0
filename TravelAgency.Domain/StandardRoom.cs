namespace TravelAgency.Domain;

public class StandardRoom : Room
{
    public bool HasBalcony { get; set; }

    public StandardRoom(int number, decimal basePrice, bool hasBalcony) 
        : base(number, "Standard", basePrice)
    {
        HasBalcony = hasBalcony;
    }

    public override decimal GetPrice()
    {
        decimal finalPrice = base.GetPrice(); 
        if (HasBalcony)
        {
            finalPrice += 150;
        }
        return finalPrice;
    }
}