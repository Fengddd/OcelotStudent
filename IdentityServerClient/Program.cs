using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace IdentityServerClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello IdentityServer4!");
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:22723");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "identityServerApi"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);

            var client1 = new HttpClient();
            client1.SetBearerToken(tokenResponse.AccessToken);

            var response = await client1.GetAsync("http://localhost:22623/Identity/IdentityApi");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }

            Console.ReadKey();
        }
    }
}
