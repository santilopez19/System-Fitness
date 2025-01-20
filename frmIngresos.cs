using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Fitness
{
    public partial class frmIngresos : Form
    {
        public frmIngresos()
        {
            InitializeComponent();
            txtDNIingreso.Focus();
            this.AcceptButton = btnIngresar;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                control.Anchor = AnchorStyles.None; // Sin anclaje para que no se fije a los bordes
                if (control is Label label)
                {
                    label.TextAlign = ContentAlignment.MiddleCenter; // Centramos texto de etiquetas
                }
                if (control is Button button)
                {
                    button.TextAlign = ContentAlignment.MiddleCenter; // Centramos texto de botones
                }
                // Márgenes opcionales
                control.Margin = new Padding(10); // Ajusta según lo necesites
            }

        }
        private void txtCupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla Backspace
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la tecla
            }
        }


        private void txtCupo_TextChanged(object sender, EventArgs e)
        {
            txtDNIingreso.Focus();
        }
        private void StartTimerToClearLabel()
        {
            if (timer == null)
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 5000; // 5 segundos
                timer.Tick += (s, e) =>
                {
                    lblNombreCliente.Text = string.Empty;
                    timer.Stop();
                };
            }
            timer.Start();
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {

            txtDNIingreso.Focus(); // Mantiene el foco en el campo del DNI

            try
            {
                // Validación del campo de texto
                if (string.IsNullOrWhiteSpace(txtDNIingreso.Text) || !int.TryParse(txtDNIingreso.Text, out int dni))
                {
                    lblNombreCliente.Text = "Ingrese un DNI válido.";
                    StartTimerToClearLabel();
                    return;
                }

                // Obtener el nombre del cliente mediante el DNI ingresado
                dbQuery db = new dbQuery();
                string nombreCliente = db.ObtenerNombreClientePorDni(txtDNIingreso.Text);

                if (nombreCliente != null)
                {
                    // Consulta para verificar si el cliente tiene pagos recientes
                    string consultaPagosRecientes = @"
            SELECT COUNT(*) 
            FROM dbo.Pagos p 
            WHERE p.ClienteID = (SELECT ClienteID FROM dbo.Clientes WHERE DNI = @Dni)
            AND p.FechaPago >= DATEADD(DAY, -30, GETDATE());";  // Verifica si ha pagado en los últimos 30 días

                    SqlParameter[] parametros = new SqlParameter[]
                    {
                new SqlParameter("@Dni", dni)
                    };

                    int pagosRecientes = Convert.ToInt32(db.ExecuteScalar(consultaPagosRecientes, parametros));

                    if (pagosRecientes > 0)
                    {
                        lblNombreCliente.Text = $"Bienvenido, {nombreCliente}. Puede ingresar.";
                    }
                    else
                    {
                        lblNombreCliente.Text = $"Lo sentimos, {nombreCliente}. No puede ingresar: no ha pagado.";
                    }
                }
                else
                {
                    lblNombreCliente.Text = "DNI no registrado en el sistema.";
                }

                StartTimerToClearLabel(); // Limpia el mensaje después de un tiempo
            }
            catch (Exception ex)
            {
                lblNombreCliente.Text = $"Error: {ex.Message}";
                StartTimerToClearLabel();
            }

        }

        private void lblTipoClase_Click(object sender, EventArgs e)
        {

        }
    }
}
