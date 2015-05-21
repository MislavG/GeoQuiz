using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoQuiz.Models
{
    public class CheckContinentViewModel
    {
        public IEnumerable<CheckContinent> AvailableCheckContinents { get; set; }
        public IEnumerable<CheckContinent> SelectedCheckContinents { get; set; }
        public PostedCheckContinents PostedCheckContinents { get; set; }
    }
}