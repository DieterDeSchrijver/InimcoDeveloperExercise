namespace InimcoDeveloperExercise.Models;

public struct SocialAccount
{
    public SocialAccount(string type, string address)
    {
        Type = type;
        Address = address;
    }

    public string Type { get; set; }
    public string Address { get; set; }
}