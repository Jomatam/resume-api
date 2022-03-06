using CvApp.Repositories.Exceptions;
using Microsoft.Azure.Cosmos;

namespace CvApp.Repositories
{
    public abstract class BaseRepository<TRepository, TEntity>
        where TRepository : BaseRepository<TRepository, TEntity>
    {
        private const string PartitionKey = "/_partitionKey";
        private readonly RepositoryOptions _options;

        protected BaseRepository(RepositoryOptions options)
        {
            _options = options;
        }

        protected Container Container { get; private set; }

        protected abstract string ContainerName { get; }

        protected async Task<TEntity> GetByIdAsync(string id, PartitionKey partitionKey)
        {
            try
            {
                var response = await Container.ReadItemAsync<TEntity>(id, partitionKey);
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new EntityNotFoundException(id);
            }
        }

        public async Task<TRepository> InitializeAsync()
        {
            var client = new CosmosClient(_options.Account, _options.AccountKey);
            var database = await client.CreateDatabaseIfNotExistsAsync(_options.DatabaseName);
            var container = await database.Database.CreateContainerIfNotExistsAsync(ContainerName, PartitionKey);
            Container = container.Container;
            return (TRepository)this;
        }
    }
}
