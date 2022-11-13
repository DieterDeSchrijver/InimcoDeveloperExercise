using InimcoDeveloperExercise.IRepositories;
using InimcoDeveloperExercise.Models;
using Microsoft.Azure.Cosmos;


namespace InimcoDeveloperExercise.CosmosDB.Repositories;

public class InimcoUserCosmosRepository : IInimcoUserCosmosRepository
{
    private readonly Container _container;
    public InimcoUserCosmosRepository(CosmosClient cosmosClient,
        string databaseName,
        string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }
    
    public async Task<InimcoUser> AddAsync(InimcoUser inimcoUser)
    {
        var item = await _container.CreateItemAsync<InimcoUser>(inimcoUser);
        return item;
    }
}