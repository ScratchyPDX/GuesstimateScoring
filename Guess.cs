using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuesstimateScoring
{
    public class Guess
    {
        public int playerId { get; set; }
        public int guessValue { get; set; }
        public int overUnderValue {get; set;}

        public Guess(int Id)
        {
            playerId = Id;
        }
    }
}
