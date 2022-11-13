using System.Web.Http;
using System.Web.Http.Results;
using InimcoDeveloperExercise.Controllers;
using InimcoDeveloperExercise.DTO.Requests;
using InimcoDeveloperExercise.Exceptions;
using InimcoDeveloperExercise.IRepositories;
using InimcoDeveloperExercise.Models;
using InimcoDeveloperExercise.Services;
using Moq;

namespace InimcoDeveloperExercise.UnitTests;

public class Tests
{
    [Test]
    public void CreateUserWithInvalidSocialAccountTypeThrowsException()
    {
        var mockRepository = new Mock<ISocialAccountTypeCosmosRepository>();
        var mockRepositoryUser = new Mock<IInimcoUserCosmosRepository>();
        var mockRepositoryService = new Mock<InimcoUserService>();

        var userRequest = new InimcoUserRequest()
        {
            FirstName = "Dieter",
            LastName = "De Schrijver",
            SocialSkills = new List<string>() { "Value" },
            SocialAccounts = new List<SocialAccountRequest>()
            {
                new()
                {
                    Type = "Feestboek",
                    Address = "www.feestboek.com/dieter"
                }
            }
        };
        
        mockRepository.Setup(x => x.Get())
            .Returns(Task.FromResult(new List<string>{"Facebook", "Instagram"}));

        var controller = new UserController(mockRepositoryUser.Object, mockRepository.Object, mockRepositoryService.Object);
        
        Assert.ThrowsAsync<SocialAccountTypeNotFoundException>(() =>  controller.CreateUser(userRequest));
    }
}