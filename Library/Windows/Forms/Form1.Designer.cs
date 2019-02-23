using System.ComponentModel;
namespace Library.Windows.Forms
{
    partial class Form1
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



        [Category("Advanced")]
        [Description("Deixa a janela fixa.")]
        [DisplayName("Fixed")]
        public bool Fixed {get; set;}



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.PBTopLeft = new System.Windows.Forms.Panel();
            this.PBTopCenter = new System.Windows.Forms.Panel();
            this.PBTopRight = new System.Windows.Forms.Panel();
            this.PBMiddle1Left = new System.Windows.Forms.Panel();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PClose = new System.Windows.Forms.Panel();
            this.PMaximize = new System.Windows.Forms.Panel();
            this.PMinimize = new System.Windows.Forms.Panel();
            this.PBMiddle1Right = new System.Windows.Forms.Panel();
            this.PBMiddle2Left = new System.Windows.Forms.Panel();
            this.BodyPanel = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.PBMiddle2Right = new System.Windows.Forms.Panel();
            this.PBBottonLeft = new System.Windows.Forms.Panel();
            this.PBBottonCenter = new System.Windows.Forms.Panel();
            this.PBBottonRight = new System.Windows.Forms.Panel();
            this.MainPanel.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.BodyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Controls.Add(this.PBTopLeft);
            this.MainPanel.Controls.Add(this.PBTopCenter);
            this.MainPanel.Controls.Add(this.PBTopRight);
            this.MainPanel.Controls.Add(this.PBMiddle1Left);
            this.MainPanel.Controls.Add(this.HeaderPanel);
            this.MainPanel.Controls.Add(this.PBMiddle1Right);
            this.MainPanel.Controls.Add(this.PBMiddle2Left);
            this.MainPanel.Controls.Add(this.BodyPanel);
            this.MainPanel.Controls.Add(this.PBMiddle2Right);
            this.MainPanel.Controls.Add(this.PBBottonLeft);
            this.MainPanel.Controls.Add(this.PBBottonCenter);
            this.MainPanel.Controls.Add(this.PBBottonRight);
            this.MainPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(400, 400);
            this.MainPanel.TabIndex = 1;
            // 
            // PBTopLeft
            // 
            this.PBTopLeft.BackColor = System.Drawing.Color.Transparent;
            this.PBTopLeft.BackgroundImage = global::Resources.Properties.Resources.window_1Top1Left;
            this.PBTopLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PBTopLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.PBTopLeft.Location = new System.Drawing.Point(0, 0);
            this.PBTopLeft.Margin = new System.Windows.Forms.Padding(0);
            this.PBTopLeft.Name = "PBTopLeft";
            this.PBTopLeft.Size = new System.Drawing.Size(5, 5);
            this.PBTopLeft.TabIndex = 0;
            this.PBTopLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBTopLeft_MouseDown);
            this.PBTopLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBTopLeft_MouseMove);
            this.PBTopLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBTopLeft_MouseUp);
            // 
            // PBTopCenter
            // 
            this.PBTopCenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PBTopCenter.BackgroundImage = global::Resources.Properties.Resources.window_1Top2Center;
            this.PBTopCenter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBTopCenter.Cursor = System.Windows.Forms.Cursors.Default;
            this.PBTopCenter.Location = new System.Drawing.Point(5, 0);
            this.PBTopCenter.Margin = new System.Windows.Forms.Padding(0);
            this.PBTopCenter.Name = "PBTopCenter";
            this.PBTopCenter.Size = new System.Drawing.Size(390, 5);
            this.PBTopCenter.TabIndex = 0;
            this.PBTopCenter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBTopCenter_MouseDown);
            this.PBTopCenter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBTopCenter_MouseMove);
            this.PBTopCenter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBTopCenter_MouseUp);
            // 
            // PBTopRight
            // 
            this.PBTopRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PBTopRight.BackgroundImage = global::Resources.Properties.Resources.window_1Top3Right;
            this.PBTopRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PBTopRight.Cursor = System.Windows.Forms.Cursors.Default;
            this.PBTopRight.Location = new System.Drawing.Point(395, 0);
            this.PBTopRight.Margin = new System.Windows.Forms.Padding(0);
            this.PBTopRight.Name = "PBTopRight";
            this.PBTopRight.Size = new System.Drawing.Size(5, 5);
            this.PBTopRight.TabIndex = 0;
            this.PBTopRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBTopRight_MouseDown);
            this.PBTopRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBTopRight_MouseMove);
            this.PBTopRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBTopRight_MouseUp);
            // 
            // PBMiddle1Left
            // 
            this.PBMiddle1Left.BackgroundImage = global::Resources.Properties.Resources.window_2Middle1Left;
            this.PBMiddle1Left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PBMiddle1Left.Cursor = System.Windows.Forms.Cursors.Default;
            this.PBMiddle1Left.Location = new System.Drawing.Point(0, 5);
            this.PBMiddle1Left.Margin = new System.Windows.Forms.Padding(0);
            this.PBMiddle1Left.Name = "PBMiddle1Left";
            this.PBMiddle1Left.Size = new System.Drawing.Size(5, 32);
            this.PBMiddle1Left.TabIndex = 0;
            this.PBMiddle1Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBMiddleLeft_MouseDown);
            this.PBMiddle1Left.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBMiddleLeft_MouseMove);
            this.PBMiddle1Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBMiddleLeft_MouseUp);
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HeaderPanel.BackgroundImage = global::Resources.Properties.Resources.window_2Middle2Center;
            this.HeaderPanel.Controls.Add(this.pictureBox1);
            this.HeaderPanel.Controls.Add(this.label1);
            this.HeaderPanel.Controls.Add(this.PClose);
            this.HeaderPanel.Controls.Add(this.PMaximize);
            this.HeaderPanel.Controls.Add(this.PMinimize);
            this.HeaderPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.HeaderPanel.Location = new System.Drawing.Point(5, 5);
            this.HeaderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(390, 32);
            this.HeaderPanel.TabIndex = 0;
            this.HeaderPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseDown);
            this.HeaderPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseMove);
            this.HeaderPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "title";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseDown);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseDown);
            // 
            // PClose
            // 
            this.PClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PClose.BackgroundImage = global::Resources.Properties.Resources.window_close1;
            this.PClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.PClose.Location = new System.Drawing.Point(363, 7);
            this.PClose.Margin = new System.Windows.Forms.Padding(0);
            this.PClose.Name = "PClose";
            this.PClose.Size = new System.Drawing.Size(19, 15);
            this.PClose.TabIndex = 0;
            this.PClose.Click += new System.EventHandler(this.PClose_Click);
            this.PClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PClose_MouseDown);
            this.PClose.MouseLeave += new System.EventHandler(this.PClose_MouseLeave);
            this.PClose.MouseHover += new System.EventHandler(this.PClose_MouseHover);
            this.PClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PClose_MouseUp);
            // 
            // PMaximize
            // 
            this.PMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PMaximize.BackgroundImage = global::Resources.Properties.Resources.window_maximize1;
            this.PMaximize.Cursor = System.Windows.Forms.Cursors.Default;
            this.PMaximize.Location = new System.Drawing.Point(343, 7);
            this.PMaximize.Margin = new System.Windows.Forms.Padding(0);
            this.PMaximize.Name = "PMaximize";
            this.PMaximize.Size = new System.Drawing.Size(19, 15);
            this.PMaximize.TabIndex = 0;
            this.PMaximize.Click += new System.EventHandler(this.PMaximize_Click);
            this.PMaximize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PMaximize_MouseDown);
            this.PMaximize.MouseLeave += new System.EventHandler(this.PMaximize_MouseLeave);
            this.PMaximize.MouseHover += new System.EventHandler(this.PMaximize_MouseHover);
            this.PMaximize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PMaximize_MouseUp);
            // 
            // PMinimize
            // 
            this.PMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PMinimize.BackgroundImage = global::Resources.Properties.Resources.window_minimize1;
            this.PMinimize.Cursor = System.Windows.Forms.Cursors.Default;
            this.PMinimize.Location = new System.Drawing.Point(323, 7);
            this.PMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.PMinimize.Name = "PMinimize";
            this.PMinimize.Size = new System.Drawing.Size(19, 15);
            this.PMinimize.TabIndex = 0;
            this.PMinimize.Click += new System.EventHandler(this.PMinimize_Click);
            this.PMinimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PMinimize_MouseDown);
            this.PMinimize.MouseLeave += new System.EventHandler(this.PMinimize_MouseLeave);
            this.PMinimize.MouseHover += new System.EventHandler(this.PMinimize_MouseHover);
            this.PMinimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PMinimize_MouseUp);
            // 
            // PBMiddle1Right
            // 
            this.PBMiddle1Right.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PBMiddle1Right.BackgroundImage = global::Resources.Properties.Resources.window_2Middle3Right;
            this.PBMiddle1Right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PBMiddle1Right.Cursor = System.Windows.Forms.Cursors.Default;
            this.PBMiddle1Right.Location = new System.Drawing.Point(395, 5);
            this.PBMiddle1Right.Margin = new System.Windows.Forms.Padding(0);
            this.PBMiddle1Right.Name = "PBMiddle1Right";
            this.PBMiddle1Right.Size = new System.Drawing.Size(5, 32);
            this.PBMiddle1Right.TabIndex = 0;
            this.PBMiddle1Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBMiddleRight_MouseDown);
            this.PBMiddle1Right.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBMiddleRight_MouseMove);
            this.PBMiddle1Right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBMiddleRight_MouseUp);
            // 
            // PBMiddle2Left
            // 
            this.PBMiddle2Left.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.PBMiddle2Left.BackgroundImage = global::Resources.Properties.Resources.window_3Middle1Left;
            this.PBMiddle2Left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBMiddle2Left.Cursor = System.Windows.Forms.Cursors.Default;
            this.PBMiddle2Left.Location = new System.Drawing.Point(0, 37);
            this.PBMiddle2Left.Margin = new System.Windows.Forms.Padding(0);
            this.PBMiddle2Left.Name = "PBMiddle2Left";
            this.PBMiddle2Left.Size = new System.Drawing.Size(5, 358);
            this.PBMiddle2Left.TabIndex = 0;
            this.PBMiddle2Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBMiddleLeft_MouseDown);
            this.PBMiddle2Left.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBMiddleLeft_MouseMove);
            this.PBMiddle2Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBMiddleLeft_MouseUp);
            // 
            // BodyPanel
            // 
            this.BodyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BodyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.BodyPanel.Controls.Add(this.ContentPanel);
            this.BodyPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.BodyPanel.Location = new System.Drawing.Point(5, 37);
            this.BodyPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(390, 358);
            this.BodyPanel.TabIndex = 0;
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 0);
            this.ContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(390, 358);
            this.ContentPanel.TabIndex = 0;
            // 
            // PBMiddle2Right
            // 
            this.PBMiddle2Right.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PBMiddle2Right.BackgroundImage = global::Resources.Properties.Resources.window_3Middle3Right;
            this.PBMiddle2Right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBMiddle2Right.Cursor = System.Windows.Forms.Cursors.Default;
            this.PBMiddle2Right.Location = new System.Drawing.Point(395, 37);
            this.PBMiddle2Right.Margin = new System.Windows.Forms.Padding(0);
            this.PBMiddle2Right.Name = "PBMiddle2Right";
            this.PBMiddle2Right.Size = new System.Drawing.Size(5, 358);
            this.PBMiddle2Right.TabIndex = 0;
            this.PBMiddle2Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBMiddleRight_MouseDown);
            this.PBMiddle2Right.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBMiddleRight_MouseMove);
            this.PBMiddle2Right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBMiddleRight_MouseUp);
            // 
            // PBBottonLeft
            // 
            this.PBBottonLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PBBottonLeft.BackgroundImage = global::Resources.Properties.Resources.window_4Bottom1Left;
            this.PBBottonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PBBottonLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.PBBottonLeft.Location = new System.Drawing.Point(0, 395);
            this.PBBottonLeft.Margin = new System.Windows.Forms.Padding(0);
            this.PBBottonLeft.Name = "PBBottonLeft";
            this.PBBottonLeft.Size = new System.Drawing.Size(5, 5);
            this.PBBottonLeft.TabIndex = 0;
            this.PBBottonLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBBottonLeft_MouseDown);
            this.PBBottonLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBBottonLeft_MouseMove);
            this.PBBottonLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBBottonLeft_MouseUp);
            // 
            // PBBottonCenter
            // 
            this.PBBottonCenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PBBottonCenter.BackgroundImage = global::Resources.Properties.Resources.window_4Bottom2Center;
            this.PBBottonCenter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBBottonCenter.Cursor = System.Windows.Forms.Cursors.Default;
            this.PBBottonCenter.Location = new System.Drawing.Point(5, 395);
            this.PBBottonCenter.Margin = new System.Windows.Forms.Padding(0);
            this.PBBottonCenter.Name = "PBBottonCenter";
            this.PBBottonCenter.Size = new System.Drawing.Size(390, 5);
            this.PBBottonCenter.TabIndex = 0;
            this.PBBottonCenter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBBottonCenter_MouseDown);
            this.PBBottonCenter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBBottonCenter_MouseMove);
            this.PBBottonCenter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBBottonCenter_MouseUp);
            // 
            // PBBottonRight
            // 
            this.PBBottonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PBBottonRight.BackgroundImage = global::Resources.Properties.Resources.window_4Bottom3Right;
            this.PBBottonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PBBottonRight.Cursor = System.Windows.Forms.Cursors.Default;
            this.PBBottonRight.Location = new System.Drawing.Point(395, 395);
            this.PBBottonRight.Margin = new System.Windows.Forms.Padding(0);
            this.PBBottonRight.Name = "PBBottonRight";
            this.PBBottonRight.Size = new System.Drawing.Size(5, 5);
            this.PBBottonRight.TabIndex = 0;
            this.PBBottonRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBBottonRight_MouseDown);
            this.PBBottonRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBBottonRight_MouseMove);
            this.PBBottonRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBBottonRight_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "EasySystem :: Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.MainPanel.ResumeLayout(false);
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.BodyPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel PBTopRight;
        private System.Windows.Forms.Panel PBMiddle1Left;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PClose;
        private System.Windows.Forms.Panel PMaximize;
        private System.Windows.Forms.Panel PMinimize;
        private System.Windows.Forms.Panel PBMiddle1Right;
        private System.Windows.Forms.Panel PBMiddle2Left;
        private System.Windows.Forms.Panel PBMiddle2Right;
        private System.Windows.Forms.Panel PBBottonLeft;
        private System.Windows.Forms.Panel PBBottonCenter;
        private System.Windows.Forms.Panel PBBottonRight;
        private System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Panel PBTopLeft;
        private System.Windows.Forms.Panel PBTopCenter;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Panel BodyPanel;

    }
}