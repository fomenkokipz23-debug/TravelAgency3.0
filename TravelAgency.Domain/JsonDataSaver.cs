using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TravelAgency.Domain;

public class JsonDataSaver
{
    private readonly string _filePath = "bookings_storage.json";

    public void SaveBookings(IEnumerable<Booking> bookings)
    {
        var dtoValues = bookings.Select(b => new BookingDto
        {
            Id = b.Id,
            ClientName = b.Guest.Name,
            ClientEmail = b.Guest.Email,
            RoomNumber = b.BookedRoom.Number,
            RoomType = b.BookedRoom.Type,
            CheckInDate = b.CheckIn.ToString("yyyy-MM-dd"),
            CheckOutDate = b.CheckOut.ToString("yyyy-MM-dd"),
            FinalPricePerNight = b.BookedRoom.GetPrice() 
        }).ToList();

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(dtoValues, options);
        
        File.WriteAllText(_filePath, jsonString);
    }

    public List<BookingDto> LoadBookings()
    {
        if (!File.Exists(_filePath))
        {
            return new List<BookingDto>();
        }

        try
        {
            string jsonString = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<BookingDto>>(jsonString) ?? new List<BookingDto>();
        }
        catch
        {
            return new List<BookingDto>();
        }
    }
}