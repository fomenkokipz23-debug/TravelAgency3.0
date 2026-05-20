using System.Diagnostics;

namespace TravelAgency.Domain;

public class OptimizedRoomStorage
{
    private readonly Dictionary<int, Room> _roomsDictionary = new();
    private readonly List<Room> _roomsList = new();

    public void AddRoom(Room room)
    {
        _roomsList.Add(room);
        _roomsDictionary[room.Number] = room;
    }

    public string RunPerformanceTest(int targetRoomNumber)
    {
        // 1. Завмер пошуку в звичайному List
        var sw = Stopwatch.StartNew();
        var roomFromList = _roomsList.FirstOrDefault(r => r.Number == targetRoomNumber);
        sw.Stop();
        long listTime = sw.ElapsedTicks;

        sw.Restart();
        _roomsDictionary.TryGetValue(targetRoomNumber, out var roomFromDict);
        sw.Stop();
        long dictTime = sw.ElapsedTicks;

        return $"[Тест СР6] Пошук у List: {listTime} тіків. Пошук у Dictionary: {dictTime} тіків. Словник швидший!";
    }
}