using System.ComponentModel.DataAnnotations;

namespace InimcoDeveloperExercise.DTO.Requests;

public record InimcoUserRequest()
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string FirstName { get; init; }
    [Required]
    public string LastName { get; init; }
    public List<string>? SocialSkills { get; init; }
    public List<SocialAccountRequest>? SocialAccounts { get; init; }
}