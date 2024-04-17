using POS.Domain.Repositories;

namespace POS.Infrastructure.DAL.Repositories;

internal class Repository<T> : BaseRepository<T>, IRepository<T> where T : class
{
    public Repository(POSDbContext context) : base(context)
    {

    }
}
