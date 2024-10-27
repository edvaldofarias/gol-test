namespace Gol.WebApi.Commands.Cars;

public record CreateCarCommand(string Model, string Plate, int Year, string Color, int PassengerCapacity);