using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3.BonusChallenge
{
    public class BonusModel
    {
        public List<List<string>> AnagramGroups { get; set; }

        public BonusModel()
        {
            AnagramGroups = new List<List<string>>();
        }
    }
}