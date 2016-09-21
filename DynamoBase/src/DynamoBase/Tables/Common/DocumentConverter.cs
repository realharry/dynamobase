using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Tables.Common
{
    // Marker interface.
    public interface IDocumentConverter
    {
        // Document ConvertToDocument(object obj);
        // object ConvertFromDocument(Document doc);
    }
}
