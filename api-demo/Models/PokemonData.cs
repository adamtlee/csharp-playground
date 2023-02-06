using System;
using ApiDemo.Models;

namespace ApiDemo.Models
{
	public class PokemonData
	{
		public PokemonData()
		{
		}
		public int count { get; set; }
		public string next { get; set; }
		public string previous { get; set; }
		public List<PokemonUrl> results { get; set; }
	}
}

