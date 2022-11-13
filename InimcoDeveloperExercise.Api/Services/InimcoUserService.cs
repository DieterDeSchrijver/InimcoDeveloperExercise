using InimcoDeveloperExercise.DTO.Requests;
using InimcoDeveloperExercise.DTO.Responses;
using InimcoDeveloperExercise.Models;

namespace InimcoDeveloperExercise.Services;

public class InimcoUserService
{
    public InimcoUserResponse EnrichInimcoUser(InimcoUser inimcoUser)
    {
        CountVowelAndConsonants(inimcoUser.FirstName + inimcoUser.LastName, out var vowels, out var consonants);
        
        return new InimcoUserResponse()
        {
            FirstName = inimcoUser.FirstName,
            LastName = inimcoUser.LastName,
            Vowels = vowels,
            Consonants = consonants,
            ReversedFirstName = Reverse(inimcoUser.FirstName),
            ReversedLastName = Reverse(inimcoUser.LastName)
        };
    }

    private static void CountVowelAndConsonants(string word, out int vowels, out int consonants)
    {
        word = word.ToLower();
        vowels = 0;
        consonants = 0;
        int i;
        // find length
        var len = word.Length;
        for (i = 0; i < len; i++)
        {
            switch (word[i])
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    vowels++;
                    break;
                case >= 'a' and <= 'z':
                    consonants++;
                    break;
            }
        }
    }
    
    

    private static string Reverse(string s)
    {
        var charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}