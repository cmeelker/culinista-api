using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Culinista.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<string> GetNickNameAsync([FromQuery] string userId)
        {
            // TO DO: Bij het starten van app client maken met bearer token. Dan kan je er met dependency injection bij elke controller bij.
            var auth0Domain = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Auth0")["Domain"];

            var authenticationApiClient = new AuthenticationApiClient(auth0Domain);

            // TO DO: Secrets uit Key Vault halen
            var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                ClientId = "FzRgPg8Rusf82qUpzRJKlfa5NctBfwhF",
                ClientSecret = "zkM4s7JhlgYwDmgMkA_sEYw7qFFSoHmO6YNu-oSxLranrq3gCn3xLS6MUjOswf1H",
                Audience = "https://dev-wmo7dfmg.us.auth0.com/api/v2/"
            });

            var client = new ManagementApiClient(token.AccessToken, auth0Domain);
            var nickName = client.Users.GetAsync(userId).Result.NickName;

            return nickName;
        }
    }
}