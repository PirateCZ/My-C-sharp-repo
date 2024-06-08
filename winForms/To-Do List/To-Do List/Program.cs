using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new listOfTask());

        }
    }
}
