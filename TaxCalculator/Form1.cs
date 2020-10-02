using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Decimal CalculateTax(Decimal taxin)
        {
            // figure out the bracket
            // NOTE the graph provided was incorrect; bracket 2 was adjusted accordingly
            Decimal flat, perc, excess;
            switch (taxin)
            {
                case var x when (x <= 9240m):
                    flat = 0m;
                    perc = 0.10m;
                    excess = x - 0m;

                    break;

                case var x when (x > 9240m && x <= 37450m):
                    flat = 924m;
                    perc = 0.15m;
                    excess = x - 9240m;

                    break;

                case var x when (x > 37450m && x <= 90750m):
                    flat = 5156.25m;
                    perc = 0.25m;
                    excess = x - 37450m;

                    break;

                case var x when (x > 90750m && x <= 189300m):
                    flat = 18481.25m;
                    perc = 0.28m;
                    excess = x - 90750m;

                    break;

                case var x when (x > 189300m && x <= 411500m):
                    flat = 46075.25m;
                    perc = 0.33m;
                    excess = x - 189300m;

                    break;

                case var x when (x > 411500m && x <= 413200m):
                    flat = 119401.25m;
                    perc = 0.35m;
                    excess = x - 411500m;

                    break;

                case var x when (x > 413200m):
                    flat = 119996.25m;
                    perc = 0.396m;
                    excess = x - 413200m;

                    break;

                default:
                    throw new Exception("Invalid input");
            }

            return flat + (perc * excess);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // get input and send to function and send to output tb
            try
            {
                tbTOwed.Text = Convert.ToString(CalculateTax(Convert.ToDecimal(tbTIncome.Text)));
            }
            catch (Exception)
            {
                tbTOwed.Text = "Invalid Entry";
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbTIncome_TextChanged(object sender, EventArgs e)
        {
            tbTOwed.Text = "";
        }
    }
}
