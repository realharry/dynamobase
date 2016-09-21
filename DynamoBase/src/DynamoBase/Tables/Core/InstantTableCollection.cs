using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Tables.Core
{
    // Note: Normally, ITableCollection or IEnumerableTableCollection should be used instead of IInstantTableCollection as a type.
    public interface IInstantTableCollection : IEnumerableTableCollection
    {
        Task CreateAllTablesAsync(bool recreateIfPresent = false);

        // Delete all tables, if relevant.
        Task DeleteAllTablesAsync();

        // Remove all items in all tables for a given collection.
        // Note: this can be potentially dangerous...
        Task PurgeAllTablesAsync(bool createIfAbsent = false);

    }
}
