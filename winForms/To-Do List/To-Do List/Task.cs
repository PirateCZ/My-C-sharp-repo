using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List
{
    internal class Task : CheckBox
    {
        private CheckBox checkBox1;
        string name;
        public Task(string name)
        {
            this.name = name;
        }
    }
}
