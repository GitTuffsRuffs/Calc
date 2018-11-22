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
        public const int PRO = 8;
        public const int DIV1X = 9;

        int call;
        double memmory;
        double sum;
        string newNr;

        //Referens
        CalcForm Form;
        private object textBoxResult;

        //Konstruktor
        public Calculator(CalcForm newForm){
            this.Form = newForm;
        }

        public void AddtoString(string nr)
        {
            newNr += nr;
            Dislpaly();
        }
        public void RemoveString(string text)
        {
            newNr = text.Remove(text.Length - 1);
            Dislpaly();
        }
        public void Clear(bool ClearAll)
        {
            Form.activateComma();
            newNr = "";
            
            if (ClearAll)
            {
                sum = 0;
                call = NOP;
                Form.setResult("");
                //Form.textBoxHist("");
            }
            else
            {
                Dislpaly();
            }
        }
        public void Operator(int newCall)
        {
            Summarize();
            call = newCall;
            newNr = "";
            Dislpaly();
        }


        public void MemmoryAdd(string add)
        {
            try
            {
                memmory = memmory + Convert.ToDouble(add);
                add = "";
                DislpalyMem();
            }
            catch { }
        }

        private void Summarize()
        {
            Form.activateComma();

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
                    sum = sum + Convert.ToDouble(newNr);
                    newNr = "";
                    Dislpaly();
                }
                catch
                { }
            }
            else if (call == SUB) // -
            {
                try
                {
                    sum = sum - Convert.ToDouble(newNr);
                    newNr = "";
                    Dislpaly();
                }
                catch { }
            }
            else if (call == MUL)
            {// *
                try
                {
                    sum = sum * Convert.ToDouble(newNr);
                    newNr = "";
                    Dislpaly();
                }
                catch { }
            }
            else if (call == DIV)
            {// /     //FIX DIV WITH 0 (somday).
                try
                {
                    sum = sum / Convert.ToDouble(newNr);
                    sum = Math.Round(sum, 2);
                    newNr = "";
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
                    sum = Math.Sqrt(sum);
                    newNr = "";
                    Dislpaly();
                }
                catch { }
            }
            else if (call == MUL2)
            {
                try
                {
                    sum = sum * sum;
                    newNr = "";
                    Dislpaly();
                }
                catch { }
            }
            else if (call == PRO) //DOSE NOT WORK
            {
                try
                {
                    sum = (sum * sum) / 100;
                    newNr = "";
                    Dislpaly();
                }
                catch
                { }
            }
            else if (call == DIV1X)
            {
                try
                {
                    sum = 1 / sum;
                    newNr = "";
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

        private void DislpalyMem()
        {
            Form.setMemory(memmory + "");
        }


    }
}
