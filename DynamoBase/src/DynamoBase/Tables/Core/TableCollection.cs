using AWSCore.DynamoBase.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Tables.Core
{
    // Sort of like a "database" in DynamoDB.
    // (DynamoDB has no concept of a "database". It's just tables.
    // But, in practice, we always deal with a set of related tables, which is like a "database" in RDBMS, for example.
    // "Table collection" allows a high level construct for managing a set of related tables.)
    public interface ITableCollection
    {
        // ??? "Global" clientContext ???
        // ClientContext is stored in each table....
        IDynamoDBClientContext ClientContext { get; }
        // key == table kind.
        IDynamoTable GetTable(string key);
        void SetTable(string key, IDynamoTable table);

    }
}
