using Newtonsoft.Json;

namespace InimcoDeveloperExercise.Models;

public class InimcoUser
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<string> SocialSkills { get; set; }
    public List<SocialAccount> SocialAccounts { get; set; }
    
    public InimcoUser(Guid id, string firstName, string lastName, List<string> socialSkills, List<SocialAccount> socialAccounts)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        SocialSkills = socialSkills;
        SocialAccounts = socialAccounts;
    }

}
    
