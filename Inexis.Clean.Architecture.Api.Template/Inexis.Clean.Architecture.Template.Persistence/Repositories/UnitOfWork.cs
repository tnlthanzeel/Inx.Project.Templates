using Inexis.Clean.Architecture.Template.Core.CommonInterfaces;

namespace Inexis.Clean.Architecture.Template.Persistence.Repositories;

internal sealed class UnitOfWork : BaseRepository, IUnitOfWork
{
    public UnitOfWork(AppDbContext dbContext) : base(dbContext) { }
}
