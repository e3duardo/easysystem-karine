namespace Forms.TermoCompromisso
{
    partial class NotificacaoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificacaoView));
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.lineHorizontalSeparator2 = new Library.Controls.LineHorizontalSeparator();
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
            this.comboBoxEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
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
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(12, 70);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(236, 21);
            this.comboBoxCliente.TabIndex = 3;
            this.comboBoxCliente.SelectedIndexChanged += new System.EventHandler(this.comboBoxCliente_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.lineHorizontalSeparator1);
            this.groupBox1.Controls.Add(this.buttonReimprimir);
            this.groupBox1.Controls.Add(this.labelNotificacao3);
            this.groupBox1.Controls.Add(this.labelNotificacao2);
            this.groupBox1.Controls.Add(this.labelNotificacao1);
            this.groupBox1.Controls.Add(this.buttonNotificacao3);
            this.groupBox1.Controls.Add(this.buttonNotificacao1);
            this.groupBox1.Controls.Add(this.buttonNotificacao2);
            this.groupBox1.Location = new System.Drawing.Point(12, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 138);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notificações";
            // 
            // lineHorizontalSeparator1
            // 
            this.lineHorizontalSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineHorizontalSeparator1.Location = new System.Drawing.Point(6, 102);
            this.lineHorizontalSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineHorizontalSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineHorizontalSeparator1.Name = "lineHorizontalSeparator1";
            this.lineHorizontalSeparator1.Size = new System.Drawing.Size(300, 2);
            this.lineHorizontalSeparator1.TabIndex = 3;
            // 
            // buttonReimprimir
            // 
            this.buttonReimprimir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.labelNotificacao3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNotificacao3.Location = new System.Drawing.Point(210, 79);
            this.labelNotificacao3.Name = "labelNotificacao3";
            this.labelNotificacao3.Size = new System.Drawing.Size(96, 13);
            this.labelNotificacao3.TabIndex = 1;
            this.labelNotificacao3.Text = "dd/MM/yyyy";
            this.labelNotificacao3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNotificacao2
            // 
            this.labelNotificacao2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNotificacao2.Location = new System.Drawing.Point(108, 79);
            this.labelNotificacao2.Name = "labelNotificacao2";
            this.labelNotificacao2.Size = new System.Drawing.Size(96, 13);
            this.labelNotificacao2.TabIndex = 1;
            this.labelNotificacao2.Text = "dd/MM/yyyy";
            this.labelNotificacao2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNotificacao1
            // 
            this.labelNotificacao1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelNotificacao1.Location = new System.Drawing.Point(6, 79);
            this.labelNotificacao1.Name = "labelNotificacao1";
            this.labelNotificacao1.Size = new System.Drawing.Size(96, 13);
            this.labelNotificacao1.TabIndex = 1;
            this.labelNotificacao1.Text = "dd/MM/yyyy";
            this.labelNotificacao1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNotificacao3
            // 
            this.buttonNotificacao3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.buttonNotificacao1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
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
            this.buttonNotificacao2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNotificacao2.Location = new System.Drawing.Point(108, 19);
            this.buttonNotificacao2.Name = "buttonNotificacao2";
            this.buttonNotificacao2.Size = new System.Drawing.Size(96, 57);
            this.buttonNotificacao2.TabIndex = 0;
            this.buttonNotificacao2.Text = "Notificação 2";
            this.buttonNotificacao2.UseVisualStyleBackColor = true;
            this.buttonNotificacao2.Click += new System.EventHandler(this.buttonNotificacao2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Status:";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(12, 128);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(153, 20);
            this.textBoxStatus.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Data do vinculo:";
            // 
            // textBoxData
            // 
            this.textBoxData.Location = new System.Drawing.Point(171, 128);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.ReadOnly = true;
            this.textBoxData.Size = new System.Drawing.Size(153, 20);
            this.textBoxData.TabIndex = 14;
            // 
            // lineHorizontalSeparator2
            // 
            this.lineHorizontalSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineHorizontalSeparator2.Location = new System.Drawing.Point(11, 97);
            this.lineHorizontalSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineHorizontalSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineHorizontalSeparator2.Name = "lineHorizontalSeparator2";
            this.lineHorizontalSeparator2.Size = new System.Drawing.Size(312, 2);
            this.lineHorizontalSeparator2.TabIndex = 10;
            // 
            // NotificacaoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 318);
            this.Controls.Add(this.textBoxData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lineHorizontalSeparator2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxEmpresa);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NotificacaoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notificações";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NotificacaoView_FormClosed);
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
        private Library.Controls.LineHorizontalSeparator lineHorizontalSeparator2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxData;
    }
}