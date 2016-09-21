using Amazon.DynamoDBv2.DocumentModel;
using AWSCore.DynamoBase.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Tables.Core
{
    public interface IDynamoTable
    {
        IDynamoDBClientContext ClientContext { get; }
        string Key { get; }
        string Name { get; set; }
        Table Table { get; }

    }
}
