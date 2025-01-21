using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace System_Fitness
{
    public partial class Estadistica : UserControl
    {
        private dbQuery db = new dbQuery(); 
        private Chart chartClientes; // Declare the chart control


        public Estadistica()
        {
            InitializeComponent();
            // Cargar opciones en los ComboBoxes
            cmbGrafico1.Items.AddRange(new string[] {
                "Clientes activos", "Nuevos clientes", "Retención de clientes",
                "Edad promedio", "Distribución por género"
            });

            cmbGrafico2.Items.AddRange(new string[] {
                 "Frecuencia de uso",
                "Promedio de visitas por cliente",
            });

            // Configuración inicial de DateTimePickers
            dtpFechaDesde.Value = DateTime.Now.AddMonths(-1); // Último mes por defecto
            dtpFechaHasta.Value = DateTime.Now;
        }
        private void CargarEstadisticaGrafico2(string estadistica)
        {
            DateTime fechaDesde = dtpFechaDesde.Value;
            DateTime fechaHasta = dtpFechaHasta.Value;

            switch (estadistica)
            {
                case "Frecuencia de uso":
                    MostrarFrecuenciaDeUso(chartDos, fechaDesde, fechaHasta);
                    break;
                case "Promedio de visitas por cliente":
                    MostrarPromedioVisitasPorCliente(chartDos, fechaDesde, fechaHasta);
                    break;
            }
        }
        private void MostrarFrecuenciaDeUso(Chart chart, DateTime fechaDesde, DateTime fechaHasta)
        {
            string query = @"
        SELECT v.ClienteId, COUNT(*) AS Frecuencia
        FROM Visitas v
        WHERE v.Fecha BETWEEN @FechaDesde AND @FechaHasta
        GROUP BY v.ClienteId";

            SqlCommand command = new SqlCommand(query, db.GetConnection());
            command.Parameters.AddWithValue("@FechaDesde", fechaDesde);
            command.Parameters.AddWithValue("@FechaHasta", fechaHasta);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            chart.Series.Clear();
            chart.Series.Add("Frecuencia de Uso");

            foreach (DataRow row in dataTable.Rows)
            {
                chart.Series["Frecuencia de Uso"].Points.AddXY(row["ClienteId"], row["Frecuencia"]);
            }
        }

        private void MostrarPromedioVisitasPorCliente(Chart chart, DateTime fechaDesde, DateTime fechaHasta)
        {
            string query = @"
        SELECT AVG(visitas) AS Promedio
        FROM (
            SELECT COUNT(*) AS visitas
            FROM Visitas v
            WHERE v.Fecha BETWEEN @FechaDesde AND @FechaHasta
            GROUP BY v.ClienteId
        ) AS subconsulta";

            SqlCommand command = new SqlCommand(query, db.GetConnection());
            command.Parameters.AddWithValue("@FechaDesde", fechaDesde);
            command.Parameters.AddWithValue("@FechaHasta", fechaHasta);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            chart.Series.Clear();
            chart.Series.Add("Promedio Visitas por Cliente");
            chart.Series["Promedio Visitas por Cliente"].Points.AddXY("Promedio", dataTable.Rows[0]["Promedio"]);
        }









        private void CargarEstadisticaGrafico1(string estadistica)
        {
            DateTime fechaDesde = dtpFechaDesde.Value;
            DateTime fechaHasta = dtpFechaHasta.Value;

            switch (estadistica)
            {
                case "Clientes activos":
                    MostrarClientesActivos(chartUno, fechaDesde, fechaHasta);
                    break;
                case "Nuevos clientes":
                    MostrarNuevosClientes(chartUno, fechaDesde, fechaHasta);
                    break;
                case "Retención de clientes":
                    MostrarRetencionClientes(chartUno, fechaDesde, fechaHasta);
                    break;
                case "Edad promedio":
                    MostrarEdadPromedio(chartUno);
                    break;
                case "Distribución por género":
                    MostrarDistribucionPorGenero(chartUno);
                    break;
            }
        }


        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Filtrar por la opción seleccionada en cmbGrafico1
            if (cmbGrafico1.SelectedItem != null)
            {
                CargarEstadisticaGrafico1(cmbGrafico1.SelectedItem.ToString());
            }

            // Filtrar por la opción seleccionada en cmbGrafico2
            if (cmbGrafico2.SelectedItem != null)
            {
                CargarEstadisticaGrafico2(cmbGrafico2.SelectedItem.ToString());
            }
        }
        private void ConfigurarGrafico(Chart chart)
        {
            chart.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Configuración de los valores del eje X (Mes/Año)
            chartArea.AxisX.Title = "Mes/Año";
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Months;
            chartArea.AxisX.Interval = 1; // Muestra un intervalo por mes

            // Configuración del eje Y// O el título correspondiente a la estadística
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;

            // Asignación de tipo de gráfico
        }

        private void MostrarClientesActivos(Chart chart, DateTime fechaDesde, DateTime fechaHasta)
        {
            string query = @"
        SELECT YEAR(v.Fecha) AS Año, MONTH(v.Fecha) AS Mes, COUNT(DISTINCT v.ClienteId) AS ClientesActivos
        FROM Visitas v
        WHERE v.Fecha BETWEEN @FechaDesde AND @FechaHasta
        GROUP BY YEAR(v.Fecha), MONTH(v.Fecha)
        ORDER BY Año, Mes";

            SqlCommand command = new SqlCommand(query, db.GetConnection());
            command.Parameters.AddWithValue("@FechaDesde", fechaDesde);
            command.Parameters.AddWithValue("@FechaHasta", fechaHasta);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Verificación para asegurarse de que se estén obteniendo varios puntos
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar en el gráfico.");
                return;
            }

            // Limpiar serie anterior
            chart.Series.Clear();
            chart.Series.Add("Clientes Activos");

            // Agregar los puntos al gráfico por cada mes
            foreach (DataRow row in dataTable.Rows)
            {
                string fechaMes = $"{row["Mes"]}/{row["Año"]}"; // Formato Mes/Año
                chart.Series["Clientes Activos"].Points.AddXY(fechaMes, row["ClientesActivos"]);
            }

            // Llamar a la función ConfigurarGrafico para que se ajusten las propiedades del gráfico
            ConfigurarGrafico(chart);
        }


        private void MostrarNuevosClientes(Chart chart, DateTime fechaDesde, DateTime fechaHasta)
        {
            string query = @"
        SELECT YEAR(c.FechaIngreso) AS Año, MONTH(c.FechaIngreso) AS Mes, COUNT(c.ClienteID) AS NuevosClientes
        FROM Clientes c
        WHERE c.FechaIngreso BETWEEN @FechaDesde AND @FechaHasta
        GROUP BY YEAR(c.FechaIngreso), MONTH(c.FechaIngreso)
        ORDER BY Año, Mes";

            SqlCommand command = new SqlCommand(query, db.GetConnection());
            command.Parameters.AddWithValue("@FechaDesde", fechaDesde);
            command.Parameters.AddWithValue("@FechaHasta", fechaHasta);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Limpiar serie anterior
            chart.Series.Clear();
            chart.Series.Add("Nuevos Clientes");

            // Agregar puntos al gráfico para cada mes
            foreach (DataRow row in dataTable.Rows)
            {
                string fechaMes = $"{row["Mes"]}/{row["Año"]}"; // Formato Mes/Año
                chart.Series["Nuevos Clientes"].Points.AddXY(fechaMes, row["NuevosClientes"]);
            }

            // Llamar a la función ConfigurarGrafico para que se ajusten las propiedades del gráfico
            ConfigurarGrafico(chart);
        }

        private void MostrarRetencionClientes(Chart chart, DateTime fechaDesde, DateTime fechaHasta)
        {
            string query = @"
        SELECT YEAR(v.Fecha) AS Año, MONTH(v.Fecha) AS Mes, COUNT(DISTINCT v.ClienteId) AS ClientesRetenidos
        FROM Visitas v
        WHERE v.Fecha BETWEEN @FechaDesde AND @FechaHasta
        GROUP BY YEAR(v.Fecha), MONTH(v.Fecha)
        ORDER BY Año, Mes";

            SqlCommand command = new SqlCommand(query, db.GetConnection());
            command.Parameters.AddWithValue("@FechaDesde", fechaDesde);
            command.Parameters.AddWithValue("@FechaHasta", fechaHasta);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Limpiar serie anterior
            chart.Series.Clear();
            chart.Series.Add("Clientes Retenidos");

            // Agregar puntos al gráfico para cada mes
            foreach (DataRow row in dataTable.Rows)
            {
                string fechaMes = $"{row["Mes"]}/{row["Año"]}"; // Formato Mes/Año
                chart.Series["Clientes Retenidos"].Points.AddXY(fechaMes, row["ClientesRetenidos"]);
            }

            // Llamar a la función ConfigurarGrafico para que se ajusten las propiedades del gráfico
            ConfigurarGrafico(chart);
        }

        private void MostrarEdadPromedio(Chart chart)
        {
            string query = @"
        SELECT YEAR(GETDATE()) - YEAR(c.FechaNacimiento) AS EdadPromedio
        FROM Clientes c";

            SqlCommand command = new SqlCommand(query, db.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Limpiar serie anterior
            chart.Series.Clear();
            chart.Series.Add("Edad Promedio");

            // Calcular la edad promedio
            if (dataTable.Rows.Count > 0)
            {
                decimal edadPromedio = Convert.ToDecimal(dataTable.Compute("AVG(EdadPromedio)", string.Empty));
                chart.Series["Edad Promedio"].Points.AddXY("Edad Promedio", edadPromedio);
            }

            // Llamar a la función ConfigurarGrafico para que se ajusten las propiedades del gráfico
            ConfigurarGrafico(chart);
        }

        private void MostrarDistribucionPorGenero(Chart chart)
        {
            string query = @"
        SELECT Sexo, COUNT(ClienteID) AS Cantidad
        FROM Clientes
        GROUP BY Sexo";

            SqlCommand command = new SqlCommand(query, db.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Limpiar serie anterior
            chart.Series.Clear();
            chart.Series.Add("Distribución por Género");

            // Agregar puntos al gráfico
            foreach (DataRow row in dataTable.Rows)
            {
                string genero = row["Sexo"].ToString();
                chart.Series["Distribución por Género"].Points.AddXY(genero, row["Cantidad"]);
            }

            // Llamar a la función ConfigurarGrafico para que se ajusten las propiedades del gráfico
            ConfigurarGrafico(chart);
        }


        private void chartUno_Click(object sender, EventArgs e)
        {

        }

        private void chartDos_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
