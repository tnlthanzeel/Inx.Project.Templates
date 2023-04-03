namespace Inexis.Clean.Architecture.Template.Application.PersistanceInterfaces;

public interface IBaseRepository
{
    Task<int> SaveChangesAsync(CancellationToken token);
}
