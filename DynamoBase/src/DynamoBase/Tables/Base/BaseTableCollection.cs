using AWSCore.DynamoBase.Tables.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSCore.DynamoBase.Clients;
using System.Collections;

namespace AWSCore.DynamoBase.Tables.Base
{
    public abstract class BaseTableCollection : IInstantTableCollection
    {
        private readonly IDictionary<string, IDynamoTable> tables;

        public BaseTableCollection(IDictionary<string, IDynamoTable> tables = null)
        {
            this.tables = tables ?? new Dictionary<string, IDynamoTable>();
        }

        protected IDictionary<string, IDynamoTable> Tables
        {
            get
            {
                return tables;
            }
        }

        // temporary
        public IDynamoDBClientContext ClientContext
        {
            get
            {
                // tbd: how to store "global" clientContext ???
                // For now, just return it from any table.
                if(tables.Any())
                {
                    return tables.Values.ToList()[0].ClientContext;
                }
                return null;
            }
        }

        public IDynamoTable GetTable(string key)
        {
            if(tables.ContainsKey(key))
            {
                return tables[key];
            }
            return null;
        }

        public void SetTable(string key, IDynamoTable table)
        {
            // Replace the existing table, if exists.
            tables[key] = table;
        }

        public IList<IDynamoTable> GetAllTables()
        {
            return Tables.Values.ToList();
        }

        public IEnumerator<IDynamoTable> GetEnumerator()
        {
            return GetAllTables().GetEnumerator();
        }
        // ????
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAllTables().GetEnumerator();
        }


        public virtual async Task CreateAllTablesAsync(bool recreateIfPresent = false)
        {
            foreach (var t in Tables.Values)
            {
                await (t as IInstantDynamoTable)?.CreateAsync(recreateIfPresent);
            }
        }

        public virtual async Task DeleteAllTablesAsync()
        {
            foreach (var t in Tables.Values)
            {
                await (t as IInstantDynamoTable)?.DeleteAsync();
            }
        }

        public virtual async Task PurgeAllTablesAsync(bool createIfAbsent = false)
        {
            foreach (var t in Tables.Values)
            {
                await (t as IInstantDynamoTable)?.PurgeAsync(createIfAbsent);
            }
        }
    }
}
