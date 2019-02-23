namespace Forms.TermoCompromisso
{
    partial class TermoCompromissoView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TermoCompromissoView));
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lineHorizontalSeparator1 = new Library.Controls.LineHorizontalSeparator();
            this.textBoxValor = new Library.Windows.Forms.MoneyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxParcelas = new System.Windows.Forms.TextBox();
            this.dataGridViewResultado = new System.Windows.Forms.DataGridView();
            this.ColumnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCalcular = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerData = new System.Windows.Forms.DateTimePicker();
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.lineHorizontalSeparator2 = new Library.Controls.LineHorizontalSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultado)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(12, 70);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(236, 21);
            this.comboBoxCliente.TabIndex = 7;
            this.comboBoxCliente.SelectedIndexChanged += new System.EventHandler(this.comboBoxCliente_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cliente:";
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(12, 25);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(236, 21);
            this.comboBoxEmpresa.TabIndex = 5;
            this.comboBoxEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboBoxEmpresa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Empresa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Valor:";
            // 
            // lineHorizontalSeparator1
            // 
            this.lineHorizontalSeparator1.Location = new System.Drawing.Point(8, 97);
            this.lineHorizontalSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineHorizontalSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineHorizontalSeparator1.Name = "lineHorizontalSeparator1";
            this.lineHorizontalSeparator1.Size = new System.Drawing.Size(369, 2);
            this.lineHorizontalSeparator1.TabIndex = 9;
            // 
            // textBoxValor
            // 
            this.textBoxValor.Location = new System.Drawing.Point(9, 18);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(100, 20);
            this.textBoxValor.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Parcelas:";
            // 
            // textBoxParcelas
            // 
            this.textBoxParcelas.Location = new System.Drawing.Point(9, 97);
            this.textBoxParcelas.Name = "textBoxParcelas";
            this.textBoxParcelas.Size = new System.Drawing.Size(100, 20);
            this.textBoxParcelas.TabIndex = 12;
            // 
            // dataGridViewResultado
            // 
            this.dataGridViewResultado.AllowUserToAddRows = false;
            this.dataGridViewResultado.AllowUserToDeleteRows = false;
            this.dataGridViewResultado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewResultado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnValor,
            this.ColumnData});
            this.dataGridViewResultado.Location = new System.Drawing.Point(115, 2);
            this.dataGridViewResultado.Name = "dataGridViewResultado";
            this.dataGridViewResultado.ReadOnly = true;
            this.dataGridViewResultado.RowHeadersVisible = false;
            this.dataGridViewResultado.Size = new System.Drawing.Size(254, 290);
            this.dataGridViewResultado.TabIndex = 13;
            // 
            // ColumnValor
            // 
            this.ColumnValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.ColumnValor.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnValor.HeaderText = "Valor";
            this.ColumnValor.Name = "ColumnValor";
            this.ColumnValor.ReadOnly = true;
            // 
            // ColumnData
            // 
            this.ColumnData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnData.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnData.HeaderText = "Data";
            this.ColumnData.Name = "ColumnData";
            this.ColumnData.ReadOnly = true;
            // 
            // buttonCalcular
            // 
            this.buttonCalcular.Location = new System.Drawing.Point(9, 123);
            this.buttonCalcular.Name = "buttonCalcular";
            this.buttonCalcular.Size = new System.Drawing.Size(65, 23);
            this.buttonCalcular.TabIndex = 14;
            this.buttonCalcular.Text = "Calcular";
            this.buttonCalcular.UseVisualStyleBackColor = true;
            this.buttonCalcular.Click += new System.EventHandler(this.buttonCalcular_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Data";
            // 
            // dateTimePickerData
            // 
            this.dateTimePickerData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerData.Location = new System.Drawing.Point(9, 57);
            this.dateTimePickerData.Name = "dateTimePickerData";
            this.dateTimePickerData.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerData.TabIndex = 16;
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Image = ((System.Drawing.Image)(resources.GetObject("buttonImprimir.Image")));
            this.buttonImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonImprimir.Location = new System.Drawing.Point(150, 408);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(85, 66);
            this.buttonImprimir.TabIndex = 17;
            this.buttonImprimir.Text = "Imprimir";
            this.buttonImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonImprimir.UseVisualStyleBackColor = true;
            this.buttonImprimir.Click += new System.EventHandler(this.buttonImprimir_Click);
            // 
            // lineHorizontalSeparator2
            // 
            this.lineHorizontalSeparator2.Location = new System.Drawing.Point(8, 400);
            this.lineHorizontalSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineHorizontalSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineHorizontalSeparator2.Name = "lineHorizontalSeparator2";
            this.lineHorizontalSeparator2.Size = new System.Drawing.Size(369, 2);
            this.lineHorizontalSeparator2.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxValor);
            this.panel1.Controls.Add(this.dateTimePickerData);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxParcelas);
            this.panel1.Controls.Add(this.buttonCalcular);
            this.panel1.Controls.Add(this.dataGridViewResultado);
            this.panel1.Location = new System.Drawing.Point(3, 102);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 295);
            this.panel1.TabIndex = 18;
            // 
            // TermoCompromissoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 483);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.lineHorizontalSeparator2);
            this.Controls.Add(this.lineHorizontalSeparator1);
            this.Controls.Add(this.comboBoxCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxEmpresa);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TermoCompromissoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TermoCompromisso";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TermoCompromissoView_FormClosed);
            this.Load += new System.EventHandler(this.TermoCompromisso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Library.Controls.LineHorizontalSeparator lineHorizontalSeparator1;
        private Library.Windows.Forms.MoneyTextBox textBoxValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxParcelas;
        private System.Windows.Forms.DataGridView dataGridViewResultado;
        private System.Windows.Forms.Button buttonCalcular;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerData;
        private System.Windows.Forms.Button buttonImprimir;
        private Library.Controls.LineHorizontalSeparator lineHorizontalSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnData;
    }
}