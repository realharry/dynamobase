using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Tables.Core
{
    // ITableCollection can be an arbitrary and indefinite set of tables (many of which the app may or may not have access to).
    // IEnumerableTableCollection has the concept of "all" tables in the collection.
    public interface IEnumerableTableCollection : ITableCollection, IEnumerable<IDynamoTable>
    {
        IList<IDynamoTable> GetAllTables();

    }
}
