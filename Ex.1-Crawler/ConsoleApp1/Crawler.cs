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
			// Check if argument was given
			if (args.Length == 0)
			{
				throw new ArgumentNullException();
			}
			string website = args[0];

			// Check if argument is a proper URL
			Regex URLregex = new Regex(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]+\.[a-zA-Z0-9()]+\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)");
			if (!URLregex.IsMatch(website))
            {
				throw new ArgumentException();
            }

			HttpClient httpClient = new HttpClient();
			HttpResponseMessage response = await httpClient.GetAsync(website);
			string body = await response.Content.ReadAsStringAsync();

			Regex regex = new Regex(@"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+");

			var match = regex.Matches(body);

			foreach (var item in match)
			{
				Console.WriteLine(item);
			}

			httpClient.Dispose();
			response.Dispose();
		}
	}
}
