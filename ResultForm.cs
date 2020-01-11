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
        private string minComplexity;
        private string maxComplexity;
        private string resultString;
        private TextBox[] cycleTextBoxes;
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
            if (f.cycles.Count() > 0)
            {
                label5.Visible = true;
                foreach (var cycle in f.cycles){

                    Label cycleLB = new Label();
                    Label mediumCountOfCycleRepeatLB = new Label();
                    Label minCountOfCycleRepeatLB = new Label();
                    Label maxCountOfCycleRepeatLB = new Label();
                    TextBox textBoxMin = f.InitTextBox(false);
                    TextBox textBoxMax = f.InitTextBox(false);
                    cycleLB.AutoSize = true;
                    mediumCountOfCycleRepeatLB.AutoSize = true;
                    minCountOfCycleRepeatLB.AutoSize = true;
                    maxCountOfCycleRepeatLB.AutoSize = true;
                    cycleLB.Text = $"Цикл: {cycle[0]}-{cycle[1]}";
                    double mediumCountOfCycleRepeat = CalculateMediumCountOfCycleRepeat(f, cycle[1]-1, cycle[0]-1);
                    mediumCountOfCycleRepeatLB.Text = $"Среднее число повторений: {mediumCountOfCycleRepeat}";
                    minCountOfCycleRepeatLB.Text = "Введите минимальное число повторений:";
                    maxCountOfCycleRepeatLB.Text = "Введите максимальное число повторений:";
                    //label6.Text = f.cycles.ToString();
                    cycleTableLayoutPanel.Controls.Add(cycleLB);
                    cycleTableLayoutPanel.Controls.Add(mediumCountOfCycleRepeatLB);
                    cycleTableLayoutPanel.Controls.Add(minCountOfCycleRepeatLB);
                    cycleTableLayoutPanel.Controls.Add(textBoxMin);
                    cycleTableLayoutPanel.Controls.Add(maxCountOfCycleRepeatLB);
                    cycleTableLayoutPanel.Controls.Add(textBoxMax);
                    //InitCyclesTextBoxes(f, 1);
                }
                Button CalculateMinAndMaxComplexity = new Button();
                CalculateMinAndMaxComplexity.Text = "Посчитать минимальную и максимальную трудоемкости";
                CalculateMinAndMaxComplexity.Click += new EventHandler(this.MyButtonHandler);
                cycleTableLayoutPanel.Controls.Add(CalculateMinAndMaxComplexity);

            }
            else
            {
                label6.Text = "Циклы не найдены";
            }

        }
        public void InitCyclesTextBoxes(MainForm f, int n)
        {
            cycleTextBoxes = f.InitTextBoxArray(cycleTableLayoutPanel, n, false);
        }
        public double CalculateMediumCountOfCycleRepeat(MainForm f, int i, int j)
        {
            return 1 / (1-f.MatrixA[i, j]);
        }
        void MyButtonHandler(object sender, EventArgs e)
        {
            Label minComplexityLB = new Label();
            Label maxComplexityLB = new Label();
            minComplexityLB.Text = "Минимальная трудоемкость:";
            minComplexityLB.Text = "максимальная трудоемкость:";
            minMaxComplexityTableLayout.Controls.Add(minComplexityLB);
            minMaxComplexityTableLayout.Controls.Add(maxComplexityLB);
        }

        void CalculateMinComplexity(MainForm f)
        {
            
            List<List<int[]>> fullCycles = findFullCyclesList(f);
            
            //foreach (var fullcycle in fullCycles)
            //{
            //    minComplexityForCycle
            //    double firstElement = f.VectorX[fullcycle.First().First()];
            //    foreach(var edge in fullcycle)
            //    int A= firstElement
            //}
        }

        List<List<int[]>> findFullCyclesList(MainForm f)
        {
            List<List<int[]>> fullCycles = new List<List<int[]>>();
            foreach (var cycle in f.cycles)
            {
                List<int[]> fullCycle = new List<int[]>();
                for (int i = 0; i < f.graph.NE; i++)
                {
                    var firstEdgeElement = f.graph.graph[i][0];
                    var secondEdgeElement = f.graph.graph[i][1];
                    if (firstEdgeElement == cycle[0])
                    {

                        for (int j = firstEdgeElement; j <= secondEdgeElement; j++)
                        {
                            int[] temp = new int[2] { f.graph.graph[j][0], f.graph.graph[j][1] };
                            fullCycle.Add(temp);
                        }
                    }
                }
                fullCycles.Add(fullCycle);
            }
            return fullCycles;
        }
    }
}
