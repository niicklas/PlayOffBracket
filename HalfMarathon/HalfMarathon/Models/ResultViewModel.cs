using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HalfMarathon.Models
{
    public class ResultViewModel
    {
        public List<Result> Results { get; set; }

        public string Year { get; set; }

        public List<int> Years { get; set; }

        public bool TimeAscSortOrder { get; set; }

    }
}