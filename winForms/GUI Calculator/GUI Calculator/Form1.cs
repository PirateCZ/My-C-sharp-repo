using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI_Calculator
{
    public partial class Form1 : Form
    {
        string language;
        string filePath = "C:\\Users\\fscho\\Documents\\GitHub\\My-C-sharp-repo\\winForms\\GUI Calculator\\GUI Calculator.sln";
        public Form1()
        {
            InitializeComponent();
        }

        private void confirmLang_Click(object sender, EventArgs e)
        {
            Calculator calculatorWindow = new Calculator();
            Thread calculatorThread = new Thread(() =>
            {
                Application.Run(calculatorWindow);
            });
            calculatorThread.Start();

            language = lang.Text;
            this.Close();
            if (language == "cz")
            {
                calculatorWindow.CreateTextCZ();
            }
            else if (language == "en")
            {
                calculatorWindow.CreateTextEN();
            }
            if (remember.Checked == true)
            {

                File.Create(filePath);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
