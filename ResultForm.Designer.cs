namespace Algorithm_Complexity_App
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cycleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.minMaxComplexityTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Корни системы уравнений:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Средняя трудоемкость:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(644, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Обнаружены циклы:";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(609, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 5;
            // 
            // cycleTableLayoutPanel
            // 
            this.cycleTableLayoutPanel.ColumnCount = 1;
            this.cycleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cycleTableLayoutPanel.Location = new System.Drawing.Point(151, 188);
            this.cycleTableLayoutPanel.Name = "cycleTableLayoutPanel";
            this.cycleTableLayoutPanel.RowCount = 2;
            this.cycleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.cycleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.cycleTableLayoutPanel.Size = new System.Drawing.Size(332, 323);
            this.cycleTableLayoutPanel.TabIndex = 6;
            // 
            // minMaxComplexityTableLayout
            // 
            this.minMaxComplexityTableLayout.ColumnCount = 1;
            this.minMaxComplexityTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.minMaxComplexityTableLayout.Location = new System.Drawing.Point(503, 188);
            this.minMaxComplexityTableLayout.Name = "minMaxComplexityTableLayout";
            this.minMaxComplexityTableLayout.RowCount = 2;
            this.minMaxComplexityTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.minMaxComplexityTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.minMaxComplexityTableLayout.Size = new System.Drawing.Size(332, 323);
            this.minMaxComplexityTableLayout.TabIndex = 7;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 523);
            this.Controls.Add(this.minMaxComplexityTableLayout);
            this.Controls.Add(this.cycleTableLayoutPanel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel cycleTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel minMaxComplexityTableLayout;
    }
}