using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

namespace Algorithm_Complexity_App {
    public partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();
        }
        ResourceManager res_manager;    // declare Resource manager to access to specific cultureinfo
        CultureInfo culture;

        public Graph graph;
        string exit_text_string, exit_caption_string;

        private void MainForm_Load(object sender, EventArgs e)
        {
            rusToolStripMenuItem.Checked = true;    //default language is english
            englishToolStripMenuItem.Checked = false;

            res_manager = new ResourceManager("Algorithm_Complexity_App.MyResources.Res", typeof(MainForm).Assembly);
            //switch to eng
            switch_language();
            N = (int)numericUpDown1.Value;
            N2 = (int)numericUpDown2.Value;
            ShowAboutBox();
        }

        private void rusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rusToolStripMenuItem.Checked == true) //switch to english
            {
                rusToolStripMenuItem.Checked = false;
                ukrtoolStripMenuItem.Checked = false;
                englishToolStripMenuItem.Checked = true;
            }
            else
            {
                ukrtoolStripMenuItem.Checked = false;
                rusToolStripMenuItem.Checked = true;
                englishToolStripMenuItem.Checked = false;
            }

            //
            switch_language();
        }


        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rusToolStripMenuItem_Click(null, null);
        }

        //Function for switch language
        private void switch_language()
        {
            var govno = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            if (rusToolStripMenuItem.Checked == true)    //in ru
            {
                culture = CultureInfo.CreateSpecificCulture("ru");        //create culture for ru
            }
            else if (ukrtoolStripMenuItem.Checked == true)
            {
                culture = CultureInfo.CreateSpecificCulture("ua");
            }
            else
            {
                culture = CultureInfo.CreateSpecificCulture("en");        //create culture for en
            }

            exit_text_string = res_manager.GetString("exit_text_string", culture);
            exit_caption_string = res_manager.GetString("exit_caption_string", culture);

            //
            this.Text = res_manager.GetString("MainForm_text", culture);

            infoToolStripMenuItem.Text = res_manager.GetString("File_menu", culture);
            exitToolStripMenuItem.Text = res_manager.GetString("Exit_menu", culture);
            labelInputEdges.Text= res_manager.GetString("Input_edges", culture);
            labelInputVertex.Text = res_manager.GetString("Input_vertex", culture);

            languagesToolStripMenuItem.Text = res_manager.GetString("Language_menu", culture);
            englishToolStripMenuItem.Text = res_manager.GetString("English_menu", culture);
            CaculateMiddleComplexityBT.Text= res_manager.GetString("Caculate_middle_complexity", culture);
            FillEdgesLB.Text= res_manager.GetString("Fill_edges", culture);
            FillVertexLB.Text = res_manager.GetString("Fill_vertex", culture);
            aboutToolStripMenuItem.Text= res_manager.GetString("About", culture);
            exitToolStripMenuItem.Text= res_manager.GetString("Exit", culture);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(exit_text_string, exit_caption_string, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Dispose();
            }
        }
        private string DefaultText = String.Format("{0:f}", 0.0);
        private string DefaultTextInt = String.Format("{0:D}", 0);
        // создает текстарию и назначает ему кое какие свойства
        public TextBox InitTextBox(bool readOnly) {
            TextBox textBox = new TextBox();
            textBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox.Text = DefaultText;
            textBox.ReadOnly = readOnly;
            if (!readOnly) {
                textBox.CausesValidation = true;
                textBox.Validating += ValidateTextBox;
            }
            return textBox;
        }
        public TextBox InitTextBoxInt(bool readOnly)
        {
            TextBox textBox = new TextBox();
            textBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox.Text = DefaultTextInt;
            textBox.ReadOnly = readOnly;
            if (!readOnly)
            {
                textBox.CausesValidation = true;
                textBox.Validating += ValidateTextBox;
            }
            return textBox;
        }

        // проверка валидности текста в текстарии
        private void ValidateTextBox(object sender, CancelEventArgs e) {
            TextBox textBox = (TextBox)sender;
            double result;
            e.Cancel = !double.TryParse(textBox.Text, out result);
        }

        // создаёт двумерный массив текстарий, вставляя каждую в таблицу расположения
        private TextBox[,] InitTextBoxMatrix(TableLayoutPanel layoutPanel, int count, bool readOnly) {
            layoutPanel.SuspendLayout();

            layoutPanel.Controls.Clear();

            layoutPanel.ColumnStyles.Clear();
            layoutPanel.ColumnCount = count;

            layoutPanel.RowStyles.Clear();
            layoutPanel.RowCount = count;

            TextBox[,] result = new TextBox[count, count];
            float cellSize = 1f / count * 100f;
            for (int col = 0; col < 3; ++col) {
                layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, cellSize));
                for (int row = 0; row < count; ++row) {
                    layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, cellSize));
                    if (col < 2){
                        TextBox textBox = InitTextBoxInt(readOnly);
                        layoutPanel.Controls.Add(textBox, col, row);
                        result[col, row] = textBox;
                    }
                    else
                    {
                        TextBox textBox = InitTextBox(readOnly);
                        layoutPanel.Controls.Add(textBox, col, row);
                        result[col, row] = textBox;
                    }
                }
            }

            layoutPanel.ResumeLayout(true);

            return result;
        }

        // создаёт одномерный массив текстарий, вставляя каждую таблицу расположения
        public TextBox[] InitTextBoxArray(TableLayoutPanel layoutPanel, int count, bool readOnly) {
            layoutPanel.SuspendLayout();

            layoutPanel.Controls.Clear();

            layoutPanel.ColumnStyles.Clear();
            layoutPanel.ColumnCount = 1;

            layoutPanel.RowStyles.Clear();
            layoutPanel.RowCount = count;

            TextBox[] result = new TextBox[count];
            float cellSize = 1f / count * 100f;

            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

            for (int row = 0; row < count; ++row) {
                layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, cellSize));

                TextBox textBox = InitTextBoxInt(readOnly);

                layoutPanel.Controls.Add(textBox, 0, row);
                result[row] = textBox;
            }

            layoutPanel.ResumeLayout(true);

            return result;
        }


        private int n;
        private int n2;


        public double[]resultX;
        public double complexity = 0;
        public double middleComplexity;
        public List<int[]> cycles;
        private double transitionProbabilityFromZToOne;
        private double transitionProbabilityFromLastToK;
        private TextBox[,] matrixA;
        private TextBox[] vectorB;
        private TextBox[] vectorX;
        private TextBox[] vectorU;

        private void InitMatrixA() {
            matrixA = InitTextBoxMatrix(layoutMatrixA, n, false);
        }

        private void InitVectorX() {
            vectorX = InitTextBoxArray(layoutVectorX, n2, false);
        }

        private void InitVectorB() {
            vectorB = InitTextBoxArray(layoutVectorB, n, false);
        }

        private void InitVectorU() {
            vectorU = InitTextBoxArray(layoutVectorU, n, true);
        }

        public int N {
            get { return n; }
            set {
                if (value != n && value > 0) {
                    n = value;
                    InitMatrixA();
                }
            }
        }
        public int N2
        {
            get { return n2; }
            set
            {
                if (value != n2 && value > 0)
                {
                    n2 = value;
                    InitVectorX();
                }
            }
        }

        public double calculateComplexity(double[] resultMass, double[] verticesСompexity)
        {
            for (int i = 0; i <= resultMass.Length-1; i++)
            {
                double complexityTemp = resultMass[i] * verticesСompexity[i];
                complexity += complexityTemp;
            }

            return complexity;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            N = (int)numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (Validate()) {
                try {
                    LinearSystem system = new LinearSystem(MatrixA, VectorB);
                    resultX = system.XVector;
                    middleComplexity = calculateComplexity(resultX, VectorX);
                    cycles = graph.detectedCycles;
                    ResultForm newForm = new ResultForm(this);

                    newForm.Show();
                    //VectorU = system.UVector;
                } catch (Exception error) {
                    MessageBox.Show(error.Message);
                }
            }
        }

        public double[,] MatrixA {
            get {
                // собираем введённую пользователем матрицу A
                double[,] matrix_a = new double[n2, n2];
                int[][] edges = new int[n][];
                int iindex;
                int jindex;
                double value;
                // заполняем матрицу нулями и главную диагональ значениями -1
                for (int i = 0; i < n2; ++i)
                    for (int j = 0; j < n2; ++j)
                        if ((i == j))
                        {
                            if (matrix_a[i, j] == 0)
                            {
                                matrix_a[i, j] = -1;
                            }
                        }
                        else
                        {
                            matrix_a[i, j] = 0;
                        }
                        
                for (int i = 0; i < n; ++i) {
                    iindex = int.Parse(matrixA[0, i].Text);
                    jindex = int.Parse(matrixA[1, i].Text);
                    value = double.Parse(matrixA[2, i].Text);
                    int[] temp = new int[2] { iindex, jindex };
                    edges[i] = temp;
                    if (iindex > 0)
                    {
                        if (jindex <= n2)
                        {

                            matrix_a[jindex - 1, iindex - 1] = value;

                        }
                        else
                        {
                            transitionProbabilityFromLastToK = value;
                        }
                    }
                    else
                    {
                        transitionProbabilityFromZToOne = value;
                    }
                }
                graph = new Graph(edges, n, n2); 
                return matrix_a;
            }
        //set {
        // записываем в текстбоксы матрицу A
        //for (int i = 0; i < n; ++i)
        //    for (int j = 0; j < n; ++j)
        //        matrixA[j, i].Text = value[i, j].ToString("f");
        //}
    }

        public double[] VectorB {
            get {

                double[] vector_b = new double[n2];
                vector_b[0] = -1;
                for (int j = 1; j < n2; ++j)
                    vector_b[j] = 0;
                return vector_b;
            }
            set
            {
                // записываем в текстбоксы вектор B
                for (int j = 0; j < n; ++j)
                    vectorB[j].Text = value[j].ToString("f");
            }
        }

        public double[] VectorX {
            get
            {
                // собираем введённый пользователем вектор X
                double[] vector_x = new double[n2];
                for (int j = 0; j < n2; ++j)
                    vector_x[j] = double.Parse(vectorX[j].Text);
                return vector_x;
            }
            set {
                // показываем вычисленный результат X
                for (int j = 0; j < n2; ++j)
                    vectorX[j].Text = value[j].ToString("f");
            }
        }

        public double[] VectorU {
            set {
                // показываем вычисленную невязку U
                for (int j = 0; j < n; ++j)
                    vectorU[j].Text = value[j].ToString("e");
            }
        }

        private void ShowAboutBox() {
            new AboutBox().ShowDialog(this);
        }

        private void оПрогаммеToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowAboutBox();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            N2 = (int)numericUpDown2.Value;
        }

        private void NumericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            N = (int)numericUpDown1.Value;
        }

        private void NumericUpDown2_KeyPress(object sender, KeyPressEventArgs e)
        {
            N2 = (int)numericUpDown2.Value;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void UkrtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ukrtoolStripMenuItem.Checked == true)    //in french, switch to default language
            {
                ukrtoolStripMenuItem.Checked = false;
                rusToolStripMenuItem.Checked = false;
                englishToolStripMenuItem.Checked = true;        //default language
            }
            else            //current language is not french, switch french
            {
                ukrtoolStripMenuItem.Checked = true;
                rusToolStripMenuItem.Checked = false;
                englishToolStripMenuItem.Checked = false;
            }
            //switch language
            switch_language();
        }

    }
}