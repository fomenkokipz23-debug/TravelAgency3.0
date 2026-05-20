using System;

namespace TravelAgency.Domain;

public static class RoomFactory
{
    public static Room CreateRoom(string type, int number, decimal basePrice)
    {
        return type.ToLower() switch
        {
            "standard" => new StandardRoom(number, basePrice, hasBalcony: true),
            "suite" => new SuiteRoom(number, basePrice, roomsCount: 2, luxuryTaxPercentage: 0.20m),
            _ => throw new ArgumentException($"Невідомий тип кімнати: {type}")
        };
    }
}