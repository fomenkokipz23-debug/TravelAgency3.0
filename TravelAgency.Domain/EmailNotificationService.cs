using System;

namespace TravelAgency.Domain;

public class EmailNotificationService
{
    public void OnBookingCreatedHandler(object? sender, BookingEventArgs e)
    {
        var booking = e.CreatedBooking;
        
        Console.WriteLine($"[EMAIL SENT] Шановний {booking.Guest.Name}! " +
                          $"Ваш номер №{booking.BookedRoom.Number} успішно заброньовано " +
                          $"на період з {booking.CheckIn:dd.MM.yyyy} по {booking.CheckOut:dd.MM.yyyy}.");
    }
}