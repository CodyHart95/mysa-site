using Amazon.DynamoDBv2.DataModel;
using mysa_backend.DynamoModels;

namespace mysa_backend.Repositories
{
    public class ShooterScoreRepo : EntityRepository<ShooterScoreEntity>, IShooterScoreRepo
    {
        public ShooterScoreRepo(IDynamoDBContext context) : base(context)
        {
        }

        public async Task<ShooterScoreEntity?> GetEntity(string shooterId, string shootId)
        {
            var template = new ShooterScoreEntity(shooterId, shootId);
            return await base.GetEntity(template);
        }

        public async Task<ShooterScoreEntity?> GetEntity(ShooterScoreEntity template) => await base.GetEntity(template);

        public async Task SaveEntity(ShooterScoreEntity template) => await base.SaveEntity(template);
    }
}
