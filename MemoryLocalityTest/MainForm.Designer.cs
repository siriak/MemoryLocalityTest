namespace MemoryLocalityTest
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart_Main = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox_StartMatrixSize = new System.Windows.Forms.TextBox();
            this.label_StartMatrixSize = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.label_MaxMatrixSize = new System.Windows.Forms.Label();
            this.textBox_MaxMatrixSize = new System.Windows.Forms.TextBox();
            this.label_TestTimes = new System.Windows.Forms.Label();
            this.textBox_TestTimes = new System.Windows.Forms.TextBox();
            this.button_Stop = new System.Windows.Forms.Button();
            this.groupBox_MatrixSizeIncrementType = new System.Windows.Forms.GroupBox();
            this.radioButton_Multiply = new System.Windows.Forms.RadioButton();
            this.radioButton_Add = new System.Windows.Forms.RadioButton();
            this.label_NIncrement = new System.Windows.Forms.Label();
            this.textBox_NIncrement = new System.Windows.Forms.TextBox();
            this.label_BlockSizeToTest = new System.Windows.Forms.Label();
            this.textBox_BlockSizeToTest = new System.Windows.Forms.TextBox();
            this.checkBox_UseReferences = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Main)).BeginInit();
            this.groupBox_MatrixSizeIncrementType.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart_Main
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_Main.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_Main.Legends.Add(legend1);
            this.chart_Main.Location = new System.Drawing.Point(109, 12);
            this.chart_Main.Name = "chart_Main";
            this.chart_Main.Size = new System.Drawing.Size(1143, 657);
            this.chart_Main.TabIndex = 0;
            this.chart_Main.Text = "Main chart";
            // 
            // textBox_StartMatrixSize
            // 
            this.textBox_StartMatrixSize.Location = new System.Drawing.Point(12, 29);
            this.textBox_StartMatrixSize.Name = "textBox_StartMatrixSize";
            this.textBox_StartMatrixSize.Size = new System.Drawing.Size(91, 20);
            this.textBox_StartMatrixSize.TabIndex = 1;
            this.textBox_StartMatrixSize.Text = "0";
            // 
            // label_StartMatrixSize
            // 
            this.label_StartMatrixSize.AutoSize = true;
            this.label_StartMatrixSize.Location = new System.Drawing.Point(13, 13);
            this.label_StartMatrixSize.Name = "label_StartMatrixSize";
            this.label_StartMatrixSize.Size = new System.Drawing.Size(80, 13);
            this.label_StartMatrixSize.TabIndex = 2;
            this.label_StartMatrixSize.Text = "Start matrix size";
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(12, 211);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(91, 23);
            this.button_Start.TabIndex = 3;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // label_MaxMatrixSize
            // 
            this.label_MaxMatrixSize.AutoSize = true;
            this.label_MaxMatrixSize.Location = new System.Drawing.Point(13, 52);
            this.label_MaxMatrixSize.Name = "label_MaxMatrixSize";
            this.label_MaxMatrixSize.Size = new System.Drawing.Size(78, 13);
            this.label_MaxMatrixSize.TabIndex = 5;
            this.label_MaxMatrixSize.Text = "Max matrix size";
            // 
            // textBox_MaxMatrixSize
            // 
            this.textBox_MaxMatrixSize.Location = new System.Drawing.Point(12, 68);
            this.textBox_MaxMatrixSize.Name = "textBox_MaxMatrixSize";
            this.textBox_MaxMatrixSize.Size = new System.Drawing.Size(91, 20);
            this.textBox_MaxMatrixSize.TabIndex = 4;
            this.textBox_MaxMatrixSize.Text = "20000";
            // 
            // label_TestTimes
            // 
            this.label_TestTimes.AutoSize = true;
            this.label_TestTimes.Location = new System.Drawing.Point(13, 91);
            this.label_TestTimes.Name = "label_TestTimes";
            this.label_TestTimes.Size = new System.Drawing.Size(55, 13);
            this.label_TestTimes.TabIndex = 7;
            this.label_TestTimes.Text = "Test times";
            // 
            // textBox_TestTimes
            // 
            this.textBox_TestTimes.Location = new System.Drawing.Point(12, 107);
            this.textBox_TestTimes.Name = "textBox_TestTimes";
            this.textBox_TestTimes.Size = new System.Drawing.Size(91, 20);
            this.textBox_TestTimes.TabIndex = 6;
            this.textBox_TestTimes.Text = "5";
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(12, 240);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(91, 23);
            this.button_Stop.TabIndex = 8;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // groupBox_MatrixSizeIncrementType
            // 
            this.groupBox_MatrixSizeIncrementType.Controls.Add(this.radioButton_Multiply);
            this.groupBox_MatrixSizeIncrementType.Controls.Add(this.radioButton_Add);
            this.groupBox_MatrixSizeIncrementType.Location = new System.Drawing.Point(13, 270);
            this.groupBox_MatrixSizeIncrementType.Name = "groupBox_MatrixSizeIncrementType";
            this.groupBox_MatrixSizeIncrementType.Size = new System.Drawing.Size(90, 70);
            this.groupBox_MatrixSizeIncrementType.TabIndex = 9;
            this.groupBox_MatrixSizeIncrementType.TabStop = false;
            this.groupBox_MatrixSizeIncrementType.Text = "N Increment";
            // 
            // radioButton_Multiply
            // 
            this.radioButton_Multiply.AutoSize = true;
            this.radioButton_Multiply.Location = new System.Drawing.Point(6, 42);
            this.radioButton_Multiply.Name = "radioButton_Multiply";
            this.radioButton_Multiply.Size = new System.Drawing.Size(60, 17);
            this.radioButton_Multiply.TabIndex = 1;
            this.radioButton_Multiply.Text = "Multiply";
            this.radioButton_Multiply.UseVisualStyleBackColor = true;
            // 
            // radioButton_Add
            // 
            this.radioButton_Add.AutoSize = true;
            this.radioButton_Add.Checked = true;
            this.radioButton_Add.Location = new System.Drawing.Point(6, 19);
            this.radioButton_Add.Name = "radioButton_Add";
            this.radioButton_Add.Size = new System.Drawing.Size(44, 17);
            this.radioButton_Add.TabIndex = 0;
            this.radioButton_Add.TabStop = true;
            this.radioButton_Add.Text = "Add";
            this.radioButton_Add.UseVisualStyleBackColor = true;
            // 
            // label_NIncrement
            // 
            this.label_NIncrement.AutoSize = true;
            this.label_NIncrement.Location = new System.Drawing.Point(13, 130);
            this.label_NIncrement.Name = "label_NIncrement";
            this.label_NIncrement.Size = new System.Drawing.Size(65, 13);
            this.label_NIncrement.TabIndex = 11;
            this.label_NIncrement.Text = "N Increment";
            // 
            // textBox_NIncrement
            // 
            this.textBox_NIncrement.Location = new System.Drawing.Point(12, 146);
            this.textBox_NIncrement.Name = "textBox_NIncrement";
            this.textBox_NIncrement.Size = new System.Drawing.Size(91, 20);
            this.textBox_NIncrement.TabIndex = 10;
            this.textBox_NIncrement.Text = "500";
            // 
            // label_BlockSizeToTest
            // 
            this.label_BlockSizeToTest.AutoSize = true;
            this.label_BlockSizeToTest.Location = new System.Drawing.Point(13, 169);
            this.label_BlockSizeToTest.Name = "label_BlockSizeToTest";
            this.label_BlockSizeToTest.Size = new System.Drawing.Size(87, 13);
            this.label_BlockSizeToTest.TabIndex = 13;
            this.label_BlockSizeToTest.Text = "Block size to test";
            // 
            // textBox_BlockSizeToTest
            // 
            this.textBox_BlockSizeToTest.Location = new System.Drawing.Point(12, 185);
            this.textBox_BlockSizeToTest.Name = "textBox_BlockSizeToTest";
            this.textBox_BlockSizeToTest.Size = new System.Drawing.Size(91, 20);
            this.textBox_BlockSizeToTest.TabIndex = 12;
            this.textBox_BlockSizeToTest.Text = "500";
            // 
            // checkBox_UseReferences
            // 
            this.checkBox_UseReferences.AutoSize = true;
            this.checkBox_UseReferences.Location = new System.Drawing.Point(12, 346);
            this.checkBox_UseReferences.Name = "checkBox_UseReferences";
            this.checkBox_UseReferences.Size = new System.Drawing.Size(98, 17);
            this.checkBox_UseReferences.TabIndex = 14;
            this.checkBox_UseReferences.Text = "Use references";
            this.checkBox_UseReferences.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.checkBox_UseReferences);
            this.Controls.Add(this.label_BlockSizeToTest);
            this.Controls.Add(this.textBox_BlockSizeToTest);
            this.Controls.Add(this.label_NIncrement);
            this.Controls.Add(this.textBox_NIncrement);
            this.Controls.Add(this.groupBox_MatrixSizeIncrementType);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.label_TestTimes);
            this.Controls.Add(this.textBox_TestTimes);
            this.Controls.Add(this.label_MaxMatrixSize);
            this.Controls.Add(this.textBox_MaxMatrixSize);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.label_StartMatrixSize);
            this.Controls.Add(this.textBox_StartMatrixSize);
            this.Controls.Add(this.chart_Main);
            this.Name = "MainForm";
            this.Text = "Memory locality test";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Main)).EndInit();
            this.groupBox_MatrixSizeIncrementType.ResumeLayout(false);
            this.groupBox_MatrixSizeIncrementType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Main;
        private System.Windows.Forms.TextBox textBox_StartMatrixSize;
        private System.Windows.Forms.Label label_StartMatrixSize;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label label_MaxMatrixSize;
        private System.Windows.Forms.TextBox textBox_MaxMatrixSize;
        private System.Windows.Forms.Label label_TestTimes;
        private System.Windows.Forms.TextBox textBox_TestTimes;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.GroupBox groupBox_MatrixSizeIncrementType;
        private System.Windows.Forms.RadioButton radioButton_Multiply;
        private System.Windows.Forms.RadioButton radioButton_Add;
        private System.Windows.Forms.Label label_NIncrement;
        private System.Windows.Forms.TextBox textBox_NIncrement;
        private System.Windows.Forms.Label label_BlockSizeToTest;
        private System.Windows.Forms.TextBox textBox_BlockSizeToTest;
        private System.Windows.Forms.CheckBox checkBox_UseReferences;
    }
}

