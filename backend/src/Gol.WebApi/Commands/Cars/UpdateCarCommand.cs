namespace Gol.WebApi.Commands.Cars;

public record UpdateCarCommand(Guid VehicleId, string Model, string Plate, int Year, string Color, int PassengerCapacity);