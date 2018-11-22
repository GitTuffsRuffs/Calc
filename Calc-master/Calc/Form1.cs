using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form, CalcForm
    {
        Calculator Calculator;

        //KONSTRUKTOR!!
        public Form1()
        {
            InitializeComponent();
            Calculator = new Calculator(this);
            List<int> memmory_list = new List<int>();
        }

        //Metoder den delar för att vara en Calcform, och kunna prata med Calculatorn
        public void setResult(string newText)
        {
            textBoxResult.Text = newText;
        }
        public void setMemory(string newMemmoiry)
        {
            textBoxMemmory.Text = newMemmoiry;
        }
        public void setHistory(string newHist)
        {
            textBoxHist.AppendText(newHist);
        }
        public void activateComma()
        {
            buttonComma.Enabled = true;
        }

        //Buttons AC, C, Back.
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            Calculator.Clear(true);
            Dummy.Focus();
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            Calculator.Clear(false);
            Dummy.Focus();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Calculator.RemoveString(textBoxResult.Text);
            Dummy.Focus();
        }

        //Buttons on form 0-9
        private void button0_Click(object sender, EventArgs e)
        {
            Calculator.AddtoString("0");
            Dummy.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Calculator.AddtoString("1");
            Dummy.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Calculator.AddtoString("2");
            Dummy.Focus();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Calculator.AddtoString("3"); 
            Dummy.Focus();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Calculator.AddtoString("4");
            Dummy.Focus();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Calculator.AddtoString("5");
            Dummy.Focus();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Calculator.AddtoString("6");
            Dummy.Focus();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Calculator.AddtoString("7");
            Dummy.Focus();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Calculator.AddtoString("8");
            Dummy.Focus();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Calculator.AddtoString("9");
            Dummy.Focus();
        }

        //Buttons on form: + , - , * , / , =, +/-, & ,
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Calculator.Operator(Calculator.ADD);
            Dummy.Focus();
        }
        private void buttonSub_Click(object sender, EventArgs e)
        {
            Calculator.Operator(Calculator.SUB);
            Dummy.Focus();
        }
        private void buttonMult_Click(object sender, EventArgs e)
        {
            Calculator.Operator(Calculator.MUL);
            Dummy.Focus();
        }
        private void buttonDiv_Click(object sender, EventArgs e)
        {
            Calculator.Operator(Calculator.DIV);
            Dummy.Focus();
        }
        private void buttonSum_Click(object sender, EventArgs e)
        {
            Calculator.Operator(Calculator.NOP);
            Dummy.Focus();
        }
        private void buttonConPol_Click(object sender, EventArgs e)
        {
            Calculator.Operator(Calculator.CPO);
            Calculator.Operator(Calculator.NOP);
            Dummy.Focus();
        }
        private void buttonComma_Click(object sender, EventArgs e)
        {
            buttonComma.Enabled = false;
            Calculator.AddtoString(",");
        }

        //Advancet %, Rot, X2, 1/X
        private void buttonProcent_Click(object sender, EventArgs e)
        {
            Calculator.Operator(Calculator.PRO);
            Calculator.Operator(Calculator.NOP);
            Dummy.Focus();
        } //% ??
        private void buttonRot_Click(object sender, EventArgs e)
        {
            Calculator.Operator(Calculator.ROT);
            Calculator.Operator(Calculator.NOP);
            Dummy.Focus();
        }
        private void buttonMulti2_Click(object sender, EventArgs e)
        {
            Calculator.Operator(Calculator.MUL2);
            Calculator.Operator(Calculator.NOP);
            Dummy.Focus();
        }
        private void buttonDiv1x_Click(object sender, EventArgs e)
        {
            Calculator.Operator(Calculator.DIV1X);
            Calculator.Operator(Calculator.NOP);
            Dummy.Focus();
        }
        
        //MEMORY



        //OTHERE

        //Show About me Menu
        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout FormAbout = new FormAbout();
            FormAbout.Show();
        }

        //Handel key input presst, skriva med tangentbordet.
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //C = clear
            //A == All Clear

            //13 Enter
            if (e.KeyValue == (int) Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Calculator.Operator(Calculator.NOP);
            }
            //8 Backspace
            else if (e.KeyValue == (int) Keys.Back)
            {
                Calculator.Clear(false);
            }
            else
            {
                Console.WriteLine(e.KeyValue);
            }
        }
               
        private void buttonMemoryClear_Click(object sender, EventArgs e)
        {
            textBoxMemmory.Clear();
        }

        private void buttonMADD_Click(object sender, EventArgs e)
        {
            Calculator.MemmoryAdd(textBoxMemmory.Text);
            Calculator.Operator(Calculator.NOP);
            Dummy.Focus();
        }
    }
}
