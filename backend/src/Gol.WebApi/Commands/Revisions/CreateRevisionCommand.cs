namespace Gol.WebApi.Commands.Revisions;

public record CreateRevisionCommand(Guid VehicleId, decimal Value, DateTime Date, int Mileage);