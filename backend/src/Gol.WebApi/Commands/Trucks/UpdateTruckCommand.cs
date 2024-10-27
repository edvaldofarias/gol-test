namespace Gol.WebApi.Commands.Trucks;

public record UpdateTruckCommand(Guid VehicleId, string Model, string Plate, int Year, string Color, int LoadCapacity);