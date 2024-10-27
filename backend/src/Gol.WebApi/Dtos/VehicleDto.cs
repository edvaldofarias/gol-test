namespace Gol.WebApi.Dtos;

public record VehicleDto(Guid Id, string Model, string Plate, int Year, string Color, Guid? CarId, Guid? TruckId);
