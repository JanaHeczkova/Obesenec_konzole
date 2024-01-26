using Oběšenec_třídy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Oběšenec_třídy
{
    internal class HadaneSlovo
    {
        public string VymysliSiSlovo = string.Empty;
        public string VratCastecneOdhaleneSlovo = string.Empty;
        private string substring = "_";
        public int PocetNeuspesnychPokusu = 0;
        public int CelkovyPocetPokusu = 8;
        bool JePismenoVeSlove = false;
        private string[] poleHadanychSlov =
        {
            "kočka",
            "pes",
            "kráva",
            "husa",
            "prase",
            "ovce",
            "nosorožec",
            "lev",
            "žirafa",
            "slon",
            "krokodýl",
            "tygr",
            "kapybara",
            "hroch",
            "opice",
            "žížala",
            "pavouk",
            "chobotnice",
            "žralok",
            "delfín",
            "veverka",
            "medvěd",
            "bažant",
            "sysel",
            "křeček",
        }; //slova, ze kterých se postupně vybírají hádaná slova

        public void VymysleneSlovo()
        {
            Random generatorNahodnychCisel = new Random();
            int nahodneCislo = generatorNahodnychCisel.Next(poleHadanychSlov.Length);
            //Console.WriteLine(nahodneCislo);
            VymysliSiSlovo = poleHadanychSlov[nahodneCislo]; //náhodně se vygeneruje hádané slovo z pole
        }

        public void VygenerujCastecneOdhaleneSlovo() //vygeneruje zakryté slovo o stejném počtu znaků.
        {
            for (int k = 0; k < VymysliSiSlovo.Length; k++)
            {
                VratCastecneOdhaleneSlovo = VratCastecneOdhaleneSlovo + "_";
            }
            //Console.WriteLine(VratCastecneOdhaleneSlovo);
        }

        public bool JePismenoObsazeneVeSlove(char hadanePismeno)
        {
            JePismenoVeSlove = false;
            for (int j = 0; j < VymysliSiSlovo.Length; j++) // Cyklus kontrolující, zda je zadné písmeno obsaženo v daném slově
            {
                if (hadanePismeno == VymysliSiSlovo[j])
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(VratCastecneOdhaleneSlovo);
                    sb[j] = hadanePismeno;
                    VratCastecneOdhaleneSlovo = sb.ToString(); //Pokud se uživatel trefí, tak se dané písmeno doplní do hádaného slova
                    JePismenoVeSlove = true; //
                }
            }
            return JePismenoVeSlove;
        }

        public void SpocitejPocetNeuspesnychPokusu()
        {
            if (!JePismenoVeSlove)
            {
                PocetNeuspesnychPokusu++;   //Pokud se uživatel netrefil, tak se navýší počet neúspěšných pokusů o 1
            }
        }

        Hrac hrac = new Hrac();
        public void JeSlovoUhodnute()
        {
            //bool UhadnuteSlovo = false;
            while (VratCastecneOdhaleneSlovo.Contains(substring)) //cyklus probíhá dokud není zakryté slovo celé odhalené
            {
                hrac.ZadejPismeno(); //hráč zadá písmeno
                JePismenoObsazeneVeSlove(hrac.HadanePismeno); //zkontroluje, zda je písmeno obsažené v hádaném slově
                Console.Clear();
                hrac.VratUzZadanaPismena();
                Console.WriteLine(VratCastecneOdhaleneSlovo); //vypíše částečně odhalené slovo
                SpocitejPocetNeuspesnychPokusu();

                if (PocetNeuspesnychPokusu == CelkovyPocetPokusu) //Pokud uživatel 5X chyboval, tak se cyklus ukončí
                {
                break;
                }
            }
            if (PocetNeuspesnychPokusu == CelkovyPocetPokusu)
            {
             Console.WriteLine("Bohužel jsi prohrál. Hádané slovo bylo: " + VymysliSiSlovo);        
            }
            else
            {
            Console.WriteLine("Gratuluji k vítězství!");
            }
        }
    }
}
