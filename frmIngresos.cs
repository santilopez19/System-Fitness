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
        private dbQuery db = new dbQuery();

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
            dbQuery db = new dbQuery();
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
                    
                // Instancia de la clase dbQuery
                

                // Obtener el ClienteID y el nombre del cliente por su DNI
                string consultaCliente = "SELECT ClienteID, Nombre FROM Clientes WHERE DNI = @Dni";
                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter("@Dni", dni)
                };

                DataTable clienteInfo = db.ExecuteQuery(consultaCliente, parametros);

                if (clienteInfo.Rows.Count > 0) // Si el cliente existe
                {
                    int clienteId = Convert.ToInt32(clienteInfo.Rows[0]["ClienteID"]);
                    string nombreCliente = clienteInfo.Rows[0]["Nombre"].ToString();

                    // Consulta para verificar pagos recientes
                    string consultaPagosRecientes = @"
                SELECT COUNT(*) 
                FROM Pagos 
                WHERE ClienteID = @ClienteID 
                AND FechaPago >= DATEADD(DAY, -30, GETDATE());";

                    SqlParameter[] parametrosPagos = new SqlParameter[]
                    {
                new SqlParameter("@ClienteID", clienteId)
                    };

                    int pagosRecientes = Convert.ToInt32(db.ExecuteScalar(consultaPagosRecientes, parametrosPagos));

                    if (pagosRecientes > 0)
                    {
                        // Registrar la visita
                        int resultado = db.RegistrarVisita(clienteId);

                        lblNombreCliente.Text = $"Bienvenido, {nombreCliente}.";
                        
                    }
                    else
                    {
                        lblNombreCliente.Text = $"Lo sentimos, {nombreCliente}.";
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
