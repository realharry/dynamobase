using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Tables.Core
{
    public interface IEnumerableTableCollection : ITableCollection, IEnumerable<IDynamoTable>
    {
        IList<IDynamoTable> GetAllTables();

    }
}
