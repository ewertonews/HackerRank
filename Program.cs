using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {

            CompetitionRepository competitionRepository = new CompetitionRepository("https://jsonmock.hackerrank.com/api/football_competitions");
            string competitionName = "UEFA Champions League";
            string competitionYear = "2011";
            var queryArgsCompetition = new Dictionary<string, string>()
            {
                 {"name", competitionName },
                { "year", competitionYear }
            };

            string winnerTeam = competitionRepository.Search(queryArgsCompetition).Result.data[0].winner;

            int year = 2011;
            int teamGoals = 0;
            string matchYear = year.ToString();
            MatchesRepository matchesRepository = new MatchesRepository("https://jsonmock.hackerrank.com/api/football_matches");

            var queryArgsTeam1 = new Dictionary<string, string>()
            {
                {"team1", winnerTeam },
                { "year", competitionYear },
                { "competition", competitionName }
            };

            var queryArgsTeam2 = new Dictionary<string, string>()
            {
                {"team2", winnerTeam },
                { "year", competitionYear },
                { "competition", competitionName }
            };

            var searchResultTeam1 = matchesRepository.Search(queryArgsTeam1);
            var searchResultTeam2 = matchesRepository.Search(queryArgsTeam2);

            teamGoals += searchResultTeam1.Result.data.ToList().Sum(m => Convert.ToInt32(m.team1goals));            
            teamGoals += searchResultTeam2.Result.data.ToList().Sum(m => Convert.ToInt32(m.team2goals));
        }
    }
}
