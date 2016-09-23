using Amazon.DynamoDBv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Clients
{
    // AmazonDynamoDBClient holder.
    public interface IDynamoDBClientContext
    {
        AmazonDynamoDBClient Client { get; }
    }
}
