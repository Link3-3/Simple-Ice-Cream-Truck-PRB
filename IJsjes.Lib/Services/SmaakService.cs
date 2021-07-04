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
        private static readonly Random random = new Random();
        public static List<Smaak> IjsSmaken { get; set; } = new List<Smaak>
        {
            new Smaak(Smaken.Chocolade, 0.7M),
            new Smaak(Smaken.Mokka, 0.8M),
            new Smaak(Smaken.Vanille, 1)
        };
        public static Ijs MaakIjsje(List<Smaak> smaken, Verpakkingen verpakking)
        {
            Ijs ijsje = new Ijs(smaken, verpakking);
            return ijsje;
        }
        public static Ijs MaakVerrassingsIjsje(Verpakkingen verpakking)
        {
            int aantalBollen = random.Next(1, 4);
            List<Smaak> verrassingsBollen = new List<Smaak>();
            for (int i = 0; i < aantalBollen; i++)
            {
                int randomSmaak = random.Next(IjsSmaken.Count);
                Smaak smaak = IjsSmaken[randomSmaak];
                verrassingsBollen.Add(smaak);
            }
            Ijs ijsje = new Ijs(verrassingsBollen, verpakking);
            return ijsje;
        }
    }
}
