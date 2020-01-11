using System;
using System.CodeDom.Compiler;
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
        private List<TextBox> minComplexityTextBoxes = new List<TextBox>();
        private List<TextBox> maxComplexityTextBoxes = new List<TextBox>();

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
                resultString += $"n{number++} = " + x + Environment.NewLine;
            }

            label2.Text = resultString;
            label4.Text = f.middleComplexity.ToString();
            if (f.cycles.Count() > 0)
            {
                label5.Visible = true;
                foreach (var cycle in f.cycles)
                {

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
                    double mediumCountOfCycleRepeat = CalculateMediumCountOfCycleRepeat(f, cycle[1] - 1, cycle[0] - 1);
                    mediumCountOfCycleRepeatLB.Text = $"Среднее число повторений: {mediumCountOfCycleRepeat}";
                    minCountOfCycleRepeatLB.Text = "Введите минимальное число повторений:";
                    maxCountOfCycleRepeatLB.Text = "Введите максимальное число повторений:";
                    //label6.Text = f.cycles.ToString();
                    cycleTableLayoutPanel.Controls.Add(cycleLB);
                    cycleTableLayoutPanel.Controls.Add(mediumCountOfCycleRepeatLB);
                    cycleTableLayoutPanel.Controls.Add(minCountOfCycleRepeatLB);
                    cycleTableLayoutPanel.Controls.Add(textBoxMin);
                    minComplexityTextBoxes.Add(textBoxMin);
                    cycleTableLayoutPanel.Controls.Add(maxCountOfCycleRepeatLB);
                    cycleTableLayoutPanel.Controls.Add(textBoxMax);
                    minComplexityTextBoxes.Add(textBoxMax);
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

        //public void InitCyclesTextBoxes(MainForm f, int n)
        //{
        //    cycleTextBoxes = f.InitTextBoxArray(cycleTableLayoutPanel, n, false);
        //}
        public double CalculateMediumCountOfCycleRepeat(MainForm f, int i, int j)
        {
            return 1 / (1 - f.MatrixA[i, j]);
        }

        void MyButtonHandler(object sender, EventArgs e)
        {
            Label minComplexityLB = new Label();
            Label maxComplexityLB = new Label();

            //minComplexityLB
            minComplexityLB.Text = "Минимальная трудоемкость:";
            minComplexityLB.Text = "Максимальная трудоемкость:";
            minMaxComplexityTableLayout.Controls.Add(minComplexityLB);
            minMaxComplexityTableLayout.Controls.Add(maxComplexityLB);
        }
        
        void CalculateMinComplexity(MainForm f)
        {

            List<List<int[]>> fullCycles = findFullCyclesList(f);
            List<List<int[]>> allCycles = new List<List<int[]>>();

            List<int[]> fullCycle = new List<int[]>();
            for (int e = 0; e < f.graph.NE; e++)
            {
                int[] temp = new int[2] {f.graph.graph[e][0], f.graph.graph[e][1]};
                fullCycle.Add(temp);
            }
            allCycles.Add(fullCycle);
    

                var complexityVector = f.VectorX;
                List<int[]> previousCycle = new List<int[]>();

                foreach (var fullcycle in fullCycles)
                {
                    if (previousCycle != null)
                    {
                        var indexOfLastElementOfPreviousCycle = fullcycle.IndexOf(previousCycle.Last());
                        foreach (var edge in previousCycle)
                        {
                            fullcycle.Remove(edge);
                        }

                        int firstindex = previousCycle[0][0];
                        int secondIndex = fullcycle[indexOfLastElementOfPreviousCycle + 1][0];
                        fullcycle.Add(new int[] {firstindex, secondIndex});
                    }

                    int index = 0;
                    double minComplexityForCycle = 0.00;

                    double[] newVector = new double[fullCycles.Count];
                    double firstElement = complexityVector[fullcycle[0][0]];
                    double A = firstElement;

                    for (int i = 0; i < newVector.Length; i++)
                    {
                        var minComplexity = 0.00;
                        List<double> temp = new List<double>();
                        for (int j = i; j < fullcycle.Count; j++)
                        {
                            if (fullcycle[i][1] == fullcycle[j][1])
                            {
                                temp.Add(f.VectorX[fullcycle[i][0] - 1]);
                            }
                        }

                        minComplexity = temp.Min();
                        newVector[i] = minComplexity + complexityVector[i];
                    }

                    minComplexityForCycle = newVector.Last() * double.Parse(minComplexityTextBoxes[index].Text);
                    complexityVector[fullcycle[0][0]] = minComplexityForCycle;
                    index++;
                    previousCycle = fullcycle;

                }
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
