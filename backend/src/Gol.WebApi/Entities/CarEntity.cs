namespace Gol.WebApi.Entities;

public class CarEntity(int passengerCapacity, Guid vehicleId)
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public int PassengerCapacity { get; private set; } = passengerCapacity;

    public Guid VehicleId { get; private set; } = vehicleId;

    public VehicleEntity Vehicle { get; private set; }


    public static CarEntity Create(string plate, string model, string color, int year, int passengerCapacity)
    {
        var vehicle = new VehicleEntity(plate, model, color, year);
        var car = new CarEntity(passengerCapacity, vehicle.Id);
        car.SetVehicle(vehicle);
        vehicle.SetCar(car);
        return car;
    }

    public void Update(int passengerCapacity)
    {
        PassengerCapacity = passengerCapacity;
    }

    public void SetVehicle(VehicleEntity vehicle)
    {
        Vehicle = vehicle;
    }
}