namespace System_Fitness
{
    partial class Calendario
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
            this.txtCupo = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.btnModificar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCrear = new Guna.UI2.WinForms.Guna2Button();
            this.cmbClase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpFechaClase = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblCupo = new System.Windows.Forms.Label();
            this.dgvClases = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cmbHorario = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTipoClase = new System.Windows.Forms.Label();
            this.lblHorario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCupo
            // 
            this.txtCupo.BackColor = System.Drawing.Color.Transparent;
            this.txtCupo.BorderRadius = 15;
            this.txtCupo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCupo.DefaultText = "";
            this.txtCupo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCupo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCupo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCupo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCupo.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtCupo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCupo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCupo.ForeColor = System.Drawing.Color.Black;
            this.txtCupo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCupo.Location = new System.Drawing.Point(201, 92);
            this.txtCupo.Margin = new System.Windows.Forms.Padding(5);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.PasswordChar = '\0';
            this.txtCupo.PlaceholderText = "";
            this.txtCupo.SelectedText = "";
            this.txtCupo.Size = new System.Drawing.Size(157, 56);
            this.txtCupo.TabIndex = 27;
            this.txtCupo.TextChanged += new System.EventHandler(this.txtCupo_TextChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.BorderRadius = 15;
            this.btnEliminar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEliminar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEliminar.FillColor = System.Drawing.Color.DarkSalmon;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Location = new System.Drawing.Point(1224, 72);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(169, 60);
            this.btnEliminar.TabIndex = 30;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Transparent;
            this.btnModificar.BorderRadius = 15;
            this.btnModificar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnModificar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnModificar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnModificar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnModificar.FillColor = System.Drawing.Color.Khaki;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.Black;
            this.btnModificar.Location = new System.Drawing.Point(1034, 72);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(169, 60);
            this.btnModificar.TabIndex = 29;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.Transparent;
            this.btnCrear.BorderRadius = 15;
            this.btnCrear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCrear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCrear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCrear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCrear.FillColor = System.Drawing.Color.LightGreen;
            this.btnCrear.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.ForeColor = System.Drawing.Color.Black;
            this.btnCrear.Location = new System.Drawing.Point(846, 72);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(5);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(169, 60);
            this.btnCrear.TabIndex = 28;
            this.btnCrear.Text = "Crear";
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // cmbClase
            // 
            this.cmbClase.BackColor = System.Drawing.Color.Transparent;
            this.cmbClase.BorderRadius = 15;
            this.cmbClase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClase.FillColor = System.Drawing.Color.WhiteSmoke;
            this.cmbClase.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbClase.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbClase.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClase.ForeColor = System.Drawing.Color.Black;
            this.cmbClase.ItemHeight = 30;
            this.cmbClase.Location = new System.Drawing.Point(546, 102);
            this.cmbClase.Margin = new System.Windows.Forms.Padding(5);
            this.cmbClase.Name = "cmbClase";
            this.cmbClase.Size = new System.Drawing.Size(201, 36);
            this.cmbClase.TabIndex = 33;
            this.cmbClase.SelectedIndexChanged += new System.EventHandler(this.cmbClase_SelectedIndexChanged);
            // 
            // dtpFechaClase
            // 
            this.dtpFechaClase.BackColor = System.Drawing.Color.Transparent;
            this.dtpFechaClase.BorderRadius = 15;
            this.dtpFechaClase.Checked = true;
            this.dtpFechaClase.FillColor = System.Drawing.Color.WhiteSmoke;
            this.dtpFechaClase.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaClase.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaClase.Location = new System.Drawing.Point(201, 24);
            this.dtpFechaClase.Margin = new System.Windows.Forms.Padding(5);
            this.dtpFechaClase.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaClase.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaClase.Name = "dtpFechaClase";
            this.dtpFechaClase.Size = new System.Drawing.Size(157, 58);
            this.dtpFechaClase.TabIndex = 32;
            this.dtpFechaClase.Value = new System.DateTime(2024, 12, 31, 18, 53, 41, 904);
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.BackColor = System.Drawing.Color.Transparent;
            this.lblCupo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCupo.Location = new System.Drawing.Point(95, 102);
            this.lblCupo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(62, 30);
            this.lblCupo.TabIndex = 35;
            this.lblCupo.Text = "Cupo";
            // 
            // dgvClases
            // 
            this.dgvClases.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvClases.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClases.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClases.ColumnHeadersHeight = 30;
            this.dgvClases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClases.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvClases.EnableHeadersVisualStyles = true;
            this.dgvClases.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvClases.Location = new System.Drawing.Point(36, 219);
            this.dgvClases.Margin = new System.Windows.Forms.Padding(5);
            this.dgvClases.Name = "dgvClases";
            this.dgvClases.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClases.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvClases.RowHeadersVisible = false;
            this.dgvClases.RowHeadersWidth = 40;
            this.dgvClases.Size = new System.Drawing.Size(1588, 611);
            this.dgvClases.TabIndex = 34;
            this.dgvClases.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvClases.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvClases.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvClases.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvClases.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvClases.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvClases.ThemeStyle.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvClases.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvClases.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvClases.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvClases.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvClases.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvClases.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvClases.ThemeStyle.ReadOnly = false;
            this.dgvClases.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvClases.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvClases.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvClases.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvClases.ThemeStyle.RowsStyle.Height = 22;
            this.dgvClases.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvClases.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvClases.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClasess_CellClick);
            this.dgvClases.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClasess_CellClick);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(95, 42);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(67, 30);
            this.lblFecha.TabIndex = 36;
            this.lblFecha.Text = "Fecha";
            // 
            // cmbHorario
            // 
            this.cmbHorario.BackColor = System.Drawing.Color.Transparent;
            this.cmbHorario.BorderRadius = 15;
            this.cmbHorario.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbHorario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHorario.FillColor = System.Drawing.Color.WhiteSmoke;
            this.cmbHorario.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbHorario.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbHorario.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHorario.ForeColor = System.Drawing.Color.Black;
            this.cmbHorario.ItemHeight = 30;
            this.cmbHorario.Location = new System.Drawing.Point(546, 42);
            this.cmbHorario.Margin = new System.Windows.Forms.Padding(5);
            this.cmbHorario.Name = "cmbHorario";
            this.cmbHorario.Size = new System.Drawing.Size(201, 36);
            this.cmbHorario.TabIndex = 37;
            this.cmbHorario.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // lblTipoClase
            // 
            this.lblTipoClase.AutoSize = true;
            this.lblTipoClase.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoClase.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoClase.Location = new System.Drawing.Point(402, 102);
            this.lblTipoClase.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTipoClase.Name = "lblTipoClase";
            this.lblTipoClase.Size = new System.Drawing.Size(134, 30);
            this.lblTipoClase.TabIndex = 39;
            this.lblTipoClase.Text = "Tipo de clase";
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.BackColor = System.Drawing.Color.Transparent;
            this.lblHorario.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorario.Location = new System.Drawing.Point(466, 42);
            this.lblHorario.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(82, 30);
            this.lblHorario.TabIndex = 38;
            this.lblHorario.Text = "Horario";
            // 
            // Calendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTipoClase);
            this.Controls.Add(this.lblHorario);
            this.Controls.Add(this.cmbHorario);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblCupo);
            this.Controls.Add(this.dgvClases);
            this.Controls.Add(this.cmbClase);
            this.Controls.Add(this.dtpFechaClase);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.txtCupo);
            this.Name = "Calendario";
            this.Size = new System.Drawing.Size(1662, 881);
            this.Load += new System.EventHandler(this.Calendario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtCupo;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private Guna.UI2.WinForms.Guna2Button btnModificar;
        private Guna.UI2.WinForms.Guna2Button btnCrear;
        private Guna.UI2.WinForms.Guna2ComboBox cmbClase;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaClase;
        private System.Windows.Forms.Label lblCupo;
        private Guna.UI2.WinForms.Guna2DataGridView dgvClases;
        private System.Windows.Forms.Label lblFecha;
        private Guna.UI2.WinForms.Guna2ComboBox cmbHorario;
        private System.Windows.Forms.Label lblTipoClase;
        private System.Windows.Forms.Label lblHorario;
    }
}
