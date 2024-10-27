namespace Gol.WebApi.Commands.Revisions;

public record UpdateRevisionCommand(Guid Id, decimal Value, DateTime Date, int Mileage);