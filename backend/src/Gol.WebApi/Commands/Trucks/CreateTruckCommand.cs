namespace Gol.WebApi.Commands.Trucks;

public record CreateTruckCommand(string Model, string Plate, int Year, string Color, int LoadCapacity);