using IJsjes.Lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJsjes.Lib.Services
{
    public class Ijs
    {
        public List<Smaak> Bollen { get; set; }
        public Verpakkingen Verpakkingen { get; set; }
        public decimal TotaalBedrag { get; set; }
        public Ijs(List<Smaak> smaken, Verpakkingen verpakkingen)
        {
            Bollen = smaken;
            Verpakkingen = verpakkingen;
            TotaalBedrag = smaken.Sum(smaak => smaak.Prijs);
        }
        public override string ToString()
        {
            string result = $"Een {Verpakkingen.ToString().ToLower()} met:";
            foreach (Smaak item in Bollen)
            {
                result += $"\n- {item.SmaakSoort}: {item.Prijs.ToString("C2")}";
            }
            result += "\n----------";
            result += $"\nTotaal:\t{TotaalBedrag.ToString("C2")}";
            return result;
        }
    }
}
