using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oběšenec_třídy
{
    internal class Hra
    {
        public void SpustSe()
        {
            HadaneSlovo hadaneSlovo = new HadaneSlovo();
            Console.WriteLine($"Hádej slovo pomocí písmen. Pokud se " + hadaneSlovo.CelkovyPocetPokusu + " X netrefíš, tak jsi prohrál.");
            Console.WriteLine();

            Hrac hrac = new Hrac();
            hadaneSlovo.VymysleneSlovo(); //vygeneruje se hádané slovo
            hadaneSlovo.VygenerujCastecneOdhaleneSlovo(); //vygeneruje se zakryté slovo o stejném počtu znaků
            hadaneSlovo.JeSlovoUhodnute();

            while (hadaneSlovo.JeSlovoUhodnute()) //cyklus probíhá dokud není zakryté slovo celé odhalené
            {
                hrac.ZadejPismeno(); //hráč zadá písmeno
                hadaneSlovo.JePismenoObsazeneVeSlove(hrac.HadanePismeno); //zkontroluje, zda je písmeno obsažené v hádaném slově
                Console.Clear();
                hrac.VratUzZadanaPismena();
                Console.WriteLine(hadaneSlovo.VratCastecneOdhaleneSlovo); //vypíše částečně odhalené slovo

                if (hadaneSlovo.PocetNeuspesnychPokusu == hadaneSlovo.CelkovyPocetPokusu) //Pokud uživatel 5X chyboval, tak se cyklus ukončí
                {
                    break;
                }
            }
            if (hadaneSlovo.PocetNeuspesnychPokusu == hadaneSlovo.CelkovyPocetPokusu)
            {
                Console.WriteLine("Bohužel jsi prohrál. Hádané slovo bylo: " + hadaneSlovo.VymysliSiSlovo);
            }
            else
            {
                Console.WriteLine("Gratuluji k vítězství!");
            }
        }
    }
}
