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
                "Asistencias por día/hora", "Frecuencia de uso", "Clientes inactivos",
                "Promedio de visitas por cliente",
            });

            // Configuración inicial de DateTimePickers
            dtpFechaDesde.Value = DateTime.Now.AddMonths(-1); // Último mes por defecto
            dtpFechaHasta.Value = DateTime.Now;
        }

        private void CargarDatosEnGrafico(Chart chart, string query, SqlParameter[] parameters, string xField, string yField)
        {
            DataTable data = db.ExecuteQuery(query, parameters);

            chart.Series.Clear();
            chart.DataSource = data;

            chart.Series.Add(new Series
            {
                Name = "Serie",
                XValueMember = xField,
                YValueMembers = yField,
                ChartType = SeriesChartType.Line
            });

            chart.DataBind();
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

        private void CargarEstadisticaGrafico2(string estadistica)
        {
            DateTime fechaDesde = dtpFechaDesde.Value;
            DateTime fechaHasta = dtpFechaHasta.Value;

            switch (estadistica)
            {
                case "Asistencias por día/hora":
                    MostrarAsistenciasPorDia(chartDos, fechaDesde, fechaHasta);
                    break;
                case "Frecuencia de uso":
                    MostrarFrecuenciaUso(chartDos, fechaDesde, fechaHasta);
                    break;
                case "Clientes inactivos":
                    MostrarClientesInactivos(chartDos, fechaDesde, fechaHasta);
                    break;
                case "Promedio de visitas por cliente":
                    MostrarPromedioVisitasPorCliente(chartDos, fechaDesde, fechaHasta);
                    break;
            }
        }

        public void MostrarPromedioVisitasPorCliente(Chart chart, DateTime desde, DateTime hasta)
        {
            string query = @"
        SELECT ClienteID, COUNT(*) / DATEDIFF(DAY, @Desde, @Hasta) AS PromedioVisitas
        FROM Visitas
        WHERE FechaVisita BETWEEN @Desde AND @Hasta
        GROUP BY ClienteID";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Desde", desde),
                new SqlParameter("@Hasta", hasta)
            };

            DataTable result = db.ExecuteQuery(query, parameters);

            // Configurar la serie del gráfico
            chart.Series.Clear();
            var series = chart.Series.Add("Promedio de Visitas por Cliente");
            series.ChartType = SeriesChartType.Column;

            // Agregar los datos al gráfico
            foreach (DataRow row in result.Rows)
            {
                string clienteId = row["ClienteID"].ToString();
                decimal promedioVisitas = Convert.ToDecimal(row["PromedioVisitas"]);

                series.Points.AddXY(clienteId, promedioVisitas); // Agrega datos al gráfico
            }
        }

        private void MostrarDistribucionPorGenero(Chart chart)
        {
            string query = @"
        SELECT Sexo, COUNT(*) AS Cantidad
        FROM Clientes
        GROUP BY Sexo";

            DataTable dt = db.ExecuteQuery(query);

            chart.Series["Series1"].Points.Clear();

            foreach (DataRow row in dt.Rows)
            {
                chart.Series["Series1"].Points.AddXY(row["Sexo"], row["Cantidad"]);
            }
        }

        public void MostrarEdadPromedio(Chart chart)
        {
            string query = "SELECT AVG(DATEDIFF(YEAR, FechaNacimiento, GETDATE())) AS EdadPromedio FROM Clientes";

            DataTable result = db.ExecuteQuery(query);

            chart.Series.Clear();
            var series = chart.Series.Add("Edad Promedio");
            series.ChartType = SeriesChartType.Column;

            foreach (DataRow row in result.Rows)
            {
                series.Points.AddXY("Edad Promedio", Convert.ToInt32(row["EdadPromedio"]));
            }
        }

        public void MostrarClientesActivos(Chart chart, DateTime fechaDesde, DateTime fechaHasta)
        {
            string query = @"
        SELECT COUNT(*) AS ClientesActivos
        FROM Clientes
        WHERE FechaAlta BETWEEN @Desde AND @Hasta";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Desde", fechaDesde),
                new SqlParameter("@Hasta", fechaHasta)
            };

            DataTable result = db.ExecuteQuery(query, parameters);

            chart.Series.Clear();
            var series = chart.Series.Add("Clientes Activos");
            series.ChartType = SeriesChartType.Column;

            foreach (DataRow row in result.Rows)
            {
                series.Points.AddXY("Clientes Activos", Convert.ToInt32(row["ClientesActivos"]));
            }
        }

        private void MostrarNuevosClientes(Chart chart, DateTime fechaDesde, DateTime fechaHasta)
        {
            string query = @"
        SELECT COUNT(*) AS NuevosClientes, CAST(FechaIngreso AS DATE) AS Fecha
        FROM Clientes
        WHERE FechaIngreso BETWEEN @FechaDesde AND @FechaHasta
        GROUP BY CAST(FechaIngreso AS DATE)
        ORDER BY Fecha";

            SqlParameter[] parameters = {
                new SqlParameter("@FechaDesde", fechaDesde),
                new SqlParameter("@FechaHasta", fechaHasta)
            };

            CargarDatosEnGrafico(chart, query, parameters, "Fecha", "NuevosClientes");
        }

        public void MostrarRetencionClientes(Chart chart, DateTime desde, DateTime hasta)
        {
            string query = @"
        SELECT ClienteID, COUNT(*) AS CantidadVisitas
        FROM Visitas
        WHERE FechaVisita BETWEEN @Desde AND @Hasta
        GROUP BY ClienteID";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Desde", desde),
                new SqlParameter("@Hasta", hasta)
            };

            DataTable result = db.ExecuteQuery(query, parameters);

            // Configurar la serie del gráfico
            chart.Series.Clear();
            var series = chart.Series.Add("Retención de Clientes");
            series.ChartType = SeriesChartType.Column;

            // Agregar los datos al gráfico
            foreach (DataRow row in result.Rows)
            {
                string clienteId = row["ClienteID"].ToString();
                int cantidadVisitas = Convert.ToInt32(row["CantidadVisitas"]);

                series.Points.AddXY(clienteId, cantidadVisitas); // Agrega datos al gráfico
            }
        }

        public void MostrarFrecuenciaUso(Chart chart, DateTime desde, DateTime hasta)
        {
            string query = @"
        SELECT ClienteID, COUNT(*) AS FrecuenciaUso
        FROM Visitas
        WHERE FechaVisita BETWEEN @Desde AND @Hasta
        GROUP BY ClienteID";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Desde", desde),
                new SqlParameter("@Hasta", hasta)
            };

            DataTable result = db.ExecuteQuery(query, parameters);

            // Configurar la serie del gráfico
            chart.Series.Clear();
            var series = chart.Series.Add("Frecuencia de Uso");
            series.ChartType = SeriesChartType.Column;

            // Agregar los datos al gráfico
            foreach (DataRow row in result.Rows)
            {
                string clienteId = row["ClienteID"].ToString();
                int frecuenciaUso = Convert.ToInt32(row["FrecuenciaUso"]);

                series.Points.AddXY(clienteId, frecuenciaUso); // Agrega datos al gráfico
            }
        }

        public void MostrarClientesInactivos(Chart chart, DateTime desde, DateTime hasta)
        {
            string query = @"
        SELECT ClienteID
        FROM Clientes
        WHERE ClienteID NOT IN (
            SELECT ClienteID
            FROM Visitas
            WHERE FechaVisita BETWEEN @Desde AND @Hasta
        )";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Desde", desde),
                new SqlParameter("@Hasta", hasta)
            };

            DataTable result = db.ExecuteQuery(query, parameters);

            // Configurar la serie del gráfico
            chart.Series.Clear();
            var series = chart.Series.Add("Clientes Inactivos");
            series.ChartType = SeriesChartType.Column;

            // Agregar los datos al gráfico
            foreach (DataRow row in result.Rows)
            {
                string clienteId = row["ClienteID"].ToString();
                series.Points.AddXY(clienteId, 1); // Un punto por cada cliente inactivo
            }
        }

        public void MostrarAsistenciasPorDia(Chart chart, DateTime desde, DateTime hasta)
        {
            string query = @"
        SELECT DAY(FechaVisita) AS Dia, COUNT(*) AS Asistencias
        FROM Visitas
        WHERE FechaVisita BETWEEN @Desde AND @Hasta
        GROUP BY DAY(FechaVisita)";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Desde", desde),
                new SqlParameter("@Hasta", hasta)
            };

            DataTable result = db.ExecuteQuery(query, parameters);

            // Configurar la serie del gráfico
            chart.Series.Clear();
            var series = chart.Series.Add("Asistencias por Día");
            series.ChartType = SeriesChartType.Column;

            // Agregar los datos al gráfico
            foreach (DataRow row in result.Rows)
            {
                string dia = row["Dia"].ToString();
                int asistencias = Convert.ToInt32(row["Asistencias"]);

                series.Points.AddXY(dia, asistencias); // Agrega datos al gráfico
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas por el usuario
            DateTime fechaDesde = dtpFechaDesde.Value;
            DateTime fechaHasta = dtpFechaHasta.Value;

            // Verificar si la fecha seleccionada es posterior a la fecha actual
            if (fechaDesde > DateTime.Now || fechaHasta > DateTime.Now)
            {
                MessageBox.Show("Las fechas seleccionadas no pueden ser posteriores a la fecha actual.", "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si la validación falla
            }

            try
            {
                // Ejecutar la consulta SQL
                string query = "SELECT * FROM dbo.Visitas WHERE FechaAlta BETWEEN @FechaDesde AND @FechaHasta";
                SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter("@FechaDesde", SqlDbType.Date) { Value = fechaDesde },
            new SqlParameter("@FechaHasta", SqlDbType.Date) { Value = fechaHasta }
        };

                // Ejecuta la consulta y llena el DataTable
                DataTable dt = db.ExecuteQuery(query, parameters);

                // Verifica si la tabla tiene resultados
                if (dt.Rows.Count > 0)
                {
                    // Aquí reemplazamos MostrarGrafico por CargarEstadisticaGrafico1 o el método adecuado
                    CargarEstadisticaGrafico1(cmbGrafico1.SelectedItem.ToString()); // Usando el gráfico adecuado para los resultados
                }
                else
                {
                    // Si no hay datos, limpiar el gráfico
                    chartClientes.Series.Clear(); // Aquí usamos el chartClientes correctamente
                    MessageBox.Show("No se encontraron registros para las fechas seleccionadas.", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                // Captura errores relacionados con SQL
                MessageBox.Show($"Error al ejecutar la consulta SQL: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Captura errores generales (no SQL)
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbGrafico1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGrafico1.SelectedItem != null)
            {
                CargarEstadisticaGrafico1(cmbGrafico1.SelectedItem.ToString());
            }
        }

        private void cmbGrafico2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGrafico2.SelectedItem != null)
            {
                CargarEstadisticaGrafico2(cmbGrafico2.SelectedItem.ToString());
            }
        }
    }
}
