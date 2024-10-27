using Gol.WebApi.Commands.Trucks;
using Gol.WebApi.Dtos;
using Gol.WebApi.Entities;
using Gol.WebApi.Infrastructure.Repositories.Interfaces;
using Gol.WebApi.Services.Interfaces;

namespace Gol.WebApi.Services;

public class TruckService(ITruckRepository truckRepository, IVehicleRepository vehicleRepository) : ITruckService
{
    public async Task CreateAsync(CreateTruckCommand command)
    {
        var truck = TruckEntity.Create(command.Plate, command.Model, command.Color, command.Year, command.LoadCapacity);
        await truckRepository.CreateAsync(truck);
    }

    public async Task UpdateAsync(UpdateTruckCommand command)
    {
        var vehicle = await vehicleRepository.GetByIdAsync(command.VehicleId);
        if (vehicle.Truck is null)
        {
            var truck = new TruckEntity(command.LoadCapacity, command.VehicleId);
            vehicle.SetTruck(truck);
        }
        else
        {
            vehicle.Truck.Update(command.LoadCapacity);
        }

        vehicle.Update(command.Plate, command.Model, command.Color, command.Year);
        await vehicleRepository.UpdateAsync(vehicle);
    }
    public async Task<TruckDto> GetByIdAsync(Guid id)
    {
        var truck = await truckRepository.GetByIdAsync(id);
        return new TruckDto(truck.Id, truck.LoadCapacity);
    }
}