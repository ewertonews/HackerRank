using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{

    public class CompetitionModel
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public CompetitionData[] data { get; set; }
    }

    public class CompetitionData
    {
        public string name { get; set; }
        public string country { get; set; }
        public int year { get; set; }
        public string winner { get; set; }
        public string runnerup { get; set; }
    }

}
