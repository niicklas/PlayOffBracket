using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayoffBracket.Models
{
    public class Team
    {

        public string TeamName { get; set; }

        public double GamesPlayed { get; set; }
        public double Wins { get; set; }
        public int Ties { get; set; }
        public int Losses { get; set; }
        public int ScoresForward { get; set; }
        public int ScoresAgainst { get; set; }
        public int Points { get; set; }


    }
}