namespace Forms.Cliente
{
    partial class Notificacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notificacao));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lineHorizontalSeparator1 = new Library.Controls.LineHorizontalSeparator();
            this.buttonReimprimir = new System.Windows.Forms.Button();
            this.labelNotificacao3 = new System.Windows.Forms.Label();
            this.labelNotificacao2 = new System.Windows.Forms.Label();
            this.labelNotificacao1 = new System.Windows.Forms.Label();
            this.buttonNotificacao3 = new System.Windows.Forms.Button();
            this.buttonNotificacao1 = new System.Windows.Forms.Button();
            this.buttonNotificacao2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa:";
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(12, 25);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(236, 21);
            this.comboBoxEmpresa.TabIndex = 1;
            this.comboBoxEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboBoxEmpresa_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(12, 70);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(236, 21);
            this.comboBoxCliente.TabIndex = 3;
            this.comboBoxCliente.SelectedIndexChanged += new System.EventHandler(this.comboBoxCliente_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lineHorizontalSeparator1);
            this.groupBox1.Controls.Add(this.buttonReimprimir);
            this.groupBox1.Controls.Add(this.labelNotificacao3);
            this.groupBox1.Controls.Add(this.labelNotificacao2);
            this.groupBox1.Controls.Add(this.labelNotificacao1);
            this.groupBox1.Controls.Add(this.buttonNotificacao3);
            this.groupBox1.Controls.Add(this.buttonNotificacao1);
            this.groupBox1.Controls.Add(this.buttonNotificacao2);
            this.groupBox1.Location = new System.Drawing.Point(12, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 138);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notificações";
            // 
            // lineHorizontalSeparator1
            // 
            this.lineHorizontalSeparator1.Location = new System.Drawing.Point(6, 102);
            this.lineHorizontalSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineHorizontalSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineHorizontalSeparator1.Name = "lineHorizontalSeparator1";
            this.lineHorizontalSeparator1.Size = new System.Drawing.Size(300, 2);
            this.lineHorizontalSeparator1.TabIndex = 3;
            // 
            // buttonReimprimir
            // 
            this.buttonReimprimir.Location = new System.Drawing.Point(108, 110);
            this.buttonReimprimir.Name = "buttonReimprimir";
            this.buttonReimprimir.Size = new System.Drawing.Size(96, 23);
            this.buttonReimprimir.TabIndex = 2;
            this.buttonReimprimir.Text = "Reimprimir";
            this.buttonReimprimir.UseVisualStyleBackColor = true;
            this.buttonReimprimir.Click += new System.EventHandler(this.buttonReimprimir_Click);
            // 
            // labelNotificacao3
            // 
            this.labelNotificacao3.Location = new System.Drawing.Point(210, 79);
            this.labelNotificacao3.Name = "labelNotificacao3";
            this.labelNotificacao3.Size = new System.Drawing.Size(96, 13);
            this.labelNotificacao3.TabIndex = 1;
            this.labelNotificacao3.Text = "dd/MM/yyyy";
            this.labelNotificacao3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNotificacao2
            // 
            this.labelNotificacao2.Location = new System.Drawing.Point(108, 79);
            this.labelNotificacao2.Name = "labelNotificacao2";
            this.labelNotificacao2.Size = new System.Drawing.Size(96, 13);
            this.labelNotificacao2.TabIndex = 1;
            this.labelNotificacao2.Text = "dd/MM/yyyy";
            this.labelNotificacao2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNotificacao1
            // 
            this.labelNotificacao1.Location = new System.Drawing.Point(6, 79);
            this.labelNotificacao1.Name = "labelNotificacao1";
            this.labelNotificacao1.Size = new System.Drawing.Size(96, 13);
            this.labelNotificacao1.TabIndex = 1;
            this.labelNotificacao1.Text = "dd/MM/yyyy";
            this.labelNotificacao1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNotificacao3
            // 
            this.buttonNotificacao3.Location = new System.Drawing.Point(210, 19);
            this.buttonNotificacao3.Name = "buttonNotificacao3";
            this.buttonNotificacao3.Size = new System.Drawing.Size(96, 57);
            this.buttonNotificacao3.TabIndex = 0;
            this.buttonNotificacao3.Text = "Notificação 3";
            this.buttonNotificacao3.UseVisualStyleBackColor = true;
            this.buttonNotificacao3.Click += new System.EventHandler(this.buttonNotificacao3_Click);
            // 
            // buttonNotificacao1
            // 
            this.buttonNotificacao1.Location = new System.Drawing.Point(6, 19);
            this.buttonNotificacao1.Name = "buttonNotificacao1";
            this.buttonNotificacao1.Size = new System.Drawing.Size(96, 57);
            this.buttonNotificacao1.TabIndex = 0;
            this.buttonNotificacao1.Text = "Notificação 1";
            this.buttonNotificacao1.UseVisualStyleBackColor = true;
            this.buttonNotificacao1.Click += new System.EventHandler(this.buttonNotificacao1_Click);
            // 
            // buttonNotificacao2
            // 
            this.buttonNotificacao2.Location = new System.Drawing.Point(108, 19);
            this.buttonNotificacao2.Name = "buttonNotificacao2";
            this.buttonNotificacao2.Size = new System.Drawing.Size(96, 57);
            this.buttonNotificacao2.TabIndex = 0;
            this.buttonNotificacao2.Text = "Notificação 2";
            this.buttonNotificacao2.UseVisualStyleBackColor = true;
            this.buttonNotificacao2.Click += new System.EventHandler(this.buttonNotificacao2_Click);
            // 
            // Notificacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 271);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxEmpresa);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Notificacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notificações";
            this.Load += new System.EventHandler(this.Notificacao_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonNotificacao3;
        private System.Windows.Forms.Button buttonNotificacao1;
        private System.Windows.Forms.Button buttonNotificacao2;
        private System.Windows.Forms.Label labelNotificacao3;
        private System.Windows.Forms.Label labelNotificacao2;
        private System.Windows.Forms.Label labelNotificacao1;
        private Library.Controls.LineHorizontalSeparator lineHorizontalSeparator1;
        private System.Windows.Forms.Button buttonReimprimir;
    }
}