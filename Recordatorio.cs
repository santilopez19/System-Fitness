using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace System_Fitness
{
    public partial class Recordatorio : UserControl
    {
        public Recordatorio()
        {
            InitializeComponent();
            CargarRecordatorioDeCuota();
        }
        private void CargarRecordatorioDeCuota()
        {
            dbQuery db = new dbQuery();
            // Consulta SQL para obtener los clientes cuya cuota se vence en 5 días
            string query = @"
        SELECT c.Nombre, c.Telefono, p.FechaPago, 
               DATEADD(DAY, 30, p.FechaPago) AS FechaVencimiento
        FROM Clientes c
        JOIN Pagos p ON c.ClienteID = p.ClienteID
        WHERE DATEDIFF(DAY, GETDATE(), DATEADD(DAY, 30, p.FechaPago)) = 5
        AND p.FechaPago IS NOT NULL;";

            SqlCommand command = new SqlCommand(query, db.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Verificar si hay datos
            if (dataTable.Rows.Count > 0)
            {
                dgvRecordatorio.DataSource = dataTable;
                // Verificar que las columnas estén en el DataTable antes de configurar el DataGridView
                if (dataTable.Columns.Contains("Nombre") && dataTable.Columns.Contains("Telefono") && dataTable.Columns.Contains("FechaPago"))
                {
                    ConfigurarDataGridView();  // Llamar a la configuración de columnas
                }
            }
            else
            {
                MessageBox.Show("No se encontraron registros.");
            }
        }

        private void ConfigurarDataGridView()
        {
            // Asegurarse de que dgvRecordatorio no sea null
            if (dgvRecordatorio != null && dgvRecordatorio.Columns.Count > 0)
            {
                // Comprobar que las columnas existen en el DataGridView
                if (dgvRecordatorio.Columns.Contains("Nombre"))
                    dgvRecordatorio.Columns["Nombre"].HeaderText = "Nombre del Cliente";

                if (dgvRecordatorio.Columns.Contains("Telefono"))
                    dgvRecordatorio.Columns["Telefono"].HeaderText = "Teléfono";

                if (dgvRecordatorio.Columns.Contains("FechaPago"))
                    dgvRecordatorio.Columns["FechaPago"].HeaderText = "Fecha de Pago";

                if (dgvRecordatorio.Columns.Contains("FechaVencimiento"))
                    dgvRecordatorio.Columns["FechaVencimiento"].HeaderText = "Fecha de Vencimiento";

                // Si no deseas que se muestre la columna ClienteID, puedes ocultarla
                if (dgvRecordatorio.Columns.Contains("ClienteID"))
                    dgvRecordatorio.Columns["ClienteID"].Visible = false;
            }
            else
            {
                MessageBox.Show("El DataGridView no está correctamente inicializado.");
            }
        }


    }
}
