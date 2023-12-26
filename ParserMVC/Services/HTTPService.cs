namespace parser.Services
{
    public class HTTPService
    {
        public async Task<string> GetHTMLAsync(string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}