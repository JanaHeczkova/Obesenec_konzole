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

        }
    }
}
