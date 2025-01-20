using System;
using System.Data;
using System.Windows.Forms;

namespace System_Fitness
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
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
    }
}
