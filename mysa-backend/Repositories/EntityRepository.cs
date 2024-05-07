using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using mysa_backend.DynamoModels;

namespace mysa_backend.Repositories
{
    public class EntityRepository<T>  where T : EntityBase
    {
        protected readonly IDynamoDBContext context;

        protected EntityRepository(IDynamoDBContext context)
        {
            this.context = context;
        }

        protected async Task<T?> GetEntity(T entityTemplate, bool consistentRead = false)
        {
            if (string.IsNullOrWhiteSpace(entityTemplate.PK) || string.IsNullOrWhiteSpace(entityTemplate.SK))
            {
                throw new ArgumentException("PK or SK missing");
            }

            var getItemConfig = new GetItemOperationConfig()
            {
                ConsistentRead = consistentRead
            };

            var doc = await context.GetTargetTable<T>()
                .GetItemAsync(entityTemplate.PK, entityTemplate.SK, getItemConfig);


            if (doc != null)
            {
                return context.FromDocument<T>(doc);
            }

            return null;
        }

        protected async Task<T[]?> GetEntities(ScanOperationConfig scanConfig)
        {
            var table = context.GetTargetTable<T>();

            var search = table.Scan(scanConfig);

            var resultPage = await search.GetNextSetAsync();

            return resultPage.Select(context.FromDocument<T>).ToArray();
        }

        protected async Task<T[]?> GetEntities(QueryOperationConfig queryConfig)
        {
            var table = context.GetTargetTable<T>();

            var query = table.Query(queryConfig);

            var resultPage = await query.GetNextSetAsync();

            return resultPage.Select(context.FromDocument<T>).ToArray();
        }

        protected async Task<T?> SaveEntity(T entity, Expression? conditionalExpression = null)
        {
            if (entity == null)
            {
                throw new NullReferenceException("Can not save a null entity");
            }

            var doc = context.ToDocument(entity);
            var table = context.GetTargetTable<T>();

            if (table == null)
            {
                throw new NullReferenceException("No table for target entity");
            }

            Document result = null;
            if (conditionalExpression != null)
            {
                var config = new UpdateItemOperationConfig()
                {
                    ConditionalExpression = conditionalExpression
                };

                result = await table.UpdateItemAsync(doc, entity.PK, entity.SK, config);
            }
            else
            {
                result = await table.UpdateItemAsync(doc);
            }

            if (result != null)
            {
                return context.FromDocument<T>(result);
            }

            return null;
        }
    }
}
