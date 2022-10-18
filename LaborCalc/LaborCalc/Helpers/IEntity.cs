namespace LaborCalc.Helpers;

public interface IEntity
{
    public Guid Id => Guid.NewGuid();
}
