using System;
using System.Collections.Generic;

namespace TravelAgency.Domain;

public class Room
{
    public int Number { get; set; }
    public string Type { get; set; } 
    public decimal BasePrice { get; set; }
    
    public HashSet<string> Amenities { get; set; } = new();

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

    public static bool operator ==(Room? left, Room? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        
        return left.Number == right.Number && left.Type == right.Type;
    }

    public static bool operator !=(Room? left, Room? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is Room room && this == room;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Number, Type);
    }
}