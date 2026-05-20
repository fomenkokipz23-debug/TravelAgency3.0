namespace TravelAgency.Domain;

public sealed class HotelRegistry
{
    private static HotelRegistry? _instance;
    private static readonly object _lock = new();

    public HotelCatalog Catalog { get; }

    private HotelRegistry()
    {
        Catalog = new HotelCatalog("Horizon Premium Agency");
    }

    public static HotelRegistry Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new HotelRegistry();
                }
                return _instance;
            }
        }
    }
}