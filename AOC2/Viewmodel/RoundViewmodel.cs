using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2.Viewmodel
{
    internal class RoundViewmodel
    {
        public int red {  get; set; }
        public int green { get; set; }
        public int blue { get; set; }

        public RoundViewmodel(int _red, int _green, int _blue)
        {
            red = _red;
            green = _green;
            blue = _blue;
        }
    }
}
