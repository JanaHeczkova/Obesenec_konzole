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
        public string substring = "_";
        public int PocetNeuspesnychPokusu = 0;
        public int PomocnyPocetPokusu = 0;
        public string[] poleHadanychSlov =
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
        
        public void VymysliSiNoveSlovo()
            {
            Random generatorNahodnychCisel = new Random();
            int nahodneCislo = generatorNahodnychCisel.Next(24);
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

        public void JePismenoObsazeneVeSlove(Hrac hrac)
        {
            for (int j = 0; j < VymysliSiSlovo.Length; j++) // Cyklus kontrolující, zda je zadné písmeno obsaženo v daném slově
            {
                if (hrac.HadanePismeno == VymysliSiSlovo[j])
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(VratCastecneOdhaleneSlovo);
                    sb[j] = hrac.HadanePismeno;
                    VratCastecneOdhaleneSlovo = sb.ToString(); //Pokud se uživatel trefí, tak se dané písmeno doplní do hádaného slova
                }
                else if (hrac.HadanePismeno != VymysliSiSlovo[j]) //Pokud se uživatel netrefí, tak se navýší pomocná proměnná o 1
                {
                    PomocnyPocetPokusu++;
                }
            }
        }
    }
}
