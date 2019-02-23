namespace Forms.Funcionario
{
    partial class MudarSenha
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MudarSenha));
            this.panel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.senhaNovaConfirmarTB = new System.Windows.Forms.TextBox();
            this.logarButton = new System.Windows.Forms.Button();
            this.senhaNovaTB = new System.Windows.Forms.TextBox();
            this.aplicarButton = new System.Windows.Forms.Button();
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginTB = new System.Windows.Forms.TextBox();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.senhaTB = new System.Windows.Forms.TextBox();
            this.mensagemL = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.senhaNovaConfirmarTB);
            this.panel.Controls.Add(this.logarButton);
            this.panel.Controls.Add(this.senhaNovaTB);
            this.panel.Controls.Add(this.aplicarButton);
            this.panel.Controls.Add(this.loginLabel);
            this.panel.Controls.Add(this.loginTB);
            this.panel.Controls.Add(this.cancelarButton);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.senhaTB);
            this.panel.Controls.Add(this.mensagemL);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(352, 344);
            this.panel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 224);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nova senha:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Confirmar:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "2º passo: informe sua nova senha.";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "1º passo: informe seus dados de login antigo.";
            // 
            // senhaNovaConfirmarTB
            // 
            this.senhaNovaConfirmarTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.senhaNovaConfirmarTB.Location = new System.Drawing.Point(28, 281);
            this.senhaNovaConfirmarTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.senhaNovaConfirmarTB.Name = "senhaNovaConfirmarTB";
            this.senhaNovaConfirmarTB.Size = new System.Drawing.Size(296, 20);
            this.senhaNovaConfirmarTB.TabIndex = 11;
            this.senhaNovaConfirmarTB.UseSystemPasswordChar = true;
            // 
            // logarButton
            // 
            this.logarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logarButton.Location = new System.Drawing.Point(258, 115);
            this.logarButton.Name = "logarButton";
            this.logarButton.Size = new System.Drawing.Size(66, 23);
            this.logarButton.TabIndex = 5;
            this.logarButton.Text = "OK";
            this.logarButton.UseVisualStyleBackColor = true;
            this.logarButton.Click += new System.EventHandler(this.logarButton_Click);
            // 
            // senhaNovaTB
            // 
            this.senhaNovaTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.senhaNovaTB.Location = new System.Drawing.Point(28, 240);
            this.senhaNovaTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.senhaNovaTB.Name = "senhaNovaTB";
            this.senhaNovaTB.Size = new System.Drawing.Size(296, 20);
            this.senhaNovaTB.TabIndex = 9;
            this.senhaNovaTB.UseSystemPasswordChar = true;
            // 
            // aplicarButton
            // 
            this.aplicarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aplicarButton.Location = new System.Drawing.Point(186, 309);
            this.aplicarButton.Name = "aplicarButton";
            this.aplicarButton.Size = new System.Drawing.Size(66, 23);
            this.aplicarButton.TabIndex = 12;
            this.aplicarButton.Text = "Aplicar";
            this.aplicarButton.UseVisualStyleBackColor = true;
            this.aplicarButton.Click += new System.EventHandler(this.aplicarButton_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(28, 34);
            this.loginLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(36, 13);
            this.loginLabel.TabIndex = 1;
            this.loginLabel.Text = "Login:";
            // 
            // loginTB
            // 
            this.loginTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loginTB.Location = new System.Drawing.Point(28, 50);
            this.loginTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.loginTB.Name = "loginTB";
            this.loginTB.Size = new System.Drawing.Size(296, 20);
            this.loginTB.TabIndex = 2;
            // 
            // cancelarButton
            // 
            this.cancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.Location = new System.Drawing.Point(258, 309);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(66, 23);
            this.cancelarButton.TabIndex = 13;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Senha antiga:";
            // 
            // senhaTB
            // 
            this.senhaTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.senhaTB.Location = new System.Drawing.Point(28, 91);
            this.senhaTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.senhaTB.Name = "senhaTB";
            this.senhaTB.Size = new System.Drawing.Size(296, 20);
            this.senhaTB.TabIndex = 4;
            this.senhaTB.UseSystemPasswordChar = true;
            // 
            // mensagemL
            // 
            this.mensagemL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mensagemL.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensagemL.Location = new System.Drawing.Point(28, 146);
            this.mensagemL.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.mensagemL.Name = "mensagemL";
            this.mensagemL.Size = new System.Drawing.Size(296, 48);
            this.mensagemL.TabIndex = 6;
            this.mensagemL.Text = "Mensagem";
            this.mensagemL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // MudarSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 344);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MudarSenha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mudar senha";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MudarSenha_FormClosed);
            this.Load += new System.EventHandler(this.MudarSenha_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button aplicarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox senhaNovaConfirmarTB;
        private System.Windows.Forms.TextBox senhaNovaTB;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox loginTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox senhaTB;
        private System.Windows.Forms.Label mensagemL;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button logarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;

    }
}