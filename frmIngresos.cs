using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace System_Fitness
{
    public partial class frmIngresos : Form
    {
        private Random random = new Random();
        public frmIngresos()
        {
            InitializeComponent();
            txtDNIingreso.Focus();
            this.AcceptButton = btnIngresar;
            CargarConfiguracionIngreso();
        }
        private void CargarConfiguracionIngreso()
        {
            DataTable dt = db.ObtenerConfiguracion(); // Asumiendo que tienes un método para obtener la configuración

            if (dt.Rows.Count > 0)
            {
                string colorFondoIngreso = dt.Rows[0]["ColorFondoIngreso"].ToString();
                tableLayoutPanel1.BackColor = ColorTranslator.FromHtml(colorFondoIngreso); 
                string colorBordeCartelIngreso = dt.Rows[0]["ColorBordeCartelIngreso"].ToString();
                lblAviso.ForeColor = ColorTranslator.FromHtml(colorBordeCartelIngreso); 
                string cartelIngreso = dt.Rows[0]["CartelIngreso"].ToString();
                lblAviso.Text = cartelIngreso; // Asignar texto
            }
        }
        private void lblAviso_Paint(object sender, PaintEventArgs e)
        {
            // Obtener el color del borde del Tag
            if (lblAviso.Tag is Color colorBorde)
            {
                // Grosor del borde
                int grosor = 2;

                // Dibujar el borde
                using (Pen pen = new Pen(colorBorde, grosor))
                {
                    e.Graphics.DrawRectangle(pen,
                        new Rectangle(0, 0, lblAviso.Width - 1, lblAviso.Height - 1));
                }
            }
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
                    lblNombreCliente.ForeColor = Color.Black; // Resetear color
                    timer.Stop();
                };
            }
            timer.Start();
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            txtDNIingreso.Focus(); // Mantener foco en el campo del DNI

            try
            {
                // Validación del campo de texto
                if (string.IsNullOrWhiteSpace(txtDNIingreso.Text) || !int.TryParse(txtDNIingreso.Text, out int dni))
                {
                    lblNombreCliente.Text = "Ingrese un DNI válido.";
                    lblNombreCliente.ForeColor = Color.Red; // Mensaje de error en rojo
                    StartTimerToClearLabel();
                    return;
                }

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
                        db.RegistrarVisita(clienteId);

                        // Mensajes personalizados aleatorios
                        string[] mensajes = new string[]
                        {
                            $"¡Hola {nombreCliente}! 😄 ¡Qué bueno verte de nuevo!",
                            $"¡Hola {nombreCliente}! 😄 ¡Vamos por más juntos! 💪",
                            $"¡Hola {nombreCliente}! 🏋️‍♂️ ¡Qué bueno verte de nuevo!",
                            $"¡Hola {nombreCliente}! ✨ ¡Va a ser un gran día de entrenamiento! 💥"
                        };

                        lblNombreCliente.Text = mensajes[random.Next(mensajes.Length)];
                        lblNombreCliente.ForeColor = Color.Green; // Cliente con acceso permitido
                        txtDNIingreso.Text = ""; // Limpiar campo
                    }
                    else
                    {
                        lblNombreCliente.Text = $"Lo sentimos, {nombreCliente}. No tiene acceso.";
                        lblNombreCliente.ForeColor = Color.Red; // Cliente sin acceso
                    }
                }
                else
                {
                    lblNombreCliente.Text = "DNI no registrado en el sistema.";
                    lblNombreCliente.ForeColor = Color.Red; // Mensaje de error en rojo
                }

                StartTimerToClearLabel(); // Limpia el mensaje después de un tiempo
            }
            catch (Exception ex)
            {
                lblNombreCliente.Text = $"Error: {ex.Message}";
                lblNombreCliente.ForeColor = Color.Red; // Mensaje de error en rojo
                StartTimerToClearLabel();
            }
        }
    }
}
