using System;
using System.Xml.Linq;

namespace ApiDemo.Models
{
	public class Pokemon
	{
        public int id { get; set; }
        public string name { get; set; }
        public List<Description> descriptions { get; set; }
        public List<Move> moves { get; set; }
        public List<Name> names { get; set; }
    }
}

