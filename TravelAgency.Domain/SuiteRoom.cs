namespace TravelAgency.Domain;

public class SuiteRoom : Room
{
    public int RoomsCount { get; set; }
    public decimal LuxuryTaxPercentage { get; set; } 

    public SuiteRoom(int number, decimal basePrice, int roomsCount, decimal luxuryTaxPercentage)
        : base(number, "Suite", basePrice)
    {
        RoomsCount = roomsCount;
        LuxuryTaxPercentage = luxuryTaxPercentage;
    }

    public override decimal GetPrice()
    {
        decimal originalPrice = base.GetPrice();
        return originalPrice + (originalPrice * LuxuryTaxPercentage);
    }
    public new string GetSubInfo()
    {
        return $"[Suite Room] Кількість кімнат: {RoomsCount}, Націнка: {LuxuryTaxPercentage * 100}%";
    }
}