using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using mysa_backend.DynamoModels;

namespace mysa_backend.Repositories
{
    public class ShootRepository : EntityRepository<ShootEntity>, IShootRepository
    {
        public ShootRepository(IDynamoDBContext context) : base(context)
        {

        }

        public async Task<ShootEntity?> GetEntity(string id, string clubName)
        {
            var template = new ShootEntity(id, clubName);
            return await base.GetEntity(template);
        }

        public async Task<ShootEntity[]?> ListShoots(string? paginationToken = null)
        {
            var filter = new ScanFilter();
            filter.AddCondition("PK", ScanOperator.BeginsWith, ShootEntity.Prefix);

            var config = new ScanOperationConfig()
            {
                Filter = filter,
                PaginationToken = paginationToken,
            };

            return await base.GetEntities(config);
        }

        public async Task<ShootEntity[]?> ListShootsByDate(DateTime date, string? paginationToken = null)
        {
            var template = new ShootEntity(date);
            var config = new QueryOperationConfig()
            {
                Filter = new QueryFilter("SK", QueryOperator.Equal, template.GSI1PK),
                PaginationToken = paginationToken
            };

            return await base.GetEntities(config);
        }

        public async Task<ShootEntity[]?> ListShootsAfterDate(DateTime date, string? paginationToken = null)
        {
            var template = new ShootEntity(date);
            var config = new QueryOperationConfig()
            {
                Filter = new QueryFilter("SK", QueryOperator.GreaterThan, template.GSI1PK),
                PaginationToken = paginationToken
            };

            return await base.GetEntities(config);
        }

        public async Task<ShootEntity[]?> ListShootsByClub(string clubName, string? paginationToken = null)
        {
            var template = new ShootEntity(clubName);
            var config = new QueryOperationConfig()
            {
                IndexName = "GSI1",
                Filter = new QueryFilter("GSI1-PK", QueryOperator.Equal, template.SK),
                PaginationToken = paginationToken
            };

            return await base.GetEntities(config);
        }

        public async Task<ShootEntity?> GetEntity(ShootEntity template) => await base.GetEntity(template);

        public async Task SaveEntity(ShootEntity template) => await base.SaveEntity(template);
    }
}
