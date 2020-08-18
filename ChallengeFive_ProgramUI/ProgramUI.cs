using ChallengeFive_ProgramUI.Consoles;
using ChallengeFive_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFive_ProgramUI
{
    public class ProgramUI
    {
        private bool _isRunning = true;
        private readonly IConsole _console;
        private readonly CustomerRepository _custRepo = new CustomerRepository();
        ProgramUI(IConsole console)
        {
            _console = console;
        }

        public void Start()
        {
            RunMenu();
        }
        private void RunMenu()
        {

        }
    }
}
