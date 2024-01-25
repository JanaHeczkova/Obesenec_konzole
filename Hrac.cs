using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oběšenec_třídy
{
    internal class Hrac
    {
    public char HadanePismeno;
    public string UzHadanaPismena = string.Empty;
    //public string ZadanePismeno = string.Empty;


        public void ZadejPismeno()
        {
        Console.WriteLine("Hádej písmeno.");
        ConsoleKeyInfo userInput = Console.ReadKey();
        HadanePismeno = userInput.KeyChar;
        }
        public void VratUzZadanaPismena()
        {
        UzHadanaPismena = UzHadanaPismena + HadanePismeno;
        Console.WriteLine();
        Console.WriteLine("Uživatel už zadal:" + UzHadanaPismena);
        }
    }
}
