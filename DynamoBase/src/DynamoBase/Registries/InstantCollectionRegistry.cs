using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Registries
{
    // Note: Normally, the collection registry type should be ICollectionRegistry.
    // "Instant" means the tables in a table collection can be dynamically created/deleted on the fly.
    public interface IInstantCollectionRegistry : ICollectionRegistry
    {
        Task CreateAllTablesAsync(string serviceURL, string tableSuffix, bool recreateIfPresent = false);

        // Delete all tables, if relevant.
        Task DeleteAllTablesAsync(string serviceURL, string tableSuffix);

        // Remove all items in all tables for a given collection.
        // Note: this can be potentially dangerous...
        Task PurgeAllTablesAsync(string serviceURL, string tableSuffix, bool createIfAbsent = false);

    }
}
