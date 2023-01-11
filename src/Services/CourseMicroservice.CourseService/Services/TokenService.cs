using System.IdentityModel.Tokens.Jwt;

namespace CourseMicroservice.CourseService.Services;

public class TokenService
{
    public async Task<string> GetUserIdWithTheTokenAsync(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwt);
        return token.Subject == null ? "no id in this token" : token.Subject;
    }           
                
                                                                                            
                  
}