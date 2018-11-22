using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Calculator
    {
        public const int NOP = 0;
        public const int ADD = 1;
        public const int SUB = 2;
        public const int MUL = 3;
        public const int DIV = 4;
        public const int CPO = 5;
        public const int ROT = 6;
        public const int MUL2 = 7;
        public const int DIV1X = 8;

        int call;
        double memmory = 0;
        double sum;
        string newNr;

        //Referens
        CalcForm Form;

        //Konstruktor
        public Calculator(CalcForm newForm){
            this.Form = newForm;
        }

        public void AddtoString(string nr)
        {
            newNr += nr;
            Dislpaly();
        }
        public void RemoveString()
        {
            if (call != NOP && newNr.Length == 0)
            {
                // 11 + => 11
                call = NOP;
                Dislpaly();
                return;
            }            
            
            if (newNr.Length == 0)
            {
                // 11 => ""
                newNr = sum + "";
                sum = 0;
            }

            string lastchar = newNr.Substring(newNr.Length - 1);
            if (lastchar == ",")
            {
                Form.activateComma();
            }

            newNr = newNr.Remove(newNr.Length - 1);

            if (newNr.Length == 0)
            {
                Form.setResult("");
            }else
            {
                Dislpaly();
            }
        }
        public void Clear(bool ClearAll)
        {
            if (ClearAll)
            {
                Form.activateComma();
                newNr = "";
                call = NOP;
                sum = 0;
                Form.setResult("");
                //Form.textBoxHist("");
            }
            else if (newNr.Length > 0)
            {
                // 11 + 11 => 11 +
                Form.activateComma();
                newNr = "";
                Dislpaly();
            }
            else if (call != NOP)
            {
                // 11 + => 11
                call = NOP;
                Dislpaly();
            }
            else
            {
                // 11 => ""
                sum = 0;
                Form.setResult("");
            }
        }
        public void Operator(int newCall)
        {
            Summarize();
            call = newCall;
            newNr = "";
            Dislpaly();
        }

        public void MemmoryAdd()
        {
            Summarize();
            memmory += sum;
            Form.setMemory(memmory + "");
        }
        public void MemmorySub()
        {
            Summarize();
            memmory -= sum;
            Form.setMemory(memmory + "");
        }
        public void MemmorySet()
        {
            Operator(NOP);
            memmory = sum;
            Form.setMemory(memmory + "");
        }
        public void MemmoryGet()
        {
            newNr = memmory + "";
            Dislpaly();
        }
        public void MemmoryClear()
        {
            memmory = 0;
            Form.setMemory("");
        }

        private void Summarize()
        {
            Form.activateComma();
            string history;

            if (call == NOP) // null
            {
                try
                {
                    if (newNr.Length > 0)
                    {
                        sum = Convert.ToDouble(newNr);
                    }
                }
                catch { }
                return;
            }
            else if (call == ADD) // +
            {
                try
                {
                    history = sum + "+" + newNr;
                    sum = sum + Convert.ToDouble(newNr);
                    newNr = "";
                    Form.addHistory(history + "=" + sum);
                    Dislpaly();
                }
                catch
                { }
            }
            else if (call == SUB) // -
            {
                try
                {
                    history = sum + "-" + newNr;
                    sum = sum - Convert.ToDouble(newNr);
                    newNr = "";
                    Form.addHistory(history + "=" + sum);
                    Dislpaly();
                }
                catch { }
            }
            else if (call == MUL)
            {// *
                try
                {
                    history = sum + "*" + newNr;
                    sum = sum * Convert.ToDouble(newNr);
                    newNr = "";
                    Form.addHistory(history + "=" + sum);
                    Dislpaly();
                }
                catch { }
            }
            else if (call == DIV)
            {// /     //FIX DIV WITH 0 (somday).
                try
                {
                    history = sum + "/" + newNr;
                    sum = sum / Convert.ToDouble(newNr);
                    sum = Math.Round(sum, 2);
                    newNr = "";
                    Form.addHistory(history + "=" + sum);
                    Dislpaly();
                }
                catch { }
            }
            else if (call == CPO)
            {
                try
                {
                    sum = sum * -1;
                    newNr = "";
                    Dislpaly();
                }
                catch { }
            }
            else if (call == ROT)
            {
                try
                {
                    history = "√" + sum ;
                    sum = Math.Sqrt(sum);
                    newNr = "";
                    Form.addHistory(history + "=" + sum);
                    Dislpaly();
                }
                catch { }
            }
            else if (call == MUL2)
            {
                try
                {
                    history = sum + "²";
                    sum = sum * sum;
                    newNr = "";
                    Form.addHistory(history + "=" + sum);
                    Dislpaly();
                }
                catch { }
            }
            else if (call == DIV1X)
            {
                try
                {
                    history = "1/" + sum;
                    sum = 1 / sum;
                    newNr = "";
                    Form.addHistory(history + "=" + sum);
                    Dislpaly();
                }
                catch
                { }
            }
        }
        private void Dislpaly()
        {
            switch (call)
            {
                case ADD:
                    Form.setResult(sum + "+" + newNr);
                    break;

                case SUB:
                    Form.setResult(sum + "-" + newNr);
                    break;

                case MUL:
                    Form.setResult(sum + "*" + newNr);
                    break;

                case DIV:
                        Form.setResult(sum + "/" + newNr);
                    break;

                case CPO:
                    if (sum >= 0)
                    {
                        Form.setResult("" + sum);
                    }
                    else if (sum < 0)
                    {
                        Form.setResult("-" + sum);
                    }
                    break;

                case ROT:
                    Form.setResult("√" + sum);
                    break;

                case MUL2:
                    Form.setResult("" + sum);
                    break;

                case DIV1X:
                    Form.setResult("" + sum);
                    break;


                default:
                    if (newNr.Length > 0)
                    {
                        Form.setResult(newNr);
                        //Form.setHistory(newNr);
                    }
                    else
                    {
                        Form.setResult(sum + "");
                    }
                    break;
            }
        }
        

    }
}
