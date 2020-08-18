using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFive_ProgramUI.Consoles
{
    public interface IConsole
    {
        void WriteLine(string s);
        void WriteLine(object o);
        void Write(string s);
        void Clear();
        string ReadLine();
        ConsoleKeyInfo ReadKey();
    }
}
