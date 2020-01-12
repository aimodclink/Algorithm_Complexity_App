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
        private MainForm f;
        private string minComplexity;
        private string maxComplexity;
        private string resultString;
        private List<int[]> cycles;
        private double[] VectorX;
        private Graph graph;
        private List<TextBox> minComplexityTextBoxes = new List<TextBox>();
        private List<TextBox> maxComplexityTextBoxes = new List<TextBox>();
        public ResultForm()
        {
            InitializeComponent();
        }

        public ResultForm(MainForm f)
        {
            f = f;
            graph = f.graph;
            cycles = f.cycles;
            VectorX = f.VectorX;
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
                    double mediumCountOfCycleRepeat = CalculateMediumCountOfCycleRepeat(f, cycle[0] - 1, cycle[1] - 1);
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
            minComplexityLB.AutoSize = true;
            maxComplexityLB.AutoSize = true;
            var minComplexity = CalculateMinComplexity(f);
            //var maxComplexity = CalculateMaxComplexity(f);
            minComplexityLB.Text = $"Минимальная трудоемкость: {minComplexity}";
            //maxComplexityLB.Text = $"Максимальная трудоемкость: {maxComplexity}";
            minMaxComplexityTableLayout.Controls.Add(minComplexityLB);
            //minMaxComplexityTableLayout.Controls.Add(maxComplexityLB);
        }
        
        double CalculateMinComplexity(MainForm f)
        {

            List<List<int[]>> fullCycles = findFullCyclesList(f);
            double minComplexityForCycle = 0.00;
            List<int[]> allCycle = new List<int[]>();
            for (int e = 1; e < graph.NE-1; e++)
            {
                if (graph.graph[e][0] < graph.graph[e][1])
                {
                    int[] temp = new int[2] { graph.graph[e][0], graph.graph[e][1] };
                    allCycle.Add(temp);
                }
            }
            fullCycles.Add(allCycle);

                var complexityVector = VectorX;
                List<int[]> previousCycle = new List<int[]>();

                foreach (var fullcycle in fullCycles)
                {
                    if (previousCycle.Count != 0)
                    {
                        var LastElementOfPreviousCycle = previousCycle[previousCycle.Count-1][1];
                        foreach (var edge in previousCycle)
                        {
                            int firstindex1 = edge[0];
                            int secondIndex1 = edge[1];
                            List<int> listToRemove = new List<int> { firstindex1, secondIndex1 };
                            fullcycle.RemoveAll(innerList => innerList.SequenceEqual(listToRemove));
                        }
                        List<int> listToRemove1 = new List<int> { LastElementOfPreviousCycle, LastElementOfPreviousCycle+1};
                        fullcycle.RemoveAll(innerList => innerList.SequenceEqual(listToRemove1));
                        int firstindex = previousCycle[0][0];
                        int secondIndex = LastElementOfPreviousCycle+1;
                        fullcycle.Add(new int[] {firstindex, secondIndex});
                    }

                    int index = 0;


                    double[] newVector = new double[fullcycle.Count+1];
                    double firstElement = complexityVector[fullcycle[0][0]];
                    double A = firstElement;
                    var minComplexity = 0.00;
                    for (int i = 0; i < newVector.Length; i++)
                    {
                        List<double> temp = new List<double>();
                        temp.Add(minComplexity);

                        //for (int j = i+1; j < fullcycle.Count; j++)
                        //{
                        //    if (fullcycle[i][1] == fullcycle[j][1])
                        //    {
                        //        temp.Add(VectorX[fullcycle[i][0] - 1]);
                        //        temp.Add(VectorX[fullcycle[j][0] - 1]);
                        //    }
                        //}

                        if (temp.Count > 2)
                        {
                            minComplexity = temp.Min();
                        }
                        minComplexity = temp.Min();
                        newVector[i] = minComplexity + complexityVector[i];
                        minComplexity = newVector[i];
                    }

                    minComplexityForCycle = newVector.Last() * double.Parse(minComplexityTextBoxes[index].Text);
                    complexityVector[fullcycle[0][0]] = minComplexityForCycle;
                    index++;
                    previousCycle = fullcycle;

                }

                return minComplexityForCycle;
        }
        double CalculateMaxComplexity(MainForm f)
        {

            List<List<int[]>> fullCycles = findFullCyclesList(f);
            double maxComplexityForCycle = 0.00;
            List<int[]> allCycle = new List<int[]>();
            for (int e = 1; e < graph.NE - 1; e++)
            {
                if (graph.graph[e][0] < graph.graph[e][1])
                {
                    int[] temp = new int[2] { graph.graph[e][0], graph.graph[e][1] };
                    allCycle.Add(temp);
                }
            }
            fullCycles.Add(allCycle);

            var complexityVector = VectorX;
            List<int[]> previousCycle = new List<int[]>();

            foreach (var fullcycle in fullCycles)
            {
                if (previousCycle.Count != 0)
                {
                    var indexOfLastElementOfPreviousCycle = fullcycle.IndexOf(previousCycle[previousCycle.Count - 1]);
                    foreach (var edge in previousCycle)
                    {
                        int firstindex1 = edge[0];
                        int secondIndex1 = edge[1];
                        List<int> listToRemove = new List<int> { firstindex1, secondIndex1 };
                        fullcycle.RemoveAll(innerList => innerList.SequenceEqual(listToRemove));
                    }

                    int firstindex = previousCycle[0][0];
                    int secondIndex = fullcycle[indexOfLastElementOfPreviousCycle + 1][0];
                    fullcycle.Add(new int[] { firstindex, secondIndex });
                }

                int index = 0;


                double[] newVector = new double[fullcycle.Count];
                double firstElement = complexityVector[fullcycle[0][0]];
                double A = firstElement;
                var maxComplexity = 0.00;
                for (int i = 0; i < newVector.Length; i++)
                {
                    List<double> temp = new List<double>();
                    temp.Add(maxComplexity);
                    for (int j = i + 1; j < fullcycle.Count; j++)
                    {
                        if (fullcycle[i][1] == fullcycle[j][1])
                        {
                            temp.Add(VectorX[fullcycle[i][0] - 1]);
                            temp.Add(VectorX[fullcycle[j][0] - 1]);
                        }
                    }

                    if (temp.Count > 2)
                    {
                        maxComplexity = temp.Max();
                    }
                    maxComplexity = temp.Max();
                    newVector[i] = maxComplexity + complexityVector[i];
                    maxComplexity = newVector[i];
                }

                maxComplexityForCycle = newVector.Last() * double.Parse(maxComplexityTextBoxes[index].Text);
                complexityVector[fullcycle[0][0]] = maxComplexityForCycle;
                index++;
                previousCycle = fullcycle;

            }

            return maxComplexityForCycle;
        }

        List<List<int[]>> findFullCyclesList(MainForm f)
        {
            List<List<int[]>> fullCycles = new List<List<int[]>>();
            foreach (var cycle in cycles)
            {
                List<int[]> fullCycle = new List<int[]>();
                for (int i = 0; i < graph.NE; i++)
                {
                    var firstEdgeElement = graph.graph[i][0];
                    //var secondEdgeElement = graph.graph[i][1];
                    if (firstEdgeElement == cycle[0])
                    {

                        for (int j = cycle[0]; j <= cycle[1]; j++)
                        {
                            if (graph.graph[j][0] < graph.graph[j][1])
                            {
                                int[] temp = new int[2] { graph.graph[j][0], graph.graph[j][1] };
                                fullCycle.Add(temp);
                            }
                        }
                    }
                }
                fullCycles.Add(fullCycle);
            }
            return fullCycles;
        }
    }
}
