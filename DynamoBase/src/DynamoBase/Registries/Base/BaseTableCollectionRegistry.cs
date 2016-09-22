using AWSCore.DynamoBase.Tables.Core;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCore.DynamoBase.Registries.Base
{
    public abstract class BaseTableCollectionRegistry : IInstantCollectionRegistry
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly IDictionary<string, ITableCollection> tableCollections = new Dictionary<string, ITableCollection>();
        protected IDictionary<string, ITableCollection> TableCollections
        {
            get
            {
                return tableCollections;
            }
        }

        protected static string GetCollectionKey(string serviceURL, string tableSuffix)
        {
            return $"{serviceURL}::{tableSuffix ?? string.Empty}";
        }

        public virtual ITableCollection GetTableCollection(string serviceURL, string tableSuffix)
        {
            Logger.Info($"GetTableCollection() serviceURL = {serviceURL}; tableSuffix = {tableSuffix}.");

            var key = GetCollectionKey(serviceURL, tableSuffix);
            if (!TableCollections.ContainsKey(key)) {
                var tableCollection = BuildTableCollection(serviceURL, tableSuffix);
                TableCollections.Add(key, tableCollection);
            }
            return TableCollections[key];
        }

        protected abstract ITableCollection BuildTableCollection(string serviceURL, string tableSuffix);



        // ???

        public async Task CreateAllTablesAsync(string serviceURL, string tableSuffix, bool recreateIfPresent = false)
        {
            var tableCollection = GetTableCollection(serviceURL, tableSuffix);
            await (tableCollection as IInstantTableCollection)?.CreateAllTablesAsync(recreateIfPresent);
        }

        public async Task DeleteAllTablesAsync(string serviceURL, string tableSuffix)
        {
            var tableCollection = GetTableCollection(serviceURL, tableSuffix);
            await (tableCollection as IInstantTableCollection)?.DeleteAllTablesAsync();
        }

        public async Task PurgeAllTablesAsync(string serviceURL, string tableSuffix, bool createIfAbsent = false)
        {
            var tableCollection = GetTableCollection(serviceURL, tableSuffix);
            await (tableCollection as IInstantTableCollection)?.PurgeAllTablesAsync(createIfAbsent);
        }

    }
}
