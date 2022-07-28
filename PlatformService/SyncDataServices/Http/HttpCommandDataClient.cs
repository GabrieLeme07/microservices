using PlatformService.Dtos;
using System.Text;
using System.Text.Json;

namespace PlatformService.SyncDataServices.Http;
public class HttpCommandDataClient : ICommandDataClient
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }

    public async Task SendPlatformToCommand(PlatformReadDto plat)
    {
        var httpContent = new StringContent(
            JsonSerializer.Serialize(plat),
            Encoding.UTF8,
            "application/json");
        var requestUri = _configuration["CommandService"];
        var response = await _httpClient.PostAsync(requestUri, httpContent);

        if (response.IsSuccessStatusCode)
            Console.WriteLine("---> Sync POST to Command Services was OK!");

        else
            Console.WriteLine("---> Sync POST to Command Services was NOT OK!");
    }
}

