using InimcoDeveloperExercise.Models;

namespace InimcoDeveloperExercise.IRepositories;

public interface IInimcoUserCosmosRepository
{
    Task<InimcoUser> AddAsync(InimcoUser inimcoUser);
}