using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuesstimateScoring
{
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public int score { get; set; }

        public Player(int Id)
        {
            this.score = 0;
            this.id = Id;
        }
    }
}
