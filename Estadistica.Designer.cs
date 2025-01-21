namespace System_Fitness
{
    partial class Estadistica
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.guna2ContainerControl4 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.cmbGrafico1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.chartUno = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblGrafico = new System.Windows.Forms.Label();
            this.guna2ContainerControl2 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.btnFiltrar = new Guna.UI2.WinForms.Guna2Button();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpFechaDesde = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblFiltroTiempo = new System.Windows.Forms.Label();
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.cmbGrafico2 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.chartDos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2ContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartUno)).BeginInit();
            this.guna2ContainerControl2.SuspendLayout();
            this.guna2ContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDos)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ContainerControl4
            // 
            this.guna2ContainerControl4.BorderRadius = 15;
            this.guna2ContainerControl4.Controls.Add(this.cmbGrafico1);
            this.guna2ContainerControl4.Controls.Add(this.chartUno);
            this.guna2ContainerControl4.Controls.Add(this.lblGrafico);
            this.guna2ContainerControl4.Location = new System.Drawing.Point(300, 19);
            this.guna2ContainerControl4.Name = "guna2ContainerControl4";
            this.guna2ContainerControl4.Size = new System.Drawing.Size(1331, 371);
            this.guna2ContainerControl4.TabIndex = 49;
            this.guna2ContainerControl4.Text = "guna2ContainerControl4";
            // 
            // cmbGrafico1
            // 
            this.cmbGrafico1.BackColor = System.Drawing.Color.Transparent;
            this.cmbGrafico1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGrafico1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrafico1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGrafico1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGrafico1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGrafico1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbGrafico1.ItemHeight = 30;
            this.cmbGrafico1.Location = new System.Drawing.Point(127, 11);
            this.cmbGrafico1.Name = "cmbGrafico1";
            this.cmbGrafico1.Size = new System.Drawing.Size(318, 36);
            this.cmbGrafico1.TabIndex = 49;
            // 
            // chartUno
            // 
            chartArea5.Name = "ChartArea1";
            this.chartUno.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartUno.Legends.Add(legend5);
            this.chartUno.Location = new System.Drawing.Point(25, 57);
            this.chartUno.Name = "chartUno";
            this.chartUno.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartUno.Series.Add(series5);
            this.chartUno.Size = new System.Drawing.Size(1287, 275);
            this.chartUno.TabIndex = 47;
            this.chartUno.Text = "chart1";
            this.chartUno.Click += new System.EventHandler(this.chartUno_Click);
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
            // guna2ContainerControl2
            // 
            this.guna2ContainerControl2.BorderRadius = 15;
            this.guna2ContainerControl2.Controls.Add(this.btnFiltrar);
            this.guna2ContainerControl2.Controls.Add(this.lblHasta);
            this.guna2ContainerControl2.Controls.Add(this.lblDesde);
            this.guna2ContainerControl2.Controls.Add(this.dtpFechaHasta);
            this.guna2ContainerControl2.Controls.Add(this.dtpFechaDesde);
            this.guna2ContainerControl2.Controls.Add(this.lblFiltroTiempo);
            this.guna2ContainerControl2.Location = new System.Drawing.Point(24, 19);
            this.guna2ContainerControl2.Name = "guna2ContainerControl2";
            this.guna2ContainerControl2.Size = new System.Drawing.Size(248, 371);
            this.guna2ContainerControl2.TabIndex = 50;
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
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
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
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
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
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.BorderRadius = 15;
            this.guna2ContainerControl1.Controls.Add(this.cmbGrafico2);
            this.guna2ContainerControl1.Controls.Add(this.chartDos);
            this.guna2ContainerControl1.Controls.Add(this.label3);
            this.guna2ContainerControl1.Location = new System.Drawing.Point(24, 415);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.Size = new System.Drawing.Size(1607, 441);
            this.guna2ContainerControl1.TabIndex = 52;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            // 
            // cmbGrafico2
            // 
            this.cmbGrafico2.BackColor = System.Drawing.Color.Transparent;
            this.cmbGrafico2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGrafico2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrafico2.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGrafico2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGrafico2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGrafico2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbGrafico2.ItemHeight = 30;
            this.cmbGrafico2.Location = new System.Drawing.Point(132, 15);
            this.cmbGrafico2.Name = "cmbGrafico2";
            this.cmbGrafico2.Size = new System.Drawing.Size(318, 36);
            this.cmbGrafico2.TabIndex = 48;
            // 
            // chartDos
            // 
            chartArea6.Name = "ChartArea1";
            this.chartDos.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartDos.Legends.Add(legend6);
            this.chartDos.Location = new System.Drawing.Point(25, 57);
            this.chartDos.Name = "chartDos";
            this.chartDos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartDos.Series.Add(series6);
            this.chartDos.Size = new System.Drawing.Size(1563, 359);
            this.chartDos.TabIndex = 47;
            this.chartDos.Text = "chart1";
            this.chartDos.Click += new System.EventHandler(this.chartDos_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 30);
            this.label3.TabIndex = 44;
            this.label3.Text = "Graficos";
            // 
            // Estadistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ContainerControl1);
            this.Controls.Add(this.guna2ContainerControl4);
            this.Controls.Add(this.guna2ContainerControl2);
            this.Name = "Estadistica";
            this.Size = new System.Drawing.Size(1662, 881);
            this.guna2ContainerControl4.ResumeLayout(false);
            this.guna2ContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartUno)).EndInit();
            this.guna2ContainerControl2.ResumeLayout(false);
            this.guna2ContainerControl2.PerformLayout();
            this.guna2ContainerControl1.ResumeLayout(false);
            this.guna2ContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUno;
        private System.Windows.Forms.Label lblGrafico;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl2;
        private Guna.UI2.WinForms.Guna2Button btnFiltrar;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaHasta;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFiltroTiempo;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDos;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cmbGrafico1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbGrafico2;
    }
}
