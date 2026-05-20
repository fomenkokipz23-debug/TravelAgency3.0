namespace TravelAgency.Domain;

public class Booking : IDisposable
{
    public Guid Id { get; private set; }
    public Client Guest { get; private set; }
    public Room BookedRoom { get; private set; }
    public DateTime CheckIn { get; private set; }
    public DateTime CheckOut { get; private set; }
    private bool _isDisposed = false;

    public Booking(Client guest, Room room, DateTime checkIn, DateTime checkOut)
    {
        Id = Guid.NewGuid();
        Guest = new Client(guest);
        BookedRoom = room;
        CheckIn = checkIn;
        CheckOut = checkOut;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
            }
            _isDisposed = true;
        }
    }
}