using System;
using TravelAgency.Domain;
using Xunit;

namespace TravelAgency.Tests;

public class BusinessLogicTests
{
    [Fact]
    public void RoomDecorator_ShouldCalculatedCorrectPrice_WhenMultipleServicesAdded()
    {
        Room room = new StandardRoom(105, 1000m, hasBalcony: false);

        room = new BreakfastDecorator(room);
        room = new TransferDecorator(room);
        
        decimal finalPrice = room.GetPrice();

        Assert.Equal(1950m, finalPrice);
    }

    [Fact]
    public void InvoiceBuilder_ShouldBuildCorrectInvoice_ForClient()
    {
        var client = new Client("Катерина", "kateryna@mail.com");
        var room = new StandardRoom(202, 1200m, hasBalcony: true); 
        var builder = new InvoiceBuilder();
        
        DateTime checkIn = DateTime.Today;
        DateTime checkOut = DateTime.Today.AddDays(3); 

        Invoice invoice = builder
            .StartNewInvoice(client)
            .SetRoomDetails(room)
            .SetDuration(checkIn, checkOut)
            .ApplyLoyaltyDiscount(200m) 
            .Build();

        Assert.Equal("Катерина", invoice.ClientName);
        Assert.Equal(3, invoice.TotalDays);
        Assert.Equal(3850m, invoice.TotalSum);
    }
}