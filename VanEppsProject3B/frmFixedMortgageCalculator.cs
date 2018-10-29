using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanEppsProject3B
{
    public partial class frmFixedMortgageCalculator : Form
    {
        public frmFixedMortgageCalculator()
        {
            InitializeComponent();
        }

        frmRateCalculator formRateCalculator;

        private void btnCalculateMortgage_Click(object sender, EventArgs e)
        {
            // Convert input
            double principalAmount = Double.Parse(txtPrincipalAmount.Text, System.Globalization.NumberStyles.Currency);
            int termLength = Int32.Parse(txtTermLength.Text, System.Globalization.NumberStyles.Number);
            double annualRate = Double.Parse(txtAnnualRate.Text, System.Globalization.NumberStyles.Number);

            // Update input fields with parsed values
            txtPrincipalAmount.Text = principalAmount.ToString();
            txtTermLength.Text = termLength.ToString();
            txtAnnualRate.Text = annualRate.ToString();

            // Convert interest rate and term length to monthly amounts
            double monthlyRate = annualRate / 12 / 100; // Divide annualRate by 12 (months in year) then divide by 100 to get decimal rate value
            int termLengthMonths = termLength * 12;

            // Calculate monthly payment
            double monthlyPayment = (monthlyRate * principalAmount) / (1 - Math.Pow(1 + monthlyRate, -termLengthMonths));
            // Calculate total amount owed
            double totalOwed = monthlyPayment * termLengthMonths;
            // Calculate interest paid
            double totalInterest = totalOwed - principalAmount;

            // Format and display calculated values
            txtMonthlyPayment.Text = monthlyPayment.ToString("c");
            txtTotalOwed.Text = totalOwed.ToString("c");
            txtTotalInterest.Text = totalInterest.ToString("c");
        }

        private void btnExitMortgage_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRate_Click(object sender, EventArgs e)
        {
            // Display Interest Rate Calculator form
            formRateCalculator = new frmRateCalculator(this);
            formRateCalculator.Show();
        }
    }
}
