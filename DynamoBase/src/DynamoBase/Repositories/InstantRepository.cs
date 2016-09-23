using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Repositories
{
    // Normally, IDataRepository should be used as a type.
    // "Instant" repository allows creating/deleting tables on the fly.
    public interface IInstantRepository : IDynamoRepository
    {
        // Dangerous operations.

        Task CreateTableAsync(bool recreateIfPresent = false);
        // Delete all tables, if relevant.
        Task DeleteTableAsync();
        // Remove data from all tables, if relevant.
        Task PurgeTableAsync(bool createIfAbsent = false);

    }
}
