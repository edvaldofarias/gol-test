namespace Gol.WebApi.Entities;

public class RevisionEntity(Guid vehicleId, DateTime revisionDate, decimal value, int mileage)
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid VehicleId { get; private set; } = vehicleId;

    public VehicleEntity Vehicle { get; private set; }

    public DateTime RevisionDate { get; private set; } = revisionDate;

    public decimal Value { get; private set; } = value;

    public int Mileage { get; private set; } = mileage;

    public void Update(DateTime revisionDate, decimal value, int mileage)
    {
        RevisionDate = revisionDate;
        Value = value;
        Mileage = mileage;
    }
}