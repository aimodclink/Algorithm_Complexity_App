using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Algorithm_Complexity_App
{
    public partial class ResultForm : Form
    {
        private string resultString;
        public ResultForm()
        {
            InitializeComponent();
        }
        public ResultForm(MainForm f)
        {
            int number = 1;
            InitializeComponent();
            foreach (var x in f.resultX)
            {
                resultString += $"n{number++} = "  + x + Environment.NewLine;
            }
            label2.Text = resultString;
            label4.Text = f.middleComplexity.ToString();
            label6.Text = f.cycles.ToString();
        }
    }
}
