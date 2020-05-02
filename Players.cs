using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuesstimateScoring
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(int Id)
        {
            this.Score = 0;
            this.Id = Id;
        }
    }
}
