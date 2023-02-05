using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService
{
    List<Monkey> monkeyList = new();
    HttpClient httpClient;

    public MonkeyService()
    {
        httpClient = new HttpClient();
    }

    public async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (monkeyList.Count > 0)
            return monkeyList;

        var url = "https://montemagno.com/monkeys.json";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();

        return monkeyList;
    }
}
