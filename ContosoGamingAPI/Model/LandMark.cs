using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoGamingAPI.Model
{
    public class LandMark
    {
        public string Name { get; set; }
        public int Distance { get; set; }

        public List<LandMark> ConnectedLandMark { get; set; }
    }
}
