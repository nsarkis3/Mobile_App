using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class Line
    {
        public string LineName { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        
        public Line()
        {
            LineName = "Offense";
            Players = new List<Player>();
        }

        public Line(string lName, List<Player> players)
        {
            LineName = lName;
            Players = players;
        }

    }
}
