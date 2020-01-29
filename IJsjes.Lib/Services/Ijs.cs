using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IJsjes.Lib.Entities;

namespace IJsjes.Lib.Services
{
    public class Ijs

    {
        static Random random = new Random();
        public static List<Smaak> Bollen { get; set; }

        public Verpakkingen Verpakking { get; set; }

        public Ijs(Verpakkingen verpakking, bool isVerassling = false) : this(Smaken.Chocolade, 1M)
        {
            Verpakking = verpakking;

            if (isVerassling)
            {
                MaakVerassingsIjsje();
            }

        }
        public Ijs(Smaken smaak, decimal prijs)
        {
            //Smaak.SmaakSoort = smaak;
            //Smaak.Prijs = prijs;

            // nog aanmaken voor Verrassingsijsje...
        }

        public override string ToString()
        {
            string result = $"{Verpakking}\n";
            int totaal = 0;
            foreach (Smaak smaak in Bollen)
            {
                result += $"\t\t{Bollen/*Smaak*/}: € {Bollen/*Prijs*/}\n";
                totaal += 0;// Bollen.Prijs.???
            }
            result += $"Totaal: \t€ {totaal}";

            return result;
        }


        public void MaakVerassingsIjsje()
        {

        }

        public bool HeeftIjsjeBollen()
        {
            bool heeftBollen = false;
            if (true)
            {

            }
            return heeftBollen;
        }

        public Smaken VoegSmaakToe()
        {
            Smaken smaak = (Smaken)random.Next(0, 3);

            return smaak;
        }

        public void GeefSmaken(int index)
        {


        }

        public void VerwijderSmaak(int index)
        {
            try
            {

                Bollen.RemoveAt(index);

            }
            catch (Exception)
            {

                throw new Exception("De gekozen smaak kan niet verwijderd worden");
            }
        }
    }
}

