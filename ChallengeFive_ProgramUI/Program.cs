using ChallengeFive_ProgramUI.Consoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFive_ProgramUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RealConsole console = new RealConsole();
            ProgramUI ui = new ProgramUI(console);
            ui.Start();
        }
    }
}
