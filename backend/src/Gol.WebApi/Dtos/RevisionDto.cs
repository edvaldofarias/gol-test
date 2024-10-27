namespace Gol.WebApi.Dtos;

public record RevisionDto(Guid Id, Guid VehicleId, decimal Value, DateTime Date, int Mileage);