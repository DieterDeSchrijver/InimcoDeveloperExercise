namespace InimcoDeveloperExercise.DTO.Responses;

public record InimcoUserResponse()
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ReversedFirstName { get; set; }
    public string ReversedLastName { get; set; }
    public int Vowels { get; set; }
    public int Consonants { get; set; }
}