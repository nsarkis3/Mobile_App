using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Year { get; set; }
        public string Position { get; set; }

        public Player(string name, string year, string pos) {
            Name = name;
            Year = year;
            Position = pos;
        }

        public Player() {
            Name = "Name";
            Year = "Freshman";
            Position = "Neither";
        }
        public override String ToString() {
            return String.Format("Name: {0}, Year: {1}, Pos: {2}", Name, Year, Position);
        }
    }
}
