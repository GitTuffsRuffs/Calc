using System;
using System.Windows.Forms;

namespace Calc
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void Exit(object sender, EventArgs e)
        {
            //Button
            this.Close();
        }
    }
}
