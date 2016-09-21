using AWSCore.DynamoBase.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Tables.Core
{
    // Sort of like a "database" in DynamoDB.
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
