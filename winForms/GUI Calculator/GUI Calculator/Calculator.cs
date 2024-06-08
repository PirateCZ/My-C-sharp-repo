using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }
        public void CreateTextCZ()
        {
            this.label1.Text = "Číslo1";
            this.label2.Text = "Číslo2";
            this.label3.Text = "Znaménko";
            this.res.Text = "Výsledek";
            this.calculate.Text = "Vypočítej"; 
        }
        public void CreateTextEN()
        {
            this.label1.Text = "Num1";
            this.label2.Text = "Num2";
            this.label3.Text = "Operator";
            this.res.Text = "Result";
            this.calculate.Text = "Calculate";
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void calculate_Click(object sender, EventArgs e)
        {
            errorMsg.Visible = false;
            double num1;
            double num2;
            char @operator;
            double result = double.MinValue; 
            //parse 1st number
            try
            {
                num1 = double.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                errorMsg.Text = ex.Message;
                errorMsg.Visible = true;
                return;
            }

            //parse 2nd number
            try
            {
                num2 = double.Parse(textBox2.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                errorMsg.Text = ex.Message;
                errorMsg.Visible = true;
                return;
            }

            //parse operator
            try
            {
                @operator = char.Parse(comboBox1.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                errorMsg.Text = ex.Message;
                errorMsg.Visible = true;
                return;
            }

            try
            {
                if(@operator == '+')
                {
                    result = num1 + num2;
                }
                else if(@operator == '-')
                {
                    result = num1 - num2;
                }
                else if(@operator == '*')
                {
                    result = num1 * num2;
                }
                else if(@operator == '/')
                {
                    result = num1 / num2;
                }
                else errorMsg.Text = "ur restarted";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                errorMsg.Text = ex.Message;
                errorMsg.Visible = true;
                return;
            }
            res.Text = result.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";

        }
    }
}