using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlayoffBracket.Models;

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

        public List<Team> generateTeams(List<string> playerNames)
        {
            List<Team> listOfTeams = new List<Team>();

            foreach (var Name in playerNames)
            {
                Team tmpTeam = new Team();
                tmpTeam.TeamName = Name;
                tmpTeam.GamesPlayed = 0;
                tmpTeam.Losses = 0;
                tmpTeam.Points = 0;
                tmpTeam.ScoresAgainst = 0;
                tmpTeam.ScoresForward = 0;
                tmpTeam.Ties = 0;
                tmpTeam.Wins = 0;
                listOfTeams.Add(tmpTeam);
            }

            return listOfTeams;
        }
    }
}