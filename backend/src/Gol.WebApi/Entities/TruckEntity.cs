namespace Gol.WebApi.Entities;

public class TruckEntity(int loadCapacity, Guid vehicleId)
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public int LoadCapacity { get; private set; } = loadCapacity;

    public Guid VehicleId { get; private set; } = vehicleId;


    public VehicleEntity Vehicle { get; private set; }

    public static TruckEntity Create(string plate, string model, string color, int year, int loadCapacity)
    {
        var vehicle = new VehicleEntity(plate, model, color, year);
        return new TruckEntity(loadCapacity, vehicle.Id);
    }

    public void Update(int loadCapacity)
    {
        LoadCapacity = loadCapacity;
    }
}