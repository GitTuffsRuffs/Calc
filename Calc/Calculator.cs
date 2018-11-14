using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Calculator
    {
        public const int ADD = 1;
        public const int SUB = 2;
        public const int MUL = 3;
        public const int DIV = 4;
        public const int NOP = 0;

        int call;
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
        public void Clear(bool ClearAll)
        {
            Form.activateComma();
            newNr = "";
            
            if (ClearAll)
            {
                sum = 0;
                call = NOP;
                Form.setResult("");
            }else
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

        private void Summarize()
        {
            Form.activateComma();

            if (call == NOP) // null
            {
                if (newNr.Length > 0)
                {
                    sum = Convert.ToDouble(newNr);
                }
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
            {// /
                try
                {
                    sum = sum / Convert.ToDouble(newNr);
                    newNr = "";
                    Dislpaly();
                }
                catch { }
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
                default:
                    if (newNr.Length > 0)
                    {
                        Form.setResult(newNr);
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
