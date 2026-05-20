using System;
using System.Text;

namespace TravelAgency.Domain;

public class Invoice
{
    public string ClientName { get; set; } = string.Empty;
    public int RoomNumber { get; set; }
    public decimal PricePerNight { get; set; }
    public int TotalDays { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalSum => (PricePerNight * TotalDays) - Discount;

    public string GenerateTextInvoice()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"--- РАХУНОК ДЛЯ: {ClientName} ---");
        sb.AppendLine($"Номер готелю: №{RoomNumber}");
        sb.AppendLine($"Вартість за добу (з послугами): {PricePerNight} грн");
        sb.AppendLine($"Кількість діб: {TotalDays}");
        if (Discount > 0) sb.AppendLine($"Знижка: -{Discount} грн");
        sb.AppendLine($"---------------------------------");
        sb.AppendLine($"ЗАГАЛОМ ДО СПЛАТИ: {TotalSum} грн");
        return sb.ToString();
    }
}

public class InvoiceBuilder
{
    private Invoice _invoice = new();

    public InvoiceBuilder StartNewInvoice(Client client)
    {
        _invoice = new Invoice { ClientName = client.Name };
        return this;
    }

    public InvoiceBuilder SetRoomDetails(Room room)
    {
        _invoice.RoomNumber = room.Number;
        _invoice.PricePerNight = room.GetPrice(); 
        return this;
    }

    public InvoiceBuilder SetDuration(DateTime checkIn, DateTime checkOut)
    {
        int days = (int)(checkOut - checkIn).TotalDays;
        _invoice.TotalDays = days <= 0 ? 1 : days; 
        return this;
    }

    public InvoiceBuilder ApplyLoyaltyDiscount(decimal discountAmount)
    {
        _invoice.Discount = discountAmount;
        return this;
    }

    public Invoice Build()
    {
        return _invoice;
    }
}