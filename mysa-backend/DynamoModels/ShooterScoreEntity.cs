using Amazon.DynamoDBv2.DataModel;

namespace mysa_backend.DynamoModels
{
    [DynamoDBTable(EntityConstants.TableName)]
    public class ShooterScoreEntity : EntityBase
    {
        private const string keyPrefix = "SCORE";

        public ShooterScoreEntity(string shooterId, string shootId) 
        {
            this.PK = $"{keyPrefix}-{shooterId}";
            this.SK = $"{keyPrefix}-{shootId}";
        }

        public int Squad { get; set; }
        public bool[] Score { get; set; }
    }
}
