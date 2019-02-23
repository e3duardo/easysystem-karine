namespace Forms.Opcoes
{
    partial class Opcoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opcoes));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNotificacao1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNotificacao2 = new System.Windows.Forms.TextBox();
            this.textBoxNotificacao3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAplicar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Notificação 1";
            // 
            // textBoxNotificacao1
            // 
            this.textBoxNotificacao1.Location = new System.Drawing.Point(6, 38);
            this.textBoxNotificacao1.Name = "textBoxNotificacao1";
            this.textBoxNotificacao1.Size = new System.Drawing.Size(202, 20);
            this.textBoxNotificacao1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Notidicação 2";
            // 
            // textBoxNotificacao2
            // 
            this.textBoxNotificacao2.Location = new System.Drawing.Point(6, 82);
            this.textBoxNotificacao2.Name = "textBoxNotificacao2";
            this.textBoxNotificacao2.Size = new System.Drawing.Size(202, 20);
            this.textBoxNotificacao2.TabIndex = 3;
            // 
            // textBoxNotificacao3
            // 
            this.textBoxNotificacao3.Location = new System.Drawing.Point(6, 121);
            this.textBoxNotificacao3.Name = "textBoxNotificacao3";
            this.textBoxNotificacao3.Size = new System.Drawing.Size(202, 20);
            this.textBoxNotificacao3.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Notidicação 3";
            // 
            // buttonAplicar
            // 
            this.buttonAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAplicar.Location = new System.Drawing.Point(161, 173);
            this.buttonAplicar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAplicar.Name = "buttonAplicar";
            this.buttonAplicar.Size = new System.Drawing.Size(66, 23);
            this.buttonAplicar.TabIndex = 6;
            this.buttonAplicar.Text = "Aplicar";
            this.buttonAplicar.UseVisualStyleBackColor = true;
            this.buttonAplicar.Click += new System.EventHandler(this.buttonAplicar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxNotificacao1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxNotificacao3);
            this.groupBox1.Controls.Add(this.textBoxNotificacao2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 149);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prazo para comparecimento (em dias)";
            // 
            // Opcoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 207);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonAplicar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Opcoes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opções das Notificações";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Opcoes_FormClosing);
            this.Load += new System.EventHandler(this.Opcoes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNotificacao1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNotificacao2;
        private System.Windows.Forms.TextBox textBoxNotificacao3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAplicar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}