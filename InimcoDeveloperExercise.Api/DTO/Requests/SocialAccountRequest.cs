using System.ComponentModel.DataAnnotations;

namespace InimcoDeveloperExercise.DTO.Requests;

public record SocialAccountRequest()
{
    [Required]
    public string? Type { get; init; }
    [Required]
    public string? Address { get; init; }
}