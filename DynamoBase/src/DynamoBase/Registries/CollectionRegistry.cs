using AWSCore.DynamoBase.Tables.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Registries
{
    public interface ICollectionRegistry
    {
        ITableCollection GetTableCollection(string serviceURL, string tableSuffix);
    }
}
