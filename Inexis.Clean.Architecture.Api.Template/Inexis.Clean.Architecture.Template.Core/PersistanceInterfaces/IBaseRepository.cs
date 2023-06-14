namespace Inexis.Clean.Architecture.Template.Core.PersistanceInterfaces;

public interface IBaseRepository
{
    Task<int> SaveChangesAsync(CancellationToken token);
}
