namespace Reports
{
    partial class RClienteStatus
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RClienteStatus));
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Reports.DataSet1();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxInicio = new System.Windows.Forms.TextBox();
            this.checkBoxTermino = new System.Windows.Forms.CheckBox();
            this.checkBoxInicio = new System.Windows.Forms.CheckBox();
            this.textBoxTermino = new System.Windows.Forms.TextBox();
            this.clienteTableAdapter = new Reports.DataSet1TableAdapters.ClienteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataMember = "Cliente";
            this.clienteBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(731, 510);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.clienteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Clientes (Status).rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(725, 504);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 1);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxInicio);
            this.groupBox1.Controls.Add(this.checkBoxTermino);
            this.groupBox1.Controls.Add(this.checkBoxInicio);
            this.groupBox1.Controls.Add(this.textBoxTermino);
            this.groupBox1.Location = new System.Drawing.Point(3, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 77);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Periodo";
            // 
            // textBoxInicio
            // 
            this.textBoxInicio.Enabled = false;
            this.textBoxInicio.Location = new System.Drawing.Point(7, 43);
            this.textBoxInicio.MaxLength = 10;
            this.textBoxInicio.Name = "textBoxInicio";
            this.textBoxInicio.Size = new System.Drawing.Size(75, 20);
            this.textBoxInicio.TabIndex = 1;
            // 
            // checkBoxTermino
            // 
            this.checkBoxTermino.AutoSize = true;
            this.checkBoxTermino.Location = new System.Drawing.Point(89, 23);
            this.checkBoxTermino.Name = "checkBoxTermino";
            this.checkBoxTermino.Size = new System.Drawing.Size(64, 17);
            this.checkBoxTermino.TabIndex = 5;
            this.checkBoxTermino.Text = "Término";
            this.checkBoxTermino.UseVisualStyleBackColor = true;
            this.checkBoxTermino.CheckedChanged += new System.EventHandler(this.checkBoxTermino_CheckedChanged);
            // 
            // checkBoxInicio
            // 
            this.checkBoxInicio.AutoSize = true;
            this.checkBoxInicio.Location = new System.Drawing.Point(8, 23);
            this.checkBoxInicio.Name = "checkBoxInicio";
            this.checkBoxInicio.Size = new System.Drawing.Size(51, 17);
            this.checkBoxInicio.TabIndex = 4;
            this.checkBoxInicio.Text = "Ínicio";
            this.checkBoxInicio.UseVisualStyleBackColor = true;
            this.checkBoxInicio.CheckedChanged += new System.EventHandler(this.checkBoxInicio_CheckedChanged);
            // 
            // textBoxTermino
            // 
            this.textBoxTermino.Enabled = false;
            this.textBoxTermino.Location = new System.Drawing.Point(88, 43);
            this.textBoxTermino.MaxLength = 10;
            this.textBoxTermino.Name = "textBoxTermino";
            this.textBoxTermino.Size = new System.Drawing.Size(75, 20);
            this.textBoxTermino.TabIndex = 3;
            // 
            // clienteTableAdapter
            // 
            this.clienteTableAdapter.ClearBeforeFill = true;
            // 
            // RClienteStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 510);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RClienteStatus";
            this.Text = "Clientes (Status)";
            this.Load += new System.EventHandler(this.Standard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxTermino;
        private System.Windows.Forms.TextBox textBoxInicio;
        private DataSet1 dataSet1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxTermino;
        private System.Windows.Forms.CheckBox checkBoxInicio;
        private System.Windows.Forms.BindingSource clienteBindingSource;
        private DataSet1TableAdapters.ClienteTableAdapter clienteTableAdapter;
    }
}