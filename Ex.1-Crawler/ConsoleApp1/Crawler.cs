using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
	class Crawler
	{
		public async static Task Main(string[] args)
		{
			string website = args[0];
			HttpClient httpClient = new HttpClient();
			
			HttpResponseMessage response = await httpClient.GetAsync(website);
			string body = await response.Content.ReadAsStringAsync();

			Regex regex = new Regex(@".*@.*\..*");

			var match = regex.Matches(body);

			foreach (var item in match)
			{
				Console.WriteLine(item);
			}
		}
	}
}
