namespace Library.Controls
{
    partial class headbutons1
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

        #region código gerado pelo Component Designer

        /// <summary> 
        /// Método necessário para o suporte do Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.excluirButton = new System.Windows.Forms.Button();
            this.salvarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.novoButton = new System.Windows.Forms.Button();
            this.editarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // excluirButton
            // 
            this.excluirButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.excluirButton.Image = global::Resources.Properties.Resources.button_excluir;
            this.excluirButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.excluirButton.Location = new System.Drawing.Point(256, 0);
            this.excluirButton.Margin = new System.Windows.Forms.Padding(0);
            this.excluirButton.Name = "excluirButton";
            this.excluirButton.Size = new System.Drawing.Size(60, 60);
            this.excluirButton.TabIndex = 4;
            this.excluirButton.Text = "Exc&luir";
            this.excluirButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.excluirButton.UseVisualStyleBackColor = true;
            // 
            // salvarButton
            // 
            this.salvarButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.salvarButton.Image = global::Resources.Properties.Resources.button_salvar;
            this.salvarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.salvarButton.Location = new System.Drawing.Point(128, 0);
            this.salvarButton.Margin = new System.Windows.Forms.Padding(0);
            this.salvarButton.Name = "salvarButton";
            this.salvarButton.Size = new System.Drawing.Size(60, 60);
            this.salvarButton.TabIndex = 2;
            this.salvarButton.Text = "&Salvar";
            this.salvarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.salvarButton.UseVisualStyleBackColor = true;
            // 
            // cancelarButton
            // 
            this.cancelarButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cancelarButton.Image = global::Resources.Properties.Resources.button_cancelar;
            this.cancelarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancelarButton.Location = new System.Drawing.Point(192, 0);
            this.cancelarButton.Margin = new System.Windows.Forms.Padding(0);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(60, 60);
            this.cancelarButton.TabIndex = 3;
            this.cancelarButton.Text = "&Cancelar";
            this.cancelarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cancelarButton.UseVisualStyleBackColor = true;
            // 
            // novoButton
            // 
            this.novoButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.novoButton.Image = global::Resources.Properties.Resources.button_novo;
            this.novoButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.novoButton.Location = new System.Drawing.Point(0, 0);
            this.novoButton.Margin = new System.Windows.Forms.Padding(0);
            this.novoButton.Name = "novoButton";
            this.novoButton.Size = new System.Drawing.Size(60, 60);
            this.novoButton.TabIndex = 0;
            this.novoButton.Text = "&Novo";
            this.novoButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.novoButton.UseVisualStyleBackColor = true;
            // 
            // editarButton
            // 
            this.editarButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.editarButton.Image = global::Resources.Properties.Resources.button_editar;
            this.editarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.editarButton.Location = new System.Drawing.Point(64, 0);
            this.editarButton.Margin = new System.Windows.Forms.Padding(0);
            this.editarButton.Name = "editarButton";
            this.editarButton.Size = new System.Drawing.Size(60, 60);
            this.editarButton.TabIndex = 1;
            this.editarButton.Text = "&Editar";
            this.editarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.editarButton.UseVisualStyleBackColor = true;
            // 
            // headbutons1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.novoButton);
            this.Controls.Add(this.editarButton);
            this.Controls.Add(this.excluirButton);
            this.Controls.Add(this.salvarButton);
            this.Controls.Add(this.cancelarButton);
            this.Name = "headbutons1";
            this.Size = new System.Drawing.Size(316, 60);
            this.Load += new System.EventHandler(this.headbutons1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button novoButton;
        public System.Windows.Forms.Button editarButton;
        public System.Windows.Forms.Button excluirButton;
        public System.Windows.Forms.Button salvarButton;
        public System.Windows.Forms.Button cancelarButton;

    }
}
