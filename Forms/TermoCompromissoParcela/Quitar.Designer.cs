namespace Forms.TermoCompromissoParcela
{
    partial class Quitar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quitar));
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewTermos = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnData2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewParcelas = new System.Windows.Forms.DataGridView();
            this.ColumnId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.descontarParcelaCB = new System.Windows.Forms.CheckBox();
            this.descontarParcelaTB = new System.Windows.Forms.TextBox();
            this.lineHorizontalSeparator1 = new Library.Controls.LineHorizontalSeparator();
            this.lineVerticalSeparator1 = new Library.Controls.LineVerticalSeparator();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttonReceber = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTermos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
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
            this.comboBoxEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
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
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Termos de Compromisso";
            // 
            // dataGridViewTermos
            // 
            this.dataGridViewTermos.AllowUserToAddRows = false;
            this.dataGridViewTermos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTermos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewTermos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewTermos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTermos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnCliente,
            this.ColumnEmpresa,
            this.ColumnData2});
            this.dataGridViewTermos.Location = new System.Drawing.Point(12, 134);
            this.dataGridViewTermos.MultiSelect = false;
            this.dataGridViewTermos.Name = "dataGridViewTermos";
            this.dataGridViewTermos.ReadOnly = true;
            this.dataGridViewTermos.RowHeadersVisible = false;
            this.dataGridViewTermos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTermos.Size = new System.Drawing.Size(383, 259);
            this.dataGridViewTermos.TabIndex = 9;
            this.dataGridViewTermos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTermos_CellClick);
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "Código";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Visible = false;
            // 
            // ColumnCliente
            // 
            this.ColumnCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCliente.HeaderText = "Cliente";
            this.ColumnCliente.Name = "ColumnCliente";
            this.ColumnCliente.ReadOnly = true;
            // 
            // ColumnEmpresa
            // 
            this.ColumnEmpresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnEmpresa.HeaderText = "Empresa";
            this.ColumnEmpresa.Name = "ColumnEmpresa";
            this.ColumnEmpresa.ReadOnly = true;
            // 
            // ColumnData2
            // 
            this.ColumnData2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.ColumnData2.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnData2.HeaderText = "Data";
            this.ColumnData2.Name = "ColumnData2";
            this.ColumnData2.ReadOnly = true;
            this.ColumnData2.Width = 53;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Parcelas";
            // 
            // dataGridViewParcelas
            // 
            this.dataGridViewParcelas.AllowUserToAddRows = false;
            this.dataGridViewParcelas.AllowUserToDeleteRows = false;
            this.dataGridViewParcelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewParcelas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewParcelas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId2,
            this.ColumnNumero,
            this.ColumnValor,
            this.ColumnData,
            this.ColumnIcon});
            this.dataGridViewParcelas.Location = new System.Drawing.Point(409, 134);
            this.dataGridViewParcelas.MultiSelect = false;
            this.dataGridViewParcelas.Name = "dataGridViewParcelas";
            this.dataGridViewParcelas.ReadOnly = true;
            this.dataGridViewParcelas.RowHeadersVisible = false;
            this.dataGridViewParcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewParcelas.Size = new System.Drawing.Size(228, 259);
            this.dataGridViewParcelas.TabIndex = 9;
            // 
            // ColumnId2
            // 
            this.ColumnId2.HeaderText = "Código";
            this.ColumnId2.Name = "ColumnId2";
            this.ColumnId2.ReadOnly = true;
            this.ColumnId2.Visible = false;
            // 
            // ColumnNumero
            // 
            this.ColumnNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnNumero.HeaderText = "Nº";
            this.ColumnNumero.Name = "ColumnNumero";
            this.ColumnNumero.ReadOnly = true;
            this.ColumnNumero.Width = 42;
            // 
            // ColumnValor
            // 
            this.ColumnValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnValor.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnValor.HeaderText = "Valor";
            this.ColumnValor.Name = "ColumnValor";
            this.ColumnValor.ReadOnly = true;
            // 
            // ColumnData
            // 
            this.ColumnData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.ColumnData.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnData.HeaderText = "Data";
            this.ColumnData.Name = "ColumnData";
            this.ColumnData.ReadOnly = true;
            // 
            // ColumnIcon
            // 
            this.ColumnIcon.FillWeight = 22F;
            this.ColumnIcon.HeaderText = "";
            this.ColumnIcon.Image = global::Forms.Properties.Resources.blank;
            this.ColumnIcon.MinimumWidth = 22;
            this.ColumnIcon.Name = "ColumnIcon";
            this.ColumnIcon.ReadOnly = true;
            this.ColumnIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIcon.Width = 22;
            // 
            // descontarParcelaCB
            // 
            this.descontarParcelaCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.descontarParcelaCB.AutoSize = true;
            this.descontarParcelaCB.Location = new System.Drawing.Point(431, 408);
            this.descontarParcelaCB.Name = "descontarParcelaCB";
            this.descontarParcelaCB.Size = new System.Drawing.Size(138, 17);
            this.descontarParcelaCB.TabIndex = 13;
            this.descontarParcelaCB.Text = "Pagar valor em parcela:";
            this.descontarParcelaCB.UseVisualStyleBackColor = true;
            this.descontarParcelaCB.CheckedChanged += new System.EventHandler(this.descontarParcelaCB_CheckedChanged);
            this.descontarParcelaCB.Click += new System.EventHandler(this.descontarParcelaCB_Click);
            // 
            // descontarParcelaTB
            // 
            this.descontarParcelaTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.descontarParcelaTB.Location = new System.Drawing.Point(431, 431);
            this.descontarParcelaTB.Name = "descontarParcelaTB";
            this.descontarParcelaTB.Size = new System.Drawing.Size(138, 20);
            this.descontarParcelaTB.TabIndex = 14;
            // 
            // lineHorizontalSeparator1
            // 
            this.lineHorizontalSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineHorizontalSeparator1.Location = new System.Drawing.Point(12, 97);
            this.lineHorizontalSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineHorizontalSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineHorizontalSeparator1.Name = "lineHorizontalSeparator1";
            this.lineHorizontalSeparator1.Size = new System.Drawing.Size(625, 2);
            this.lineHorizontalSeparator1.TabIndex = 11;
            // 
            // lineVerticalSeparator1
            // 
            this.lineVerticalSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineVerticalSeparator1.Location = new System.Drawing.Point(401, 97);
            this.lineVerticalSeparator1.MaximumSize = new System.Drawing.Size(2, 2000);
            this.lineVerticalSeparator1.MinimumSize = new System.Drawing.Size(2, 0);
            this.lineVerticalSeparator1.Name = "lineVerticalSeparator1";
            this.lineVerticalSeparator1.Size = new System.Drawing.Size(2, 296);
            this.lineVerticalSeparator1.TabIndex = 10;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 22F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Forms.Properties.Resources.accept;
            this.dataGridViewImageColumn1.MinimumWidth = 22;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 22;
            // 
            // buttonReceber
            // 
            this.buttonReceber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReceber.Image = ((System.Drawing.Image)(resources.GetObject("buttonReceber.Image")));
            this.buttonReceber.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonReceber.Location = new System.Drawing.Point(581, 399);
            this.buttonReceber.Name = "buttonReceber";
            this.buttonReceber.Size = new System.Drawing.Size(56, 58);
            this.buttonReceber.TabIndex = 12;
            this.buttonReceber.Text = "Receber";
            this.buttonReceber.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonReceber.UseVisualStyleBackColor = true;
            this.buttonReceber.Click += new System.EventHandler(this.buttonReceber_Click);
            // 
            // Quitar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 469);
            this.Controls.Add(this.descontarParcelaTB);
            this.Controls.Add(this.descontarParcelaCB);
            this.Controls.Add(this.buttonReceber);
            this.Controls.Add(this.lineHorizontalSeparator1);
            this.Controls.Add(this.lineVerticalSeparator1);
            this.Controls.Add(this.dataGridViewParcelas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewTermos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxEmpresa);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Quitar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receber Parcela";
            this.Load += new System.EventHandler(this.Quitar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTermos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewTermos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewParcelas;
        private Library.Controls.LineVerticalSeparator lineVerticalSeparator1;
        private Library.Controls.LineHorizontalSeparator lineHorizontalSeparator1;
        private System.Windows.Forms.Button buttonReceber;
        private System.Windows.Forms.CheckBox descontarParcelaCB;
        private System.Windows.Forms.TextBox descontarParcelaTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnData2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnData;
        private System.Windows.Forms.DataGridViewImageColumn ColumnIcon;
    }
}