namespace System_Fitness
{
    partial class FinanzasUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.guna2ContainerControl3 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.dgvIngresos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblIngresos = new System.Windows.Forms.Label();
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.dgvEgresos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblEgresos = new System.Windows.Forms.Label();
            this.guna2ContainerControl2 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.btnFiltrar = new Guna.UI2.WinForms.Guna2Button();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpFechaDesde = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblFiltroTiempo = new System.Windows.Forms.Label();
            this.guna2ContainerControl4 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.chartFinanzas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rbBalance = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.rbIngresosyEgresos = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblIngresosYEgresos = new System.Windows.Forms.Label();
            this.lblGrafico = new System.Windows.Forms.Label();
            this.guna2ContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            this.guna2ContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).BeginInit();
            this.guna2ContainerControl2.SuspendLayout();
            this.guna2ContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFinanzas)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ContainerControl3
            // 
            this.guna2ContainerControl3.BorderRadius = 15;
            this.guna2ContainerControl3.Controls.Add(this.dgvIngresos);
            this.guna2ContainerControl3.Controls.Add(this.lblIngresos);
            this.guna2ContainerControl3.Location = new System.Drawing.Point(295, 20);
            this.guna2ContainerControl3.Name = "guna2ContainerControl3";
            this.guna2ContainerControl3.Size = new System.Drawing.Size(1343, 242);
            this.guna2ContainerControl3.TabIndex = 46;
            this.guna2ContainerControl3.Text = "guna2ContainerControl3";
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvIngresos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIngresos.ColumnHeadersHeight = 30;
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIngresos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIngresos.EnableHeadersVisualStyles = true;
            this.dgvIngresos.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvIngresos.Location = new System.Drawing.Point(25, 46);
            this.dgvIngresos.Margin = new System.Windows.Forms.Padding(5);
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngresos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIngresos.RowHeadersVisible = false;
            this.dgvIngresos.RowHeadersWidth = 40;
            this.dgvIngresos.Size = new System.Drawing.Size(1284, 166);
            this.dgvIngresos.TabIndex = 46;
            this.dgvIngresos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvIngresos.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvIngresos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvIngresos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvIngresos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvIngresos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvIngresos.ThemeStyle.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvIngresos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvIngresos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvIngresos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvIngresos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvIngresos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvIngresos.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvIngresos.ThemeStyle.ReadOnly = false;
            this.dgvIngresos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvIngresos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvIngresos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvIngresos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvIngresos.ThemeStyle.RowsStyle.Height = 22;
            this.dgvIngresos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvIngresos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lblIngresos
            // 
            this.lblIngresos.AutoSize = true;
            this.lblIngresos.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresos.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresos.Location = new System.Drawing.Point(20, 11);
            this.lblIngresos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblIngresos.Name = "lblIngresos";
            this.lblIngresos.Size = new System.Drawing.Size(91, 30);
            this.lblIngresos.TabIndex = 44;
            this.lblIngresos.Text = "Ingresos";
            // 
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.BorderRadius = 15;
            this.guna2ContainerControl1.Controls.Add(this.dgvEgresos);
            this.guna2ContainerControl1.Controls.Add(this.lblEgresos);
            this.guna2ContainerControl1.Location = new System.Drawing.Point(295, 281);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.Size = new System.Drawing.Size(1343, 253);
            this.guna2ContainerControl1.TabIndex = 47;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            // 
            // dgvEgresos
            // 
            this.dgvEgresos.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvEgresos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEgresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvEgresos.ColumnHeadersHeight = 30;
            this.dgvEgresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEgresos.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvEgresos.EnableHeadersVisualStyles = true;
            this.dgvEgresos.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvEgresos.Location = new System.Drawing.Point(25, 60);
            this.dgvEgresos.Margin = new System.Windows.Forms.Padding(5);
            this.dgvEgresos.Name = "dgvEgresos";
            this.dgvEgresos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEgresos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvEgresos.RowHeadersVisible = false;
            this.dgvEgresos.RowHeadersWidth = 40;
            this.dgvEgresos.Size = new System.Drawing.Size(1293, 172);
            this.dgvEgresos.TabIndex = 46;
            this.dgvEgresos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEgresos.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEgresos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvEgresos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEgresos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvEgresos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvEgresos.ThemeStyle.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvEgresos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvEgresos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvEgresos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEgresos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvEgresos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvEgresos.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvEgresos.ThemeStyle.ReadOnly = false;
            this.dgvEgresos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEgresos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEgresos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEgresos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvEgresos.ThemeStyle.RowsStyle.Height = 22;
            this.dgvEgresos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEgresos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lblEgresos
            // 
            this.lblEgresos.AutoSize = true;
            this.lblEgresos.BackColor = System.Drawing.Color.Transparent;
            this.lblEgresos.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEgresos.Location = new System.Drawing.Point(20, 11);
            this.lblEgresos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEgresos.Name = "lblEgresos";
            this.lblEgresos.Size = new System.Drawing.Size(84, 30);
            this.lblEgresos.TabIndex = 44;
            this.lblEgresos.Text = "Egresos";
            // 
            // guna2ContainerControl2
            // 
            this.guna2ContainerControl2.BorderRadius = 15;
            this.guna2ContainerControl2.Controls.Add(this.btnFiltrar);
            this.guna2ContainerControl2.Controls.Add(this.lblHasta);
            this.guna2ContainerControl2.Controls.Add(this.lblDesde);
            this.guna2ContainerControl2.Controls.Add(this.dtpFechaHasta);
            this.guna2ContainerControl2.Controls.Add(this.dtpFechaDesde);
            this.guna2ContainerControl2.Controls.Add(this.lblFiltroTiempo);
            this.guna2ContainerControl2.Location = new System.Drawing.Point(24, 20);
            this.guna2ContainerControl2.Name = "guna2ContainerControl2";
            this.guna2ContainerControl2.Size = new System.Drawing.Size(248, 514);
            this.guna2ContainerControl2.TabIndex = 48;
            this.guna2ContainerControl2.Text = "guna2ContainerControl2";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.Transparent;
            this.btnFiltrar.BorderRadius = 15;
            this.btnFiltrar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltrar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltrar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFiltrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFiltrar.FillColor = System.Drawing.Color.PowderBlue;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.Black;
            this.btnFiltrar.Location = new System.Drawing.Point(26, 272);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(5);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(201, 60);
            this.btnFiltrar.TabIndex = 52;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.BackColor = System.Drawing.Color.Transparent;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.Location = new System.Drawing.Point(30, 159);
            this.lblHasta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(47, 20);
            this.lblHasta.TabIndex = 51;
            this.lblHasta.Text = "Hasta";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.BackColor = System.Drawing.Color.Transparent;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.Location = new System.Drawing.Point(22, 57);
            this.lblDesde.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(51, 20);
            this.lblDesde.TabIndex = 50;
            this.lblDesde.Text = "Desde";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.BackColor = System.Drawing.Color.Transparent;
            this.dtpFechaHasta.BorderRadius = 15;
            this.dtpFechaHasta.Checked = true;
            this.dtpFechaHasta.FillColor = System.Drawing.Color.White;
            this.dtpFechaHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(26, 184);
            this.dtpFechaHasta.Margin = new System.Windows.Forms.Padding(5);
            this.dtpFechaHasta.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaHasta.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(201, 58);
            this.dtpFechaHasta.TabIndex = 49;
            this.dtpFechaHasta.Value = new System.DateTime(2024, 12, 31, 18, 53, 41, 904);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.BackColor = System.Drawing.Color.Transparent;
            this.dtpFechaDesde.BorderRadius = 15;
            this.dtpFechaDesde.Checked = true;
            this.dtpFechaDesde.FillColor = System.Drawing.Color.White;
            this.dtpFechaDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(25, 82);
            this.dtpFechaDesde.Margin = new System.Windows.Forms.Padding(5);
            this.dtpFechaDesde.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaDesde.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(202, 58);
            this.dtpFechaDesde.TabIndex = 48;
            this.dtpFechaDesde.Value = new System.DateTime(2024, 12, 31, 18, 53, 41, 904);
            // 
            // lblFiltroTiempo
            // 
            this.lblFiltroTiempo.AutoSize = true;
            this.lblFiltroTiempo.BackColor = System.Drawing.Color.Transparent;
            this.lblFiltroTiempo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroTiempo.Location = new System.Drawing.Point(88, 11);
            this.lblFiltroTiempo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFiltroTiempo.Name = "lblFiltroTiempo";
            this.lblFiltroTiempo.Size = new System.Drawing.Size(59, 30);
            this.lblFiltroTiempo.TabIndex = 47;
            this.lblFiltroTiempo.Text = "Filtro";
            // 
            // guna2ContainerControl4
            // 
            this.guna2ContainerControl4.BorderRadius = 15;
            this.guna2ContainerControl4.Controls.Add(this.chartFinanzas);
            this.guna2ContainerControl4.Controls.Add(this.rbBalance);
            this.guna2ContainerControl4.Controls.Add(this.rbIngresosyEgresos);
            this.guna2ContainerControl4.Controls.Add(this.lblBalance);
            this.guna2ContainerControl4.Controls.Add(this.lblIngresosYEgresos);
            this.guna2ContainerControl4.Controls.Add(this.lblGrafico);
            this.guna2ContainerControl4.Location = new System.Drawing.Point(24, 553);
            this.guna2ContainerControl4.Name = "guna2ContainerControl4";
            this.guna2ContainerControl4.Size = new System.Drawing.Size(1614, 310);
            this.guna2ContainerControl4.TabIndex = 48;
            this.guna2ContainerControl4.Text = "guna2ContainerControl4";
            // 
            // chartFinanzas
            // 
            chartArea1.Name = "ChartArea1";
            this.chartFinanzas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartFinanzas.Legends.Add(legend1);
            this.chartFinanzas.Location = new System.Drawing.Point(25, 60);
            this.chartFinanzas.Name = "chartFinanzas";
            this.chartFinanzas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartFinanzas.Series.Add(series1);
            this.chartFinanzas.Size = new System.Drawing.Size(1555, 226);
            this.chartFinanzas.TabIndex = 47;
            this.chartFinanzas.Text = "chart1";
            // 
            // rbBalance
            // 
            this.rbBalance.BackColor = System.Drawing.Color.Transparent;
            this.rbBalance.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbBalance.CheckedState.BorderThickness = 0;
            this.rbBalance.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbBalance.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbBalance.ForeColor = System.Drawing.Color.SteelBlue;
            this.rbBalance.Location = new System.Drawing.Point(553, 21);
            this.rbBalance.Name = "rbBalance";
            this.rbBalance.Size = new System.Drawing.Size(20, 20);
            this.rbBalance.TabIndex = 51;
            this.rbBalance.Text = "guna2CustomRadioButton2";
            this.rbBalance.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbBalance.UncheckedState.BorderThickness = 2;
            this.rbBalance.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbBalance.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbBalance.CheckedChanged += new System.EventHandler(this.rbBalance_CheckedChanged);
            // 
            // rbIngresosyEgresos
            // 
            this.rbIngresosyEgresos.BackColor = System.Drawing.Color.Transparent;
            this.rbIngresosyEgresos.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbIngresosyEgresos.CheckedState.BorderThickness = 0;
            this.rbIngresosyEgresos.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbIngresosyEgresos.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbIngresosyEgresos.ForeColor = System.Drawing.Color.SteelBlue;
            this.rbIngresosyEgresos.Location = new System.Drawing.Point(285, 21);
            this.rbIngresosyEgresos.Name = "rbIngresosyEgresos";
            this.rbIngresosyEgresos.Size = new System.Drawing.Size(20, 20);
            this.rbIngresosyEgresos.TabIndex = 50;
            this.rbIngresosyEgresos.Text = "guna2CustomRadioButton1";
            this.rbIngresosyEgresos.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbIngresosyEgresos.UncheckedState.BorderThickness = 2;
            this.rbIngresosyEgresos.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbIngresosyEgresos.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbIngresosyEgresos.CheckedChanged += new System.EventHandler(this.rbIngresosyEgresos_CheckedChanged);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(581, 11);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(85, 30);
            this.lblBalance.TabIndex = 49;
            this.lblBalance.Text = "Balance";
            // 
            // lblIngresosYEgresos
            // 
            this.lblIngresosYEgresos.AutoSize = true;
            this.lblIngresosYEgresos.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresosYEgresos.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresosYEgresos.Location = new System.Drawing.Point(313, 11);
            this.lblIngresosYEgresos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblIngresosYEgresos.Name = "lblIngresosYEgresos";
            this.lblIngresosYEgresos.Size = new System.Drawing.Size(184, 30);
            this.lblIngresosYEgresos.TabIndex = 48;
            this.lblIngresosYEgresos.Text = "Ingresos y Egresos";
            // 
            // lblGrafico
            // 
            this.lblGrafico.AutoSize = true;
            this.lblGrafico.BackColor = System.Drawing.Color.Transparent;
            this.lblGrafico.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrafico.Location = new System.Drawing.Point(20, 11);
            this.lblGrafico.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblGrafico.Name = "lblGrafico";
            this.lblGrafico.Size = new System.Drawing.Size(88, 30);
            this.lblGrafico.TabIndex = 44;
            this.lblGrafico.Text = "Graficos";
            // 
            // FinanzasUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.guna2ContainerControl4);
            this.Controls.Add(this.guna2ContainerControl2);
            this.Controls.Add(this.guna2ContainerControl1);
            this.Controls.Add(this.guna2ContainerControl3);
            this.Name = "FinanzasUserControl";
            this.Size = new System.Drawing.Size(1662, 881);
            this.guna2ContainerControl3.ResumeLayout(false);
            this.guna2ContainerControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            this.guna2ContainerControl1.ResumeLayout(false);
            this.guna2ContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).EndInit();
            this.guna2ContainerControl2.ResumeLayout(false);
            this.guna2ContainerControl2.PerformLayout();
            this.guna2ContainerControl4.ResumeLayout(false);
            this.guna2ContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFinanzas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl3;
        private Guna.UI2.WinForms.Guna2DataGridView dgvIngresos;
        private System.Windows.Forms.Label lblIngresos;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvEgresos;
        private System.Windows.Forms.Label lblEgresos;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl2;
        private System.Windows.Forms.Label lblFiltroTiempo;
        private System.Windows.Forms.Label lblDesde;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaHasta;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblHasta;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl4;
        private System.Windows.Forms.Label lblGrafico;
        private Guna.UI2.WinForms.Guna2CustomRadioButton rbBalance;
        private Guna.UI2.WinForms.Guna2CustomRadioButton rbIngresosyEgresos;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblIngresosYEgresos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFinanzas;
        private Guna.UI2.WinForms.Guna2Button btnFiltrar;
    }
}
