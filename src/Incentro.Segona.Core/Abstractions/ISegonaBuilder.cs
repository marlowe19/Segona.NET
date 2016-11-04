namespace Incentro.Segona.Core.Abstractions
{
    public interface ISegonaBuilder
    {
        ISegonaBuilder SetHandler<T>() where T : class, ISegonaHandler;
    }
}
