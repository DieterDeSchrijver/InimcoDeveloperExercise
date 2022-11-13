using InimcoDeveloperExercise.IRepositories;
using InimcoDeveloperExercise.Models;
using Microsoft.Azure.Cosmos;


namespace InimcoDeveloperExercise.CosmosDB.Repositories;

public class SocialAccountTypeCosmosRepository : ISocialAccountTypeCosmosRepository
{
    private readonly Container _container;
    public SocialAccountTypeCosmosRepository(CosmosClient cosmosClient,
        string databaseName,
        string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }

    public async Task<List<string>> Get()
    {
        //return mock data to simplify project.
        var list = new List<string>();
        list.Add("Facebook");
        list.Add("LinkedIn");
        list.Add("Twitter");
        list.Add("Instagram");
        return list;    
    }
}