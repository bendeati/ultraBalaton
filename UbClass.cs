using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ubBalaton
{
    class UbClass
    {
        private string versenyzo;
        private int rajtszam;
        private string kategoria;
        private string versenyido;
        private int tavSzazalek;

        //konstruktor
        public UbClass(string sor)
        {
            string[] d = sor.Split(';');
            versenyzo = d[0];
            rajtszam = Convert.ToInt32(d[1]);
            kategoria = d[2];
            versenyido = d[3];
            tavSzazalek = Convert.ToInt32(d[4]);
        }

        //get és set
        public string Versenyzo { get => versenyzo; set => versenyzo = value; }
        public int Rajtszam { get => rajtszam; set => rajtszam = value; }
        public string Kategoria { get => kategoria; set => kategoria = value; }
        public string Versenyido { get => versenyido; set => versenyido = value; }
        public int TavSzazalek { get => tavSzazalek; set => tavSzazalek = value; }

        public double idoOraban()
        {
            string[] d = versenyido.Split(':');
            double ora = Convert.ToDouble(d[0]);
            double perc = Convert.ToDouble(d[1]);
            double masodperc = Convert.ToDouble(d[2]);
            return (ora + perc/60 + masodperc/3600);
        }
    }
}
