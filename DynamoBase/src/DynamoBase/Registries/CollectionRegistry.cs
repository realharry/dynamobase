using AWSCore.DynamoBase.Tables.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Registries
{
    // A collection of collections of tables.
    // The primary use case for this is when you have multiple table collections, e.g., one for each environment.
    public interface ICollectionRegistry
    {
        ITableCollection GetTableCollection(string serviceURL, string tableSuffix);
    }
}
