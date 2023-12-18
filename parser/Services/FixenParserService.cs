using System.Text.RegularExpressions;

namespace parser.Services
{
    public class FixenParserService
    {
        private Regex regex = new Regex("<p class=\"\"[a-zA-Z\\s]*price[a-zA-Z\\s]*\"\">[<a-zA-Z>\\\\]*<span class=\"\"[a-zA-Z\\s]*woocommerce-Price-amount amount[a-zA-Z\\s]*\"\"><bdi>(\\d+)");

        private int Parse(string input) 
        {
            var price = regex.Match(input).Groups[1].Value;
            return int.TryParse(price, out var priceinteger) ? priceinteger : 0;
        }

        private async Task<string> GetHTMLAsync(Uri input)
        {
            HttpClient httpClient = new HttpClient();
            var response =await httpClient.GetAsync(input);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<int> GetPriceAsync(Uri input)
        {
            string html = await GetHTMLAsync(input);
            return Parse(html);
        }
    }
}
