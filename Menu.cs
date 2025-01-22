using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace System_Fitness
{
    public partial class Menu : Form
    {
        dbQuery db = new dbQuery();
        public Menu()
        {
            InitializeComponent();
            AplicarConfiguraciones();
        }
        public void AplicarConfiguraciones()
        {
            DataTable dt = db.ObtenerConfiguracion();

            if (dt.Rows.Count > 0)
            {
                // Aplicar configuraciones
                this.BackColor = ColorTranslator.FromHtml(dt.Rows[0]["ColorFondo"].ToString());
                ContenedorLateral.FillColor = ColorTranslator.FromHtml(dt.Rows[0]["ColorBarraLateral"].ToString());
                ContenedorSuperior.FillColor = ColorTranslator.FromHtml(dt.Rows[0]["ColorSuperior"].ToString());
                lblNombre.Text = "System Fitness - " + dt.Rows[0]["NombreGimnasio"].ToString();
                lblNombre.ForeColor = ColorTranslator.FromHtml(dt.Rows[0]["ForeColorNombreGimnasio"].ToString());
                CargarLogo(); ObtenerRutaLogo();
            }
        }
        private void CargarLogo()
        {
            string logoPath = ObtenerRutaLogo();  // Recuperar la ruta desde la base de datos

            if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
            {
                pctLogo.ImageLocation = logoPath;  // Asignar la ruta al PictureBox
            }
            else
            {
                pctLogo.Image = null;  // Si no hay logo, dejar el PictureBox vacío
            }
        }

        public string ObtenerRutaLogo()
        {
            string query = "SELECT Logo FROM AjustesSistema WHERE AjusteID = 1";
            DataTable dt = db.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Logo"].ToString();  // Obtener la ruta guardada en la base de datos
            }

            return null;
        }

        // Método para cargar cualquier UserControl
        private void CargarUserControl(UserControl userControl)
        {
            mainPanel.Controls.Clear(); // Limpia el panel principal
            userControl.Dock = DockStyle.Fill; // Ajusta el UserControl al panel
            mainPanel.Controls.Add(userControl); // Agrega el UserControl al panel
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            // Cargar UserControl de inicio
            Inicio inicioControl = new Inicio();
            CargarUserControl(inicioControl);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            // Cargar UserControl de clientes
            Clientes clientesControl = new Clientes();
            CargarUserControl(clientesControl);
        }

        private void btnpagos_Click(object sender, EventArgs e)
        {
            // Cargar UserControl de pagos
            Pagos pagosControl = new Pagos();
            CargarUserControl(pagosControl);
        }

        private void btnRutinas_Click(object sender, EventArgs e)
        {
            // Cargar UserControl de rutinas
            Rutinas rutinasControl = new Rutinas();
            CargarUserControl(rutinasControl);
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            // Cargar UserControl de finanzas
            FinanzasUserControl FinanzasUserControl = new FinanzasUserControl();
            CargarUserControl(FinanzasUserControl);
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            // Cargar UserControl de calendario
            Calendario calendarioControl = new Calendario();
            CargarUserControl(calendarioControl);
        }

        private void btnEstadistica_Click(object sender, EventArgs e)
        {
            // Cargar UserControl de estadísticas
            Estadistica estadisticaControl = new Estadistica();
            CargarUserControl(estadisticaControl);
        }

        private void btnIngresos_Click(object sender, EventArgs e)
        {
            frmIngresos frmIngresos = new frmIngresos();
            frmIngresos.ShowDialog();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            // Cargar UserControl de configuración
            Configuracion configuracionControl = new Configuracion();
            CargarUserControl(configuracionControl);
            AplicarConfiguraciones();
        }

        public static DataSet DataSetCache = new DataSet();



        public static DataTable ObtenerTabla(string nombreTabla)
        {
            if (DataSetCache.Tables.Contains(nombreTabla))
            {
                return DataSetCache.Tables[nombreTabla];
            }
            else
            {
                throw new Exception($"La tabla {nombreTabla} no está en la caché.");
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // Cargar UserControl de inicio
            Inicio inicioControl = new Inicio();
            CargarUserControl(inicioControl);
        }

        private void btnRecordatorios_Click(object sender, EventArgs e)
        {// Verificar si el evento se ejecuta
            Recordatorio recordatorio = new Recordatorio();
            CargarUserControl(recordatorio);
        }

        private void pctLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
