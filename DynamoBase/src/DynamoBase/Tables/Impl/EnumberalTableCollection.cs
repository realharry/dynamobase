using AWSCore.DynamoBase.Tables.Base;
using AWSCore.DynamoBase.Tables.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Tables.Impl
{
    public class EnumerableTableCollection : BaseTableCollection, IEnumerableTableCollection
    {
        public EnumerableTableCollection(IDictionary<string, IDynamoTable> tables = null)
            : base(tables)
        {
        }

    }
}
