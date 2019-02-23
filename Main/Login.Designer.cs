namespace Main
{
    partial class Login
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">verdade se for necessário descartar os recursos gerenciados; caso contrário, falso.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte do Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label loginLabel;
            System.Windows.Forms.Label senhaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.senhaTB = new System.Windows.Forms.TextBox();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.logarButton = new System.Windows.Forms.Button();
            this.loginTB = new System.Windows.Forms.TextBox();
            loginLabel = new System.Windows.Forms.Label();
            senhaLabel = new System.Windows.Forms.Label();
            this.ContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(loginLabel);
            this.ContentPanel.Controls.Add(senhaLabel);
            this.ContentPanel.Controls.Add(this.loginTB);
            this.ContentPanel.Controls.Add(this.senhaTB);
            this.ContentPanel.Controls.Add(this.logarButton);
            this.ContentPanel.Controls.Add(this.cancelarButton);
            this.ContentPanel.MaximumSize = new System.Drawing.Size(292, 144);
            this.ContentPanel.MinimumSize = new System.Drawing.Size(292, 144);
            this.ContentPanel.Size = new System.Drawing.Size(292, 144);
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Location = new System.Drawing.Point(8, 7);
            loginLabel.Margin = new System.Windows.Forms.Padding(3);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new System.Drawing.Size(36, 13);
            loginLabel.TabIndex = 0;
            loginLabel.Text = "Login:";
            // 
            // senhaLabel
            // 
            senhaLabel.AutoSize = true;
            senhaLabel.Location = new System.Drawing.Point(8, 60);
            senhaLabel.Margin = new System.Windows.Forms.Padding(3);
            senhaLabel.Name = "senhaLabel";
            senhaLabel.Size = new System.Drawing.Size(41, 13);
            senhaLabel.TabIndex = 2;
            senhaLabel.Text = "Senha:";
            // 
            // senhaTB
            // 
            this.senhaTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.senhaTB.BackColor = System.Drawing.Color.Gainsboro;
            this.senhaTB.Location = new System.Drawing.Point(8, 80);
            this.senhaTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 10);
            this.senhaTB.Name = "senhaTB";
            this.senhaTB.Size = new System.Drawing.Size(276, 20);
            this.senhaTB.TabIndex = 3;
            this.senhaTB.UseSystemPasswordChar = true;
            this.senhaTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.Location = new System.Drawing.Point(227, 113);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(57, 23);
            this.cancelarButton.TabIndex = 5;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // logarButton
            // 
            this.logarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logarButton.Location = new System.Drawing.Point(164, 113);
            this.logarButton.Name = "logarButton";
            this.logarButton.Size = new System.Drawing.Size(57, 23);
            this.logarButton.TabIndex = 4;
            this.logarButton.Text = "Logar";
            this.logarButton.UseVisualStyleBackColor = true;
            this.logarButton.Click += new System.EventHandler(this.logarButton_Click);
            // 
            // loginTB
            // 
            this.loginTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loginTB.BackColor = System.Drawing.Color.Gainsboro;
            this.loginTB.Location = new System.Drawing.Point(8, 27);
            this.loginTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 10);
            this.loginTB.Name = "loginTB";
            this.loginTB.Size = new System.Drawing.Size(276, 20);
            this.loginTB.TabIndex = 1;
            this.loginTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(302, 186);
            this.Fixed = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login2_Load);
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox loginTB;
        private System.Windows.Forms.Button logarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.TextBox senhaTB;
    }
}
