using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJsjes.Lib.Entities
{
    public class Smaak
    {
        public Guid Id{ get; set;}

        public decimal Prijs{ get; set;}

        public Smaken SmaakSoort { get; set; }

        public static int MaxId { get; set; }

        public Smaak(Smaken smaak, decimal prijs, Guid? id = null)
        {
            SmaakSoort = smaak;
            Prijs = prijs;

            if (id != null)
            {
                Id = (Guid)id;

            }
            else
            {
                Id = Guid.NewGuid();
            }
            MaxId++;
        }

        public override string ToString()
        {
            return $"{SmaakSoort}: €{Prijs}";
        }

    }
}
