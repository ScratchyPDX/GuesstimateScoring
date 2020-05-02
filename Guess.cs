using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuesstimateScoring
{
    public class Guess
    {
        public int PlayerId { get; set; }
        public int GuessValue { get; set; }
        public int OverUnderValue {get; set;}

        public Guess(int Id)
        {
            PlayerId = Id;
        }
    }
}
