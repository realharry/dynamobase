using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using AWSCore.DynamoBase.Clients;

namespace AWSCore.DynamoBase.Clients.Impl
{
    public class DefaultDynamoDBClientContext : IDynamoDBClientContext
    {
        private AmazonDynamoDBClient client = null;

        public DefaultDynamoDBClientContext(AmazonDynamoDBClient client = null)
        {
            this.client = client;
        }
        public DefaultDynamoDBClientContext(AWSCredentials credentials)
            : this(credentials, GetDefaultConfig())
        {
        }
        private DefaultDynamoDBClientContext(AmazonDynamoDBConfig config)
            : this(GetDefaultCredentials(), config)
        {
        }
        public DefaultDynamoDBClientContext(AWSCredentials credentials, AmazonDynamoDBConfig config)
            : this(new AmazonDynamoDBClient(credentials, config))
        {
        }

        public AmazonDynamoDBClient Client
        {
            get
            {
                // ????
                if (client == null)
                {
                    client = new AmazonDynamoDBClient(GetDefaultConfig());
                }
                return client;
            }
        }

        // temporary
        private static AWSCredentials GetDefaultCredentials()
        {
            // ???
            return null;
        }
        // temporary
        private static AmazonDynamoDBConfig GetDefaultConfig()
        {
            AmazonDynamoDBConfig config = new AmazonDynamoDBConfig();
            config.RegionEndpoint = Amazon.RegionEndpoint.USWest2;
            config.ServiceURL = "http://localhost:8000";
            // ...
            return config;
        }
    }
}
