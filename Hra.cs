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
            Console.WriteLine("Hádej slovo pomocí písmen. Pokud se 5X netrefíš, tak jsi prohrál.");
            Console.WriteLine();

            HadaneSlovo hadaneSlovo = new HadaneSlovo();
            Hrac hrac = new Hrac();
            hadaneSlovo.VymysliSiNoveSlovo(); //vygeneruje se hádané slovo
            hadaneSlovo.VygenerujCastecneOdhaleneSlovo(); //vygeneruje se zakryté slovo o stejném počtu znaků


            while (hadaneSlovo.VratCastecneOdhaleneSlovo.Contains(hadaneSlovo.substring)) //cyklus probíhá dokud není zakryté slovo celé odhalené
            {
                hrac.ZadejPismeno(); //hráč zadá písmeno
                hadaneSlovo.JePismenoObsazeneVeSlove(hrac); //zkontroluje, zda je slovo obsažené v hádaném slově
                Console.Clear();
                hrac.VratUzZadanaPismena(); //vypíše částečně odhalené slovo
                Console.WriteLine(hadaneSlovo.VratCastecneOdhaleneSlovo);

                if (hadaneSlovo.PomocnyPocetPokusu == hadaneSlovo.VymysliSiSlovo.Length)
                {
                    hadaneSlovo.PocetNeuspesnychPokusu++;   //navýší počet neúspěšných pokusů o 1
                }

                hadaneSlovo.PomocnyPocetPokusu = 0; //vynuluje se počet pomocných pokusů


                if (hadaneSlovo.PocetNeuspesnychPokusu == 5) //Pokud uživatel 5X chyboval, tak se cyklus ukončí
                {
                break;
                }
            }
            if (hadaneSlovo.PocetNeuspesnychPokusu == 5)
            {
                Console.WriteLine("Bohužel jsi prohrál. Hádané slovo bylo: " + hadaneSlovo.VymysliSiSlovo); //Hláška v případě, že uživatel 5X chyboval.
            }
            else
            {
                Console.WriteLine("Gratuluju k vítězství."); //Pokud uživatel uhádl celé slovo, tak se vypíše hláška.
            }
        }
    }
}
