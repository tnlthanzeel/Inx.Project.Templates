using Inexis.Clean.Architecture.Template.Core.Common.Interfaces;

namespace Inexis.Clean.Architecture.Template.Persistence.Repositories;

internal sealed class UnitOfWork : BaseRepository, IUnitOfWork
{
    public UnitOfWork(AppDbContext dbContext) : base(dbContext) { }
}
