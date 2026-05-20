using System;

namespace TravelAgency.Domain;

public class BookingEventArgs : EventArgs
{
    public Booking CreatedBooking { get; }

    public BookingEventArgs(Booking booking)
    {
        CreatedBooking = booking;
    }
}