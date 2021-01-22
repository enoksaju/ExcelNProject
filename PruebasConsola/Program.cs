using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas.VariablesCriticas;
using libProduccionDataBase.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using Google.Protobuf;

namespace PruebasConsola
{
	class Program
	{
		static void Main(string[] args)
		{

			using (var client = new HttpClient())
			{
				var joke = client.GetStringAsync(@"https://api.chucknorris.io/jokes/random").Result;


				var returnedObject = Random.deserialize(joke);
				string value = returnedObject.value;

				Console.WriteLine(value);
			}


			Console.ReadLine();
		}
	}

	public class Random
	{
		public string[] categories { get; set; }
		public DateTime created_at { get; set; }
		public string icon_url { get; set; }
		public string Id { get; set; }
		public DateTime updated_at { get; set; }
		public string url { get; set; }
		public string value { get; set; }

		public static Random deserialize(string res)
		{
			return JsonConvert.DeserializeObject<Random>(res);
		}
	}
}
