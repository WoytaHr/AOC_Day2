using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2.Viewmodel
{
    internal class GameViewmodel
    {
        public int Id { get; set; }
        public List<RoundViewmodel> Rounds { get; set; }

        public GameViewmodel(string gameID, string line)
        {
            Rounds = new List<RoundViewmodel>();
            string test = gameID.Remove(0, 5);
            Id = int.Parse(test);
            string[] rounds = line.Split(";");
            foreach (string s in rounds)
            {
                int red = 0;
                int green = 0;
                int blue = 0;
                string[] colours = s.Split(",");
                foreach (string colour in colours)
                {
                    
                    if (colour.Contains("blue"))
                    {
                        blue = int.Parse(string.Concat(colour.Where(Char.IsDigit)));
                    }
                    if (colour.Contains("red"))
                    {
                        red = int.Parse(string.Concat(colour.Where(Char.IsDigit)));
                    }
                    if (colour.Contains("green"))
                    {
                        green = int.Parse(string.Concat(colour.Where(Char.IsDigit)));
                    }
                }
                Rounds.Add(new RoundViewmodel(red, green, blue));
            }    
        }
    }
}
