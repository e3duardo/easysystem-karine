namespace Forms.TermoCompromisso
{
    partial class JudicialView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JudicialView));
            this.lineHorizontalSeparator1 = new Library.Controls.LineHorizontalSeparator();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lineHorizontalSeparator1
            // 
            this.lineHorizontalSeparator1.Location = new System.Drawing.Point(7, 98);
            this.lineHorizontalSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineHorizontalSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineHorizontalSeparator1.Name = "lineHorizontalSeparator1";
            this.lineHorizontalSeparator1.Size = new System.Drawing.Size(260, 2);
            this.lineHorizontalSeparator1.TabIndex = 14;
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(19, 71);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(236, 21);
            this.comboBoxCliente.TabIndex = 13;
            this.comboBoxCliente.SelectedIndexChanged += new System.EventHandler(this.comboBoxCliente_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Cliente:";
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(19, 26);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(236, 21);
            this.comboBoxEmpresa.TabIndex = 11;
            this.comboBoxEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboBoxEmpresa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Empresa:";
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Image = ((System.Drawing.Image)(resources.GetObject("buttonImprimir.Image")));
            this.buttonImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonImprimir.Location = new System.Drawing.Point(95, 106);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(85, 66);
            this.buttonImprimir.TabIndex = 18;
            this.buttonImprimir.Text = "Imprimir";
            this.buttonImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonImprimir.UseVisualStyleBackColor = true;
            this.buttonImprimir.Click += new System.EventHandler(this.buttonImprimir_Click);
            // 
            // JudicialView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 181);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.lineHorizontalSeparator1);
            this.Controls.Add(this.comboBoxCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxEmpresa);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JudicialView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Judicial";
            this.Load += new System.EventHandler(this.JudicialView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Library.Controls.LineHorizontalSeparator lineHorizontalSeparator1;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonImprimir;
    }
}