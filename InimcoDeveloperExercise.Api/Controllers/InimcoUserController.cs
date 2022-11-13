using System.Net;
using System.Web.Http;
using InimcoDeveloperExercise.DTO.Requests;
using InimcoDeveloperExercise.DTO.Responses;
using InimcoDeveloperExercise.Exceptions;
using InimcoDeveloperExercise.IRepositories;
using InimcoDeveloperExercise.Models;
using InimcoDeveloperExercise.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Enum;

namespace InimcoDeveloperExercise.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IInimcoUserCosmosRepository _inimcoUserCosmosRepository;
    private readonly ISocialAccountTypeCosmosRepository _socialAccountTypeCosmosRepository;
    private readonly InimcoUserService _inimcoUserService;

    public UserController(IInimcoUserCosmosRepository inimcoUserCosmosRepository, ISocialAccountTypeCosmosRepository socialAccountTypeCosmosRepository, InimcoUserService inimcoUserService)
    {
        _inimcoUserCosmosRepository = inimcoUserCosmosRepository;
        _socialAccountTypeCosmosRepository = socialAccountTypeCosmosRepository;
        _inimcoUserService = inimcoUserService;
    }

    [Microsoft.AspNetCore.Mvc.HttpGet("social-types")]
    public async Task<IActionResult> GetSocialTypes()
    {
        return Ok(await _socialAccountTypeCosmosRepository.Get());
    }

    [Microsoft.AspNetCore.Mvc.HttpPost]
    public async Task<IActionResult> CreateUser(InimcoUserRequest userRequest)
    {
        var socialAccounts = new List<SocialAccount>();
        var availableTypes = await _socialAccountTypeCosmosRepository.Get();

        //check if social account type exists & add to list.
        if (userRequest.SocialAccounts != null)
            foreach (var userRequestSocialAccount in userRequest.SocialAccounts)
            {
                if (!availableTypes.Contains(userRequestSocialAccount.Type!))
                {
                    throw new SocialAccountTypeNotFoundException(
                        "The following Social Account Type was not found: " + userRequestSocialAccount.Type,
                        userRequestSocialAccount.Type);
                }

                socialAccounts.Add(new SocialAccount(userRequestSocialAccount.Type!, userRequestSocialAccount.Address!));
            }

        var user = new InimcoUser(userRequest.Id, userRequest.FirstName, userRequest.LastName, userRequest.SocialSkills!,
            socialAccounts);
        
        var result = await _inimcoUserCosmosRepository.AddAsync(user);

        return Ok(_inimcoUserService.EnrichInimcoUser(result));
    }
}                                    