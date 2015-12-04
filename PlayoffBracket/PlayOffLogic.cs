using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayoffBracket
{
    public class PlayOffLogic
    {

        public List<String> getPlayers(int amountOfPlayers)
        {
            List<String> players = new List<string>();
            for (int i = 1; i <= amountOfPlayers; i++)
            {
                players.Add("Player" + i);
            }
            return players;
        }

    }
}