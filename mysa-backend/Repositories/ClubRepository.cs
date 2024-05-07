using Amazon.DynamoDBv2.DataModel;
using mysa_backend.DynamoModels;

namespace mysa_backend.Repositories
{
    public class ClubRepository : EntityRepository<ClubEntity>, IClubRepository
    {
        public ClubRepository(IDynamoDBContext context) : base(context)
        {

        }

        public async Task<ClubEntity?> GetEntity(string clubName, string city)
        {
            var template = new ClubEntity(clubName, city);
            return await base.GetEntity(template);
        }

        public async Task<ClubEntity?> GetEntity(ClubEntity template) => await base.GetEntity(template);

        public async Task SaveEntity(ClubEntity template) => await base.SaveEntity(template);
    }
}
