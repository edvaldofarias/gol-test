namespace Gol.WebApi.Entities;

public class VehicleEntity(string plate, string model, string color, int year)
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Plate { get; private set; } = plate;
    public string Model { get; private set; } = model;

    public string Color { get; private set; } = color;

    public int Year { get; private set; } = year;

    public Guid? TruckId { get; private set; }

    public Guid? CarId { get; private set; }

    public TruckEntity? Truck { get; private set; }

    public CarEntity? Car { get; private set; }

    public IEnumerable<RevisionEntity> Revisions { get; private set; }

    public void SetTruck(TruckEntity truck)
    {

        Car = null;
        Truck = truck;
        TruckId = truck.Id;
    }

    public void SetCar(CarEntity car)
    {
        Truck = null;
        Car = car;
        CarId = car.Id;
    }

    public void Update(string plate, string model, string color, int year)
    {
        Plate = plate;
        Model = model;
        Color = color;
        Year = year;
    }


}