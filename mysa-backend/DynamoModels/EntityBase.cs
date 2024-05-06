using Amazon.DynamoDBv2.DataModel;

namespace mysa_backend.DynamoModels
{
    public class EntityBase
    {
        [DynamoDBHashKey]
        public string PK { get; protected set; }

        [DynamoDBRangeKey]
        public string SK {  get; protected set; }
    }
}
