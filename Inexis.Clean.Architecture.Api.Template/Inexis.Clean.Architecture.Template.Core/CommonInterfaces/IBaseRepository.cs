namespace Inexis.Clean.Architecture.Template.Core.CommonInterfaces;

public interface IBaseRepository
{
    Task<int> SaveChangesAsync(CancellationToken token);
}
