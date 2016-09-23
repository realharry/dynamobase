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
        // Not being used.
        // (Note: Conversion methods can be generally static.)
        // Document ConvertToDocument(object obj);
        // object ConvertFromDocument(Document doc);
    }
}
