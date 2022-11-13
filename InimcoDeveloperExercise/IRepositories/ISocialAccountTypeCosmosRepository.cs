using InimcoDeveloperExercise.Models;

namespace InimcoDeveloperExercise.IRepositories;

public interface ISocialAccountTypeCosmosRepository
{
    Task<List<string>> Get();
}