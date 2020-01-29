using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IJsjes.Lib.Entities;

namespace IJsjes.Lib.Services
{
    public class SmaakService
    {
        public static List<Smaak> IjsSmaken { get; set; } = new List<Smaak>
        {
            new Smaak(Smaken.Chocolade, 0.7M),
            new Smaak(Smaken.Mokka, 0.8M),
            new Smaak(Smaken.Vanille, 1)
        };
    }
}
