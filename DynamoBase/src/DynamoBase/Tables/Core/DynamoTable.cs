using Amazon.DynamoDBv2.DocumentModel;
using AWSCore.DynamoBase.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Tables.Core
{
    // Wrapper around DynamodB table.
    // Note: "key" is used to classify tables into a category.
    //    For example, a User table in prod and a User table in staging clearly belong to the same category/class
    //    (although they are physically different tables on DynamoDB).
    // Key (in addition to DynamoDB table Name) can be used to define a category or type.
    public interface IDynamoTable
    {
        IDynamoDBClientContext ClientContext { get; }
        string Key { get; }
        string Name { get; set; }
        Table Table { get; }

    }
}
