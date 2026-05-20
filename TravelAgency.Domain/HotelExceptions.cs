using System;

namespace TravelAgency.Domain;

public class RoomOccupiedException : Exception
{
    public int RoomNumber { get; }

    public RoomOccupiedException(int roomNumber) 
        : base($"Кімната №{roomNumber} вже заброньована на ці дати.")
    {
        RoomNumber = roomNumber;
    }
}

public class InvalidBookingDatesException : Exception
{
    public InvalidBookingDatesException(DateTime checkIn, DateTime checkOut)
        : base($"Некоректний період проживання: дата заїзду ({checkIn:dd.MM.yyyy}) не може бути пізнішою за дату виїзду ({checkOut:dd.MM.yyyy}).")
    {
    }
}