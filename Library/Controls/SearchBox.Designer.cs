using System.ComponentModel;

namespace Library.Controls
{
    partial class SearchBox
    {
        [Category("Advanced")]
        [Description("Escolhe tipo de pesquisa.")]
        [DisplayName("Tipo")]
        public tipo Tipo { get; set; }

        

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.resultadoDGV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filtrosGB = new System.Windows.Forms.GroupBox();
            this.pesquisarButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.filtrosTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultadoDGV)).BeginInit();
            this.filtrosGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultadoDGV
            // 
            this.resultadoDGV.AllowUserToAddRows = false;
            this.resultadoDGV.AllowUserToDeleteRows = false;
            this.resultadoDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultadoDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resultadoDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.resultadoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultadoDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.resultadoDGV.Location = new System.Drawing.Point(3, 116);
            this.resultadoDGV.Margin = new System.Windows.Forms.Padding(6);
            this.resultadoDGV.Name = "resultadoDGV";
            this.resultadoDGV.ReadOnly = true;
            this.resultadoDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultadoDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.resultadoDGV.RowHeadersVisible = false;
            this.resultadoDGV.RowHeadersWidth = 16;
            this.resultadoDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultadoDGV.Size = new System.Drawing.Size(241, 261);
            this.resultadoDGV.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Nome";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "Data";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 53;
            // 
            // filtrosGB
            // 
            this.filtrosGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filtrosGB.Controls.Add(this.pesquisarButton);
            this.filtrosGB.Controls.Add(this.label4);
            this.filtrosGB.Controls.Add(this.filtrosTextBox);
            this.filtrosGB.Location = new System.Drawing.Point(3, 5);
            this.filtrosGB.Margin = new System.Windows.Forms.Padding(6);
            this.filtrosGB.Name = "filtrosGB";
            this.filtrosGB.Size = new System.Drawing.Size(241, 99);
            this.filtrosGB.TabIndex = 3;
            this.filtrosGB.TabStop = false;
            this.filtrosGB.Text = "Filtros";
            // 
            // pesquisarButton
            // 
            this.pesquisarButton.Location = new System.Drawing.Point(6, 66);
            this.pesquisarButton.Name = "pesquisarButton";
            this.pesquisarButton.Size = new System.Drawing.Size(75, 23);
            this.pesquisarButton.TabIndex = 2;
            this.pesquisarButton.Text = "Pesquisar";
            this.pesquisarButton.UseVisualStyleBackColor = true;
            this.pesquisarButton.Click += new System.EventHandler(this.pesquisarButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nome ou código:";
            // 
            // filtrosTextBox
            // 
            this.filtrosTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filtrosTextBox.Location = new System.Drawing.Point(6, 39);
            this.filtrosTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 19, 3);
            this.filtrosTextBox.Name = "filtrosTextBox";
            this.filtrosTextBox.Size = new System.Drawing.Size(213, 20);
            this.filtrosTextBox.TabIndex = 1;
            // 
            // SearchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resultadoDGV);
            this.Controls.Add(this.filtrosGB);
            this.Name = "SearchBox";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(247, 382);
            ((System.ComponentModel.ISupportInitialize)(this.resultadoDGV)).EndInit();
            this.filtrosGB.ResumeLayout(false);
            this.filtrosGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox filtrosGB;
        private System.Windows.Forms.Button pesquisarButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox filtrosTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        public System.Windows.Forms.DataGridView resultadoDGV;
    }
}
