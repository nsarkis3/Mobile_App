using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;
using SQLite;

namespace SymptomTracker
{
    public class Symptom
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Ignore]
        public Color BoxColor { get; private set; }
        public DateTime Datetime { get; set; }
        public string Notes { get; set; }

        private int strengthValue;
        public int Strength
        {
            get { return strengthValue; }
            set
            {
                strengthValue = value;
                setBoxColor();
            }
        }

        public void setBoxColor()
        {
            switch (Strength)
            {
                case 1:
                case 2:
                case 3:
                    BoxColor = Colors.Green;
                    break;
                case 4:
                case 5:
                case 6:
                case 7:
                    BoxColor = Colors.Orange;
                    break;
                case 8:
                case 9:
                case 10:
                    BoxColor = Colors.Red;
                    break;
                default:
                    break;
            }
        }
        public Symptom(DateTime date, string note, int strength)
        {
            Datetime = date;
            Notes = note;
            Strength = strength;
        }
        public Symptom() { }
    }
}
