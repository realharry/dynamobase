using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using AWSCore.DynamoBase.Clients;
using AWSCore.DynamoBase.Tables.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using NLog;

namespace AWSCore.DynamoBase.Tables.Base
{
    public abstract class BaseDynamoTable : IInstantDynamoTable
    {
        // private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly IDynamoDBClientContext clientContext;

        private string _table_key = null;
        private string _table_name = null;

        // TBD:
        // what happens if clientContext is null???  What if key is null????
        public BaseDynamoTable(IDynamoDBClientContext clientContext, string key, string name = null)
        {
            this.clientContext = clientContext;
            _table_key = key;
            if (name != null)
            {
                _table_name = name;
            }
            else
            {
                // ???
                _table_name = _table_key;
            }
        }

        public IDynamoDBClientContext ClientContext
        {
            get
            {
                return clientContext;
            }
        }

        public string Key
        {
            get
            {
                return _table_key;
            }
        }

        public string Name
        {
            get
            {
                return _table_name;
            }
            set
            {
                _table_name = value;
            }
        }


        private Table table = null;
        // Note that this can return null table...
        public Table Table
        {
            get
            {
                if (table == null)
                {
                    try
                    {
                        table = Table.LoadTable(ClientContext.Client, Name);
                    }
                    catch (Exception ex)
                    {
                        // What to do???
                        // Logger.Warn($"Failed to load the table, {Name}. {ex.Message}");
                        System.Diagnostics.Debug.WriteLine($"Failed to load the table, {Name}. {ex.Message}");
                        // throw ex;
                    }
                }
                return table;
            }
        }



        // Note:
        // We should just use the aws console or cli to create tables.
        // (it's very unlikely we will need to create/delete a table dynamically, except for maybe during testing.)
        // Before deployment, we pre-create all necesasry tables.
        // As far as the app is concerned, it should be assumed that the needed tables are always present.


        // TBD: Does this work???
        public virtual async Task<bool> IsPresentAsync()
        {
            string lastEvaluatedTableName = null;
            do
            {
                try {
                    // Create a request object to specify optional parameters.
                    var request = new ListTablesRequest
                    {
                        Limit = 10, // Page size.
                        ExclusiveStartTableName = lastEvaluatedTableName
                    };

                    var response = await ClientContext.Client.ListTablesAsync(request);
                    var tableNames = response.TableNames;
                    foreach (string name in tableNames)
                    {
                        Console.WriteLine(name);
                        if (name == Name)
                        {
                            return true;
                        }
                    }
                    lastEvaluatedTableName = response.LastEvaluatedTableName;
                }
                catch (Exception ex)
                {
                    // What to do???
                    // Logger.Warn($"Failed to list tables, {Name}. {ex.Message}");
                    throw ex;
                }

            } while (lastEvaluatedTableName != null);

            return false;
        }


        // TBD:
        public abstract Task CreateAsync(bool recreateIfPresent = false);

        public virtual async Task DeleteAsync()
        {
            try
            {
                var request = new DeleteTableRequest
                {
                    TableName = Name
                };
                var response = await ClientContext.Client.DeleteTableAsync(request);
                // ....
            }
            catch (Exception ex)
            {
                // What to do???
                // Logger.Warn($"Failed to delete the table, {Name}. {ex.Message}");
                throw ex;
            }
        }

        public virtual async Task PurgeAsync(bool createIfAbsent = false)
        {
            var isCurrentlyPresent = await IsPresentAsync();
            if (isCurrentlyPresent)
            {
                // ???
                await DeleteAsync();
            }
            if(isCurrentlyPresent || createIfAbsent)
            {
                // ???
                await CreateAsync();
            }
        }
    }
}
