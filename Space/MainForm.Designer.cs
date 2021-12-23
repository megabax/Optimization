namespace Space
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.btnSphere = new System.Windows.Forms.Button();
            this.btnOptimize = new System.Windows.Forms.Button();
            this.btnLineOpt = new System.Windows.Forms.Button();
            this.btnLineOpt2 = new System.Windows.Forms.Button();
            this.btnUnimodal2 = new System.Windows.Forms.Button();
            this.btnIzom = new System.Windows.Forms.Button();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.tbMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(6, 6);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(463, 440);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            // 
            // btnSphere
            // 
            this.btnSphere.Location = new System.Drawing.Point(758, 71);
            this.btnSphere.Name = "btnSphere";
            this.btnSphere.Size = new System.Drawing.Size(75, 23);
            this.btnSphere.TabIndex = 1;
            this.btnSphere.Text = "Сфера";
            this.btnSphere.UseVisualStyleBackColor = true;
            this.btnSphere.Click += new System.EventHandler(this.btnSphere_Click);
            // 
            // btnOptimize
            // 
            this.btnOptimize.Location = new System.Drawing.Point(16, 12);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(103, 23);
            this.btnOptimize.TabIndex = 2;
            this.btnOptimize.Text = "Оптимизация";
            this.btnOptimize.UseVisualStyleBackColor = true;
            this.btnOptimize.Click += new System.EventHandler(this.btnOptimize_Click);
            // 
            // btnLineOpt
            // 
            this.btnLineOpt.Location = new System.Drawing.Point(125, 12);
            this.btnLineOpt.Name = "btnLineOpt";
            this.btnLineOpt.Size = new System.Drawing.Size(103, 23);
            this.btnLineOpt.TabIndex = 3;
            this.btnLineOpt.Text = "Оптимизация 1";
            this.btnLineOpt.UseVisualStyleBackColor = true;
            this.btnLineOpt.Click += new System.EventHandler(this.btnLineOpt_Click);
            // 
            // btnLineOpt2
            // 
            this.btnLineOpt2.Location = new System.Drawing.Point(234, 12);
            this.btnLineOpt2.Name = "btnLineOpt2";
            this.btnLineOpt2.Size = new System.Drawing.Size(103, 23);
            this.btnLineOpt2.TabIndex = 4;
            this.btnLineOpt2.Text = "Оптимизация 2";
            this.btnLineOpt2.UseVisualStyleBackColor = true;
            this.btnLineOpt2.Click += new System.EventHandler(this.btnLineOpt2_Click);
            // 
            // btnUnimodal2
            // 
            this.btnUnimodal2.Location = new System.Drawing.Point(758, 100);
            this.btnUnimodal2.Name = "btnUnimodal2";
            this.btnUnimodal2.Size = new System.Drawing.Size(141, 23);
            this.btnUnimodal2.TabIndex = 5;
            this.btnUnimodal2.Text = "Унимодальная функция 2";
            this.btnUnimodal2.UseVisualStyleBackColor = true;
            this.btnUnimodal2.Click += new System.EventHandler(this.btnUnimodal2_Click);
            // 
            // btnIzom
            // 
            this.btnIzom.Location = new System.Drawing.Point(758, 129);
            this.btnIzom.Name = "btnIzom";
            this.btnIzom.Size = new System.Drawing.Size(141, 23);
            this.btnIzom.TabIndex = 6;
            this.btnIzom.Text = "Функция изома";
            this.btnIzom.UseVisualStyleBackColor = true;
            this.btnIzom.Click += new System.EventHandler(this.btnIzom_Click);
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tabPage1);
            this.tbMain.Controls.Add(this.tabPage2);
            this.tbMain.Location = new System.Drawing.Point(14, 49);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(738, 563);
            this.tbMain.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pbMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(492, 466);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Карта";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(730, 537);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "График";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(10, 7);
            this.chart.Name = "chart";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(709, 516);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 624);
            this.Controls.Add(this.btnIzom);
            this.Controls.Add(this.btnLineOpt2);
            this.Controls.Add(this.btnUnimodal2);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.btnSphere);
            this.Controls.Add(this.btnLineOpt);
            this.Controls.Add(this.btnOptimize);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.tbMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Button btnSphere;
        private System.Windows.Forms.Button btnOptimize;
        private System.Windows.Forms.Button btnLineOpt;
        private System.Windows.Forms.Button btnLineOpt2;
        private System.Windows.Forms.Button btnUnimodal2;
        private System.Windows.Forms.Button btnIzom;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}

