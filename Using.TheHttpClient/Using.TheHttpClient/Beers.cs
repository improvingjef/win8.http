using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using.TheHttpClient
{
    public class Brewery
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Beer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double abv { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public Brewery brewery { get; set; }
    }

    public class BeerList
    {
        public int page { get; set; }
        public int pages { get; set; }
        public int total { get; set; }
        public List<Beer> beers { get; set; }
    }
}
