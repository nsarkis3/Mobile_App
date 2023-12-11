using SQLite;
using Microsoft.Maui.Graphics;
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

        private bool isPlaying;
        public bool IsPlaying
        {
            get { return isPlaying; }
            set
            {
                isPlaying = value;
                setSelected();
            }
        }
        [Ignore]
        public Color Selected { get; private set; }

        public int Completions { get; set; }

        public int Catches { get; set; }

        public int ThrowAways { get; set; }

        public int Points { get; set; }

        [Ignore]
        public string Icon 
        {
            get
            {
                switch (Position) 
                {
                    case ("Handler"): return "handler.png";
                    case ("Both"): return "both.png";
                    default: return "cutter.png";
                }
            }
        } 

        public Player(string name, string year, string pos) {
            Name = name;
            Year = year;
            Position = pos;
            IsPlaying = false;
            Completions = 0;
            Catches = 0;
            ThrowAways = 0;
        }

        public Player() {
            Name = "";
            Year = "";
            Position = "";
            IsPlaying = false;
            Completions = 0;
            Catches = 0;
            ThrowAways = 0;
        }
        public override String ToString() {
            return String.Format("Name: {0}, Year: {1}, Pos: {2}", Name, Year, Position, IsPlaying);
        }

        public void setSelected()
        {
            if (IsPlaying) Selected = Colors.LightGreen;
            else Selected = Colors.LightSalmon;
        }
    }
}
