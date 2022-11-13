namespace InimcoDeveloperExercise.Exceptions;

[Serializable]
public class SocialAccountTypeNotFoundException : Exception
{
    public string? SocialAccountType { get; }
    
    public SocialAccountTypeNotFoundException() { }
    public SocialAccountTypeNotFoundException(string message)
        : base(message) { }
    public SocialAccountTypeNotFoundException(string message, string? socialAccountType)
        : this(message)
    {
        SocialAccountType = socialAccountType;
    }
}