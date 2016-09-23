using AWSCore.DynamoBase.Tables.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Repositories
{
    // Currently, 
    // each "repository" is associated with one DynamoDB table. 
    public interface IDynamoRepository : IDataRepository
    {
        IDynamoTable DynamoTable { get; }
    }
}
