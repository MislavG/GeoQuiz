using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace GeoQuiz.Models
{
    
    public class CheckContinent
    {
        public List<string> Continents
        {
            get
            {
                List<string> continent = new List<string>();
                continent.Add("Europe");
                continent.Add("Africa");
                continent.Add("Asia");
                continent.Add("North America");
                continent.Add("South America");
                continent.Add("Australia");
                continent.Add("Whole World");
                return continent;
            }
        }
    }
}
