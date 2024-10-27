using Gol.WebApi.Commands.Cars;
using Gol.WebApi.Dtos;
using Gol.WebApi.Entities;
using Gol.WebApi.Infrastructure.Repositories.Interfaces;
using Gol.WebApi.Services.Interfaces;

namespace Gol.WebApi.Services;

public class CarService(ICarRepository carRepository, IVehicleRepository vehicleRepository) : ICarService
{
    public async Task CreateAsync(CreateCarCommand command)
    {
        var car = CarEntity.Create(command.Plate, command.Model, command.Color, command.Year,
            command.PassengerCapacity);
        await carRepository.CreateAsync(car);
    }

    public async Task UpdateAsync(UpdateCarCommand command)
    {
        var vehicle = await vehicleRepository.GetByIdAsync(command.VehicleId);
        if (vehicle is null)
        {
            throw new Exception("Vehicle not found");
        }

        if (vehicle.Car is null)
        {
            var car = new CarEntity(command.PassengerCapacity, vehicle.Id);
            vehicle.SetCar(car);
        }
        else
        {
            vehicle.Car.Update(command.PassengerCapacity);
        }

        vehicle.Update(command.Plate, command.Model, command.Color, command.Year);
        await vehicleRepository.UpdateAsync(vehicle);
    }

    public async Task<CarDto> GetByIdAsync(Guid id)
    {
        var car = await carRepository.GetByIdAsync(id);
        return new CarDto(car.Id, car.PassengerCapacity);
    }
}