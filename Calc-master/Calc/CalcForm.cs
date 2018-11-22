namespace Calc
{
    //Uppfyller Classen kraven kan den få vara en CalcForm, och får då prata med Calculatorn
    interface CalcForm
    {
        void activateComma();
        void setResult(string newText);
        void setMemory(string newMemmoiry);
        //void setHistory(string newHist);
    }
}
