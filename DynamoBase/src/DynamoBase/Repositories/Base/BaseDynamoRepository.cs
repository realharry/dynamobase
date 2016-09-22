using AWSCore.DynamoBase.Tables.Core;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AWSCore.DynamoBase.Repositories.Base
{
    public abstract class BaseDynamoRepository : IInstantRepository
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly IDynamoTable dynamoTable;
        public BaseDynamoRepository(IDynamoTable dynamoTable)
        {
            this.dynamoTable = dynamoTable;
        }

        public IDynamoTable DynamoTable
        {
            get
            {
                return dynamoTable;
            }
        }
        public IInstantDynamoTable InstantDynamoTable
        {
            get
            {
                return dynamoTable as IInstantDynamoTable;
            }
        }

        // Create a table if not exist.
        // If recreateIfPresent == true, delete the existing table, if any, and create a new one.
        public async Task CreateTableAsync(bool recreateIfPresent = false)
        {
            await InstantDynamoTable?.CreateAsync(recreateIfPresent);
        }

        // Delete the table.
        public async Task DeleteTableAsync()
        {
            await InstantDynamoTable?.DeleteAsync();
        }

        // Delete all data.
        // if createIfAbsent == true, create a new table.
        public virtual async Task PurgeTableAsync(bool createIfAbsent = false)
        {
            await InstantDynamoTable?.PurgeAsync(createIfAbsent);
        }

    }
}
