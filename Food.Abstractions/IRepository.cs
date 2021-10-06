using System;
using System.Threading.Tasks;

namespace Food.Abstractions
{
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot: AggregateRoot
    {
        Task<TAggregateRoot> GetByIdAsync(Guid id);

        Task SaveAsync(TAggregateRoot order);
    }
}