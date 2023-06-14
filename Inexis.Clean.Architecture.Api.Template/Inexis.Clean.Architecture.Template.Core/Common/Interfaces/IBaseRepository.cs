namespace Inexis.Clean.Architecture.Template.Core.Common.Interfaces;

public interface IBaseRepository
{
    Task<int> SaveChangesAsync(CancellationToken token);
}
