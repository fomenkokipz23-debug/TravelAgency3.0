namespace TravelAgency.Domain;

public abstract class RoomDecorator : Room
{
    protected Room _wrappedRoom;

    protected RoomDecorator(Room room) : base(room.Number, room.Type, room.BasePrice)
    {
        _wrappedRoom = room;
    }
}

public class BreakfastDecorator : RoomDecorator
{
    public BreakfastDecorator(Room room) : base(room) { }

    public override decimal GetPrice()
    {
        return _wrappedRoom.GetPrice() + 350m;
    }
}

public class TransferDecorator : RoomDecorator
{
    public TransferDecorator(Room room) : base(room) { }

    public override decimal GetPrice()
    {
        return _wrappedRoom.GetPrice() + 600m;
    }
}