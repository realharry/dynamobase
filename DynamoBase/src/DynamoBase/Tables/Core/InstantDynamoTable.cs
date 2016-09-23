using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Tables.Core
{
    // Note: Normally, IDynamoTable should be used as a type instead of InstantDynamoTable.
    // "Instant" table can be dynamically created/deleted.
    public interface IInstantDynamoTable : IDynamoTable
    {
        // Returns true if the table is present.
        Task<bool> IsPresentAsync();

        // Note: these operations can be potentially dangerous...

        // Create a new table.
        Task CreateAsync(bool recreateIfPresent = false);

        // Delete an existing table.
        Task DeleteAsync();

        // Remove all items in the table.
        Task PurgeAsync(bool createIfAbsent = false);

    }
}
