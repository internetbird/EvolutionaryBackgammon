namespace EvolutionaryBackgammon
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series33 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series34 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series35 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title9 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series36 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series37 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series38 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series39 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series40 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title10 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.Settings = new System.Windows.Forms.GroupBox();
            this.cmbCrossoverProbability = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.generationProgressBar = new System.Windows.Forms.ProgressBar();
            this.cmbMutationProbability = new System.Windows.Forms.ComboBox();
            this.lblAlgorithmStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNumOfGenerations = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNumOfGamesPerGen = new System.Windows.Forms.ComboBox();
            this.cmbPopulationSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRunAlgorithm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbSummary = new System.Windows.Forms.TextBox();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.cmbCrossoverProbability);
            this.Settings.Controls.Add(this.label5);
            this.Settings.Controls.Add(this.generationProgressBar);
            this.Settings.Controls.Add(this.cmbMutationProbability);
            this.Settings.Controls.Add(this.lblAlgorithmStatus);
            this.Settings.Controls.Add(this.label4);
            this.Settings.Controls.Add(this.cmbNumOfGenerations);
            this.Settings.Controls.Add(this.label3);
            this.Settings.Controls.Add(this.cmbNumOfGamesPerGen);
            this.Settings.Controls.Add(this.cmbPopulationSize);
            this.Settings.Controls.Add(this.label2);
            this.Settings.Controls.Add(this.btnRunAlgorithm);
            this.Settings.Controls.Add(this.label1);
            this.Settings.Location = new System.Drawing.Point(21, 10);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(1402, 72);
            this.Settings.TabIndex = 0;
            this.Settings.TabStop = false;
            this.Settings.Text = "Settings";
            // 
            // cmbCrossoverProbability
            // 
            this.cmbCrossoverProbability.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCrossoverProbability.FormattingEnabled = true;
            this.cmbCrossoverProbability.Items.AddRange(new object[] {
            "1",
            "0.75",
            "0.5",
            "0"});
            this.cmbCrossoverProbability.Location = new System.Drawing.Point(643, 25);
            this.cmbCrossoverProbability.Name = "cmbCrossoverProbability";
            this.cmbCrossoverProbability.Size = new System.Drawing.Size(58, 21);
            this.cmbCrossoverProbability.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Crossover Probability:";
            // 
            // generationProgressBar
            // 
            this.generationProgressBar.Location = new System.Drawing.Point(1039, 23);
            this.generationProgressBar.Name = "generationProgressBar";
            this.generationProgressBar.Size = new System.Drawing.Size(197, 23);
            this.generationProgressBar.TabIndex = 5;
            this.generationProgressBar.Visible = false;
            // 
            // cmbMutationProbability
            // 
            this.cmbMutationProbability.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMutationProbability.FormattingEnabled = true;
            this.cmbMutationProbability.Items.AddRange(new object[] {
            "0.01",
            "0.02",
            "0.05",
            "0.1",
            "0"});
            this.cmbMutationProbability.Location = new System.Drawing.Point(822, 25);
            this.cmbMutationProbability.Name = "cmbMutationProbability";
            this.cmbMutationProbability.Size = new System.Drawing.Size(52, 21);
            this.cmbMutationProbability.TabIndex = 9;
            // 
            // lblAlgorithmStatus
            // 
            this.lblAlgorithmStatus.AutoSize = true;
            this.lblAlgorithmStatus.Location = new System.Drawing.Point(1247, 28);
            this.lblAlgorithmStatus.Name = "lblAlgorithmStatus";
            this.lblAlgorithmStatus.Size = new System.Drawing.Size(0, 13);
            this.lblAlgorithmStatus.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(712, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mutation Probability:";
            // 
            // cmbNumOfGenerations
            // 
            this.cmbNumOfGenerations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumOfGenerations.FormattingEnabled = true;
            this.cmbNumOfGenerations.Items.AddRange(new object[] {
            "30",
            "40",
            "50",
            "100"});
            this.cmbNumOfGenerations.Location = new System.Drawing.Point(474, 25);
            this.cmbNumOfGenerations.Name = "cmbNumOfGenerations";
            this.cmbNumOfGenerations.Size = new System.Drawing.Size(47, 21);
            this.cmbNumOfGenerations.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Num Of Generation:";
            // 
            // cmbNumOfGamesPerGen
            // 
            this.cmbNumOfGamesPerGen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumOfGamesPerGen.FormattingEnabled = true;
            this.cmbNumOfGamesPerGen.Items.AddRange(new object[] {
            "30",
            "40",
            "50"});
            this.cmbNumOfGamesPerGen.Location = new System.Drawing.Point(311, 25);
            this.cmbNumOfGamesPerGen.Name = "cmbNumOfGamesPerGen";
            this.cmbNumOfGamesPerGen.Size = new System.Drawing.Size(46, 21);
            this.cmbNumOfGamesPerGen.TabIndex = 5;
            // 
            // cmbPopulationSize
            // 
            this.cmbPopulationSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPopulationSize.FormattingEnabled = true;
            this.cmbPopulationSize.Items.AddRange(new object[] {
            "50",
            "100",
            "200"});
            this.cmbPopulationSize.Location = new System.Drawing.Point(94, 25);
            this.cmbPopulationSize.Name = "cmbPopulationSize";
            this.cmbPopulationSize.Size = new System.Drawing.Size(48, 21);
            this.cmbPopulationSize.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Num Of Games Per Generation:";
            // 
            // btnRunAlgorithm
            // 
            this.btnRunAlgorithm.Location = new System.Drawing.Point(901, 16);
            this.btnRunAlgorithm.Name = "btnRunAlgorithm";
            this.btnRunAlgorithm.Size = new System.Drawing.Size(122, 36);
            this.btnRunAlgorithm.TabIndex = 2;
            this.btnRunAlgorithm.Text = "Run Algorithm";
            this.btnRunAlgorithm.UseVisualStyleBackColor = true;
            this.btnRunAlgorithm.Click += new System.EventHandler(this.btnRunAlgorithm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Population Size:";
            // 
            // chart1
            // 
            chartArea9.AxisX.Title = "Generation Number";
            chartArea9.AxisY.Title = "Precent Of Games Won";
            chartArea9.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.chart1.Legends.Add(legend9);
            this.chart1.Location = new System.Drawing.Point(21, 100);
            this.chart1.Name = "chart1";
            series33.ChartArea = "ChartArea1";
            series33.Legend = "Legend1";
            series33.Name = "BestGenFitness";
            series34.ChartArea = "ChartArea1";
            series34.Legend = "Legend1";
            series34.Name = "WorstGenFitness";
            series35.ChartArea = "ChartArea1";
            series35.Legend = "Legend1";
            series35.Name = "AverageGenFitness";
            this.chart1.Series.Add(series33);
            this.chart1.Series.Add(series34);
            this.chart1.Series.Add(series35);
            this.chart1.Size = new System.Drawing.Size(867, 644);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            title9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title9.Name = "Generation Fiteness Values";
            title9.Text = "Generation Fitness Values";
            this.chart1.Titles.Add(title9);
            // 
            // chart2
            // 
            chartArea10.AxisX.Title = "Generation Number";
            chartArea10.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chart2.Legends.Add(legend10);
            this.chart2.Location = new System.Drawing.Point(894, 100);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series36.ChartArea = "ChartArea1";
            series36.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            series36.Legend = "Legend1";
            series36.Name = "BuildWallsOnStonesAtRisk";
            series37.ChartArea = "ChartArea1";
            series37.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            series37.Legend = "Legend1";
            series37.Name = "HitOpponentStones";
            series38.ChartArea = "ChartArea1";
            series38.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            series38.Legend = "Legend1";
            series38.Name = "MinimizeNumOfSteps";
            series39.ChartArea = "ChartArea1";
            series39.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            series39.Legend = "Legend1";
            series39.Name = "MaximizeNumOfWalls";
            series40.ChartArea = "ChartArea1";
            series40.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            series40.Legend = "Legend1";
            series40.Name = "ChooseRandomMove";
            series40.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chart2.Series.Add(series36);
            this.chart2.Series.Add(series37);
            this.chart2.Series.Add(series38);
            this.chart2.Series.Add(series39);
            this.chart2.Series.Add(series40);
            this.chart2.Size = new System.Drawing.Size(529, 349);
            this.chart2.TabIndex = 6;
            this.chart2.Text = "chart2";
            title10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title10.Name = "Title1";
            title10.Text = "Best Player\'s chromosome structure";
            this.chart2.Titles.Add(title10);
            // 
            // tbSummary
            // 
            this.tbSummary.BackColor = System.Drawing.SystemColors.InfoText;
            this.tbSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbSummary.ForeColor = System.Drawing.Color.Lime;
            this.tbSummary.Location = new System.Drawing.Point(894, 464);
            this.tbSummary.Multiline = true;
            this.tbSummary.Name = "tbSummary";
            this.tbSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSummary.Size = new System.Drawing.Size(529, 280);
            this.tbSummary.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 770);
            this.Controls.Add(this.tbSummary);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.Settings);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Settings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunAlgorithm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNumOfGamesPerGen;
        private System.Windows.Forms.ComboBox cmbPopulationSize;
        private System.Windows.Forms.ComboBox cmbNumOfGenerations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMutationProbability;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCrossoverProbability;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblAlgorithmStatus;
        private System.Windows.Forms.ProgressBar generationProgressBar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TextBox tbSummary;
    }
}

