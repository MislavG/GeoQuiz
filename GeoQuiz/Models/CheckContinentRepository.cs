using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoQuiz.Models
{
    public class CheckContinentRepository
    {
        public static CheckContinent Get(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id.Equals(id));
        }
        public static IEnumerable<CheckContinent> GetAll()
        {
            return new List<CheckContinent> {
                              new CheckContinent {Name = "Europe", Id = 1 },
                              new CheckContinent {Name = "Africa", Id = 2},
                              new CheckContinent {Name = "Asia", Id = 3},
                              new CheckContinent {Name = "North America", Id = 4},
                              new CheckContinent {Name = "South America", Id = 5},
                              new CheckContinent {Name = "Australia", Id = 6},
                              new CheckContinent {Name = "Whole World", Id = 7}
                            };
        }
    }
}
