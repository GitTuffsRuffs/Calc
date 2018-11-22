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
        }

        //Metoder den delar för att vara en Calcform, och kunna prata med Calculatorn
        public void setResult(string newText)
        {
            textBoxResult.Text = newText;
        }
        public void addHistory(string newHist)
        {
            textBoxHist.Text = newHist + "\r\n" + textBoxHist.Text;
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
            textBoxHist.Clear();
            pictureBoxLable.Visible = false;
            pictureBox2.Visible = false;
            Dummy.Focus();
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            Calculator.Clear(false);
            Dummy.Focus();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Calculator.RemoveString();
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
        private void buttonMemoryClear_Click(object sender, EventArgs e)
        {
            Calculator.MemmoryClear();
            Dummy.Focus();
        }
        private void buttonMemoryRead_Click(object sender, EventArgs e)
        {
            Calculator.MemmoryGet();
            Dummy.Focus();
        }
        private void buttonMADD_Click(object sender, EventArgs e)
        {
            Calculator.MemmoryAdd();
            Dummy.Focus();
        }
        private void buttonMemmoryRemove_Click(object sender, EventArgs e)
        {
            Calculator.MemmorySub();
            Dummy.Focus();
        }
        private void buttonMemorySave_Click(object sender, EventArgs e)
        {
            Calculator.MemmorySet();
            Dummy.Focus();
        }

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBoxLable.Visible = true;
            pictureBox2.Visible = true;

            Random rand = new Random();
            int irand = rand.Next(1, 11);

            switch (irand)
            {
                case 1:
                    pictureBoxLable.Text = "Jhon has 32 candy bars,he eats 28.\nWhat dose he have now? Diabetes.";
                    break;

                case 2:
                    pictureBoxLable.Text = "Mistakes are proof that you\nare trying. You can do it!";
                    break;

                case 3:
                    pictureBoxLable.Text = "Education ain't the learning of facts,\nbut the training of the mind to think.";
                    break;

                case 4:
                    pictureBoxLable.Text = "Mathematics is like love, a simple\nidea, but it can get complicated.";
                    break;

                case 5:
                    pictureBoxLable.Text = "Parallel lines have got so much in\ncommon, shame they'll never meet. ";
                    break;

                case 6:
                    pictureBoxLable.Text = "Even the hardest puzzles have a\nsoulution.";
                    break;

                case 7:
                    pictureBoxLable.Text = "In the middle of difficulty\nlise opportunity.";
                    break;

                case 8:
                    pictureBoxLable.Text = "Are you cold? Sit in the corners,\nit's always 90 ⊾ degrees!";
                    break;

                case 9:
                    pictureBoxLable.Text = "i: Be rational 冂!\n冂: Get reall i! ";
                    break;

                case 10:
                    pictureBoxLable.Text = "You have to be ODD\nto be number ONE.";
                    break;

                default:
                    pictureBoxLable.Text = "Hello, do you like math?";
                    break;
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
