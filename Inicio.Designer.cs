namespace System_Fitness
{
    partial class Inicio
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
            this.btnCargarGasto = new Guna.UI2.WinForms.Guna2Button();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.cmbCategoriaGasto = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radiobuttonEfectivo = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.radiobuttonTransferencia = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.txtObservacion = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.guna2ContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCargarGasto
            // 
            this.btnCargarGasto.BackColor = System.Drawing.Color.Transparent;
            this.btnCargarGasto.BorderRadius = 15;
            this.btnCargarGasto.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCargarGasto.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCargarGasto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCargarGasto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCargarGasto.FillColor = System.Drawing.Color.LightCyan;
            this.btnCargarGasto.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarGasto.ForeColor = System.Drawing.Color.Black;
            this.btnCargarGasto.Location = new System.Drawing.Point(1190, 55);
            this.btnCargarGasto.Margin = new System.Windows.Forms.Padding(5);
            this.btnCargarGasto.Name = "btnCargarGasto";
            this.btnCargarGasto.Size = new System.Drawing.Size(218, 74);
            this.btnCargarGasto.TabIndex = 34;
            this.btnCargarGasto.Text = "Cargar Gasto";
            this.btnCargarGasto.Click += new System.EventHandler(this.btnCargarGasto_Click);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.BackColor = System.Drawing.Color.Transparent;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.Location = new System.Drawing.Point(96, 41);
            this.lblMonto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(75, 30);
            this.lblMonto.TabIndex = 33;
            this.lblMonto.Text = "Monto";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.Transparent;
            this.txtMonto.BorderRadius = 15;
            this.txtMonto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMonto.DefaultText = "";
            this.txtMonto.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMonto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMonto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMonto.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMonto.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtMonto.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.ForeColor = System.Drawing.Color.Black;
            this.txtMonto.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMonto.Location = new System.Drawing.Point(194, 29);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(5);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.PasswordChar = '\0';
            this.txtMonto.PlaceholderText = "";
            this.txtMonto.SelectedText = "";
            this.txtMonto.Size = new System.Drawing.Size(300, 56);
            this.txtMonto.TabIndex = 28;
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            // 
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.BorderRadius = 15;
            this.guna2ContainerControl1.Controls.Add(this.lblObservacion);
            this.guna2ContainerControl1.Controls.Add(this.txtObservacion);
            this.guna2ContainerControl1.Controls.Add(this.radiobuttonTransferencia);
            this.guna2ContainerControl1.Controls.Add(this.radiobuttonEfectivo);
            this.guna2ContainerControl1.Controls.Add(this.label3);
            this.guna2ContainerControl1.Controls.Add(this.label2);
            this.guna2ContainerControl1.Controls.Add(this.label1);
            this.guna2ContainerControl1.Controls.Add(this.cmbCategoriaGasto);
            this.guna2ContainerControl1.Controls.Add(this.txtMonto);
            this.guna2ContainerControl1.Controls.Add(this.btnCargarGasto);
            this.guna2ContainerControl1.Controls.Add(this.lblMonto);
            this.guna2ContainerControl1.Location = new System.Drawing.Point(53, 624);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.Size = new System.Drawing.Size(1489, 189);
            this.guna2ContainerControl1.TabIndex = 35;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            // 
            // cmbCategoriaGasto
            // 
            this.cmbCategoriaGasto.BackColor = System.Drawing.Color.Transparent;
            this.cmbCategoriaGasto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCategoriaGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaGasto.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCategoriaGasto.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCategoriaGasto.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoriaGasto.ForeColor = System.Drawing.Color.Black;
            this.cmbCategoriaGasto.ItemHeight = 30;
            this.cmbCategoriaGasto.Location = new System.Drawing.Point(879, 29);
            this.cmbCategoriaGasto.Name = "cmbCategoriaGasto";
            this.cmbCategoriaGasto.Size = new System.Drawing.Size(224, 36);
            this.cmbCategoriaGasto.TabIndex = 35;
            this.cmbCategoriaGasto.SelectedIndexChanged += new System.EventHandler(this.cmbCategoriaGasto_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(802, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 30);
            this.label1.TabIndex = 36;
            this.label1.Text = "Efectivo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(769, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 30);
            this.label2.TabIndex = 37;
            this.label2.Text = "Categoria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(802, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 30);
            this.label3.TabIndex = 38;
            this.label3.Text = "Transferencia";
            // 
            // radiobuttonEfectivo
            // 
            this.radiobuttonEfectivo.BackColor = System.Drawing.Color.Transparent;
            this.radiobuttonEfectivo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radiobuttonEfectivo.CheckedState.BorderThickness = 0;
            this.radiobuttonEfectivo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radiobuttonEfectivo.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radiobuttonEfectivo.ForeColor = System.Drawing.Color.SteelBlue;
            this.radiobuttonEfectivo.Location = new System.Drawing.Point(774, 143);
            this.radiobuttonEfectivo.Name = "radiobuttonEfectivo";
            this.radiobuttonEfectivo.Size = new System.Drawing.Size(20, 20);
            this.radiobuttonEfectivo.TabIndex = 39;
            this.radiobuttonEfectivo.Text = "guna2CustomRadioButton1";
            this.radiobuttonEfectivo.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radiobuttonEfectivo.UncheckedState.BorderThickness = 2;
            this.radiobuttonEfectivo.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radiobuttonEfectivo.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.radiobuttonEfectivo.CheckedChanged += new System.EventHandler(this.radiobuttonEfectivo_CheckedChanged);
            // 
            // radiobuttonTransferencia
            // 
            this.radiobuttonTransferencia.BackColor = System.Drawing.Color.Transparent;
            this.radiobuttonTransferencia.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radiobuttonTransferencia.CheckedState.BorderThickness = 0;
            this.radiobuttonTransferencia.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radiobuttonTransferencia.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radiobuttonTransferencia.ForeColor = System.Drawing.Color.SteelBlue;
            this.radiobuttonTransferencia.Location = new System.Drawing.Point(774, 96);
            this.radiobuttonTransferencia.Name = "radiobuttonTransferencia";
            this.radiobuttonTransferencia.Size = new System.Drawing.Size(20, 20);
            this.radiobuttonTransferencia.TabIndex = 40;
            this.radiobuttonTransferencia.Text = "guna2CustomRadioButton2";
            this.radiobuttonTransferencia.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radiobuttonTransferencia.UncheckedState.BorderThickness = 2;
            this.radiobuttonTransferencia.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radiobuttonTransferencia.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.radiobuttonTransferencia.CheckedChanged += new System.EventHandler(this.guna2CustomRadioButton2_CheckedChanged);
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.Color.Transparent;
            this.txtObservacion.BorderRadius = 15;
            this.txtObservacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObservacion.DefaultText = " \r\n\r\n";
            this.txtObservacion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtObservacion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtObservacion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservacion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservacion.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtObservacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservacion.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.txtObservacion.ForeColor = System.Drawing.Color.Black;
            this.txtObservacion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservacion.Location = new System.Drawing.Point(194, 113);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(5);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.PasswordChar = '\0';
            this.txtObservacion.PlaceholderText = "";
            this.txtObservacion.SelectedText = "";
            this.txtObservacion.Size = new System.Drawing.Size(416, 56);
            this.txtObservacion.TabIndex = 41;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.BackColor = System.Drawing.Color.Transparent;
            this.lblObservacion.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacion.Location = new System.Drawing.Point(56, 123);
            this.lblObservacion.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(128, 30);
            this.lblObservacion.TabIndex = 42;
            this.lblObservacion.Text = "Observacion";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ContainerControl1);
            this.Name = "Inicio";
            this.Size = new System.Drawing.Size(1662, 881);
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.guna2ContainerControl1.ResumeLayout(false);
            this.guna2ContainerControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnCargarGasto;
        private System.Windows.Forms.Label lblMonto;
        private Guna.UI2.WinForms.Guna2TextBox txtMonto;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategoriaGasto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CustomRadioButton radiobuttonTransferencia;
        private Guna.UI2.WinForms.Guna2CustomRadioButton radiobuttonEfectivo;
        private Guna.UI2.WinForms.Guna2TextBox txtObservacion;
        private System.Windows.Forms.Label lblObservacion;
    }
}
