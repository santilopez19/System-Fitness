using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;

namespace System_Fitness
{
    public partial class FinanzasUserControl : UserControl
    {
        public FinanzasUserControl()
        {
            InitializeComponent();
            // Configuramos el gráfico al inicio
            dgvIngresos.AllowUserToAddRows = false;
            dgvEgresos.AllowUserToAddRows = false;
            ConfigureChart();
        }

        // Método para configurar el gráfico
        private void ConfigureChart()
        {
            // Limpiamos los datos previos en el gráfico
            chartFinanzas.ChartAreas.Clear();
            var chartArea = new ChartArea("MainArea");
            chartFinanzas.ChartAreas.Add(chartArea);

            // Inicializamos las series
            chartFinanzas.Series.Clear();

            // Usamos las consultas SQL para obtener los datos de los pagos y gastos
            if (rbBalance.Checked)
            {
                // Configuramos el gráfico para Balance (Ingresos - Egresos)
                var ingresosData = GetIngresosPorMes();
                var egresosData = GetEgresosPorMes();

                // Calculamos los balances mensuales (Ingresos - Egresos)
                var balanceMensual = new Dictionary<string, decimal>();
                foreach (var mes in ingresosData.Keys)
                {
                    decimal ingresos = ingresosData.ContainsKey(mes) ? ingresosData[mes] : 0;
                    decimal egresos = egresosData.ContainsKey(mes) ? egresosData[mes] : 0;
                    balanceMensual[mes] = ingresos - egresos;
                }

                // Agregamos los balances al gráfico
                Series seriesBalance = new Series("Balance");
                foreach (var balance in balanceMensual)
                {
                    seriesBalance.Points.AddXY(balance.Key, balance.Value);
                }

                // Configuramos el tipo de gráfico como columnas

                seriesBalance.ChartType = SeriesChartType.Line;
                seriesBalance.BorderDashStyle = ChartDashStyle.Solid;
                seriesBalance.Color = System.Drawing.Color.PowderBlue;
                seriesBalance.BorderWidth = 3;
                seriesBalance.MarkerStyle = MarkerStyle.Circle; // Marcador en los puntos
                seriesBalance.MarkerSize = 8;
                seriesBalance.MarkerColor = Color.Black; // Color del marcador


                chartFinanzas.Series.Add(seriesBalance);
            }
            else if (rbIngresosyEgresos.Checked)
            {
                // Configuramos el gráfico para Egresos y Ingresos por separado
                var egresosData = GetEgresosPorMes();
                var ingresosData = GetIngresosPorMes();

                // Agregamos los egresos al gráfico
                Series seriesEgresos = new Series("Egresos");
                foreach (var egreso in egresosData)
                {
                    seriesEgresos.Points.AddXY(egreso.Key, egreso.Value);
                }
                seriesEgresos.ChartType = SeriesChartType.Line; // Cambiar de Column a Line
                seriesEgresos.Color = System.Drawing.Color.Salmon; // Color para gastos
                seriesEgresos.BorderWidth = 4; // Grosor de la línea
                seriesEgresos.BorderDashStyle = ChartDashStyle.Solid;

                // Agregamos los ingresos al gráfico
                Series seriesIngresos = new Series("Ingresos");
                foreach (var ingreso in ingresosData)
                {
                    seriesIngresos.Points.AddXY(ingreso.Key, ingreso.Value);
                }
                seriesIngresos.ChartType = SeriesChartType.Line; // Cambiar de Column a Line
                seriesIngresos.Color = System.Drawing.Color.PaleGreen; // Color para ingresos
                seriesIngresos.BorderWidth = 4;
                seriesIngresos.BorderDashStyle = ChartDashStyle.Solid;


                chartFinanzas.Series.Add(seriesEgresos);
                chartFinanzas.Series.Add(seriesIngresos);
            }
            chartFinanzas.ChartAreas[0].BackColor = Color.White; // Fondo del área de dibujo
            chartFinanzas.ChartAreas[0].AxisX.LineColor = Color.LightGray; // Color del eje X
            chartFinanzas.ChartAreas[0].AxisY.LineColor = Color.LightGray; // Color del eje Y
            chartFinanzas.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray; // Cuadrícula en X
            chartFinanzas.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray; // Cuadrícula en Y
            chartFinanzas.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
            chartFinanzas.ChartAreas[0].BorderWidth = 2;
            chartFinanzas.ChartAreas[0].BorderColor = Color.White;

        }


        // Evento para cuando se cambie el radio button de Balance
        private void rbBalance_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBalance.Checked)
            {
                ConfigureChart();
            }
        }

        // Evento para cuando se cambie el radio button de Ingresos y Egresos
        private void rbIngresosyEgresos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIngresosyEgresos.Checked)
            {
                ConfigureChart();
            }
        }

        // Método para obtener los ingresos por mes de la tabla Pagos
        private Dictionary<string, decimal> GetIngresosPorMes()
        {
            Dictionary<string, decimal> ingresos = new Dictionary<string, decimal>();

            string query = @"
        SELECT FORMAT(FechaPago, 'MMMM yyyy') AS Mes, SUM(Monto) AS TotalIngresos
        FROM Pagos
        GROUP BY FORMAT(FechaPago, 'MMMM yyyy')
        ORDER BY MAX(FechaPago)
    ";

            try
            {
                using (SqlConnection conn = new SqlConnection("server=localhost; database=dbSystemFitness; integrated security=true; Encrypt=False;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string mes = reader["Mes"].ToString();
                                decimal totalIngresos = Convert.ToDecimal(reader["TotalIngresos"]);
                                ingresos[mes] = totalIngresos;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los ingresos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ingresos;
        }

        // Método para obtener los egresos por mes de la tabla Gastos
        private Dictionary<string, decimal> GetEgresosPorMes()
        {
            Dictionary<string, decimal> egresos = new Dictionary<string, decimal>();

            string query = @"
        SELECT FORMAT(FechaGasto, 'MMMM yyyy') AS Mes, SUM(Monto) AS TotalEgresos
        FROM Gastos
        GROUP BY FORMAT(FechaGasto, 'MMMM yyyy')
        ORDER BY MAX(FechaGasto)
    ";

            try
            {
                using (SqlConnection conn = new SqlConnection("server=localhost; database=dbSystemFitness; integrated security=true; Encrypt=False;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string mes = reader["Mes"].ToString();
                                decimal totalEgresos = Convert.ToDecimal(reader["TotalEgresos"]);
                                egresos[mes] = totalEgresos;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los egresos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return egresos;
        }

        // Método para obtener los egresos entre dos fechas
        private Dictionary<string, decimal> GetEgresosPorMes(DateTime fechaDesde, DateTime fechaHasta)
        {
            Dictionary<string, decimal> egresos = new Dictionary<string, decimal>();

            string query = @"
        SELECT FORMAT(FechaGasto, 'MMMM yyyy') AS Mes, SUM(Monto) AS TotalEgresos
        FROM Gastos
        WHERE FechaGasto >= @FechaDesde AND FechaGasto <= @FechaHasta
        GROUP BY FORMAT(FechaGasto, 'MMMM yyyy')
        ORDER BY MAX(FechaGasto)
    ";

            try
            {
                using (SqlConnection conn = new SqlConnection("server=localhost; database=dbSystemFitness; integrated security=true; Encrypt=False;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde);
                        cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string mes = reader["Mes"].ToString();
                                decimal totalEgresos = Convert.ToDecimal(reader["TotalEgresos"]);
                                egresos[mes] = totalEgresos;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los egresos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return egresos;
        }

        
        // Método para inicializar las columnas en los DataGridViews
        private void InitializeGridColumns()
        {
            // Definir las columnas para el DataGridView de Ingresos
            if (dgvIngresos.Columns.Count == 0) // Solo lo hacemos si no hay columnas definidas
            {
                dgvIngresos.Columns.Add("Fecha", "Fecha");
                dgvIngresos.Columns.Add("Monto", "Monto");
            }

            // Definir las columnas para el DataGridView de Egresos
            if (dgvEgresos.Columns.Count == 0) // Solo lo hacemos si no hay columnas definidas
            {
                dgvEgresos.Columns.Add("Fecha", "Fecha");
                dgvEgresos.Columns.Add("Monto", "Monto");
                dgvEgresos.Columns.Add("Categoria", "Categoría"); // Nueva columna para Categoría
            }
        }


        // Método para cargar los egresos en el DataGridView
        private async Task LoadEgresosGrid(DateTime fechaDesde, DateTime fechaHasta)
        {
            dgvEgresos.Rows.Clear();  // Limpiar las filas existentes

            var egresosData = await GetEgresosEntreFechasAsync(fechaDesde, fechaHasta);

            foreach (var egreso in egresosData)
            {
                // Agregar cada egreso individual con su fecha, monto y categoría
                dgvEgresos.Rows.Add(egreso.Fecha.ToString("dd/MM/yyyy"), egreso.TotalEgresos, egreso.Categoria);
            }
        }
        // Método para cargar los ingresos en el DataGridView
        private async Task LoadIngresosGrid(DateTime fechaDesde, DateTime fechaHasta)
        {
            dgvIngresos.Rows.Clear();  // Limpiar las filas existentes

            var ingresosData = await GetIngresosEntreFechasAsync(fechaDesde, fechaHasta);

            foreach (var ingreso in ingresosData)
            {
                // Agregar cada ingreso individual con su fecha y monto
                dgvIngresos.Rows.Add(ingreso.Fecha.ToString("dd/MM/yyyy"), ingreso.TotalIngresos);
            }
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {// Verificar que las fechas sean válidas y que 'Fecha Desde' no sea posterior a 'Fecha Hasta'
            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detener la ejecución si las fechas no son válidas
            }

            // Asegurarse de que las columnas estén inicializadas
            InitializeGridColumns();

            // Cargar los ingresos y egresos filtrados por las fechas
            await LoadIngresosGrid(dtpFechaDesde.Value, dtpFechaHasta.Value);
            await LoadEgresosGrid(dtpFechaDesde.Value, dtpFechaHasta.Value);
        }

        // Método para obtener los ingresos individuales entre fechas
        private async Task<List<Ingreso>> GetIngresosEntreFechasAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Ingreso> ingresos = new List<Ingreso>();

            string query = @"
    SELECT FechaPago, Monto
    FROM Pagos
    WHERE FechaPago BETWEEN @FechaDesde AND @FechaHasta
    ORDER BY FechaPago
    ";

            try
            {
                using (SqlConnection conn = new SqlConnection("server=localhost; database=dbSystemFitness; integrated security=true; Encrypt=False;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde);
                        cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                DateTime fecha = Convert.ToDateTime(reader["FechaPago"]);
                                decimal totalIngresos = Convert.ToDecimal(reader["Monto"]);
                                ingresos.Add(new Ingreso { Fecha = fecha, TotalIngresos = totalIngresos });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los ingresos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ingresos;
        }

        // Método para obtener los egresos individuales entre fechas
        private async Task<List<Egreso>> GetEgresosEntreFechasAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Egreso> egresos = new List<Egreso>();

            string query = @"
    SELECT FechaGasto, Monto, Categoria
    FROM Gastos
    WHERE FechaGasto BETWEEN @FechaDesde AND @FechaHasta
    ORDER BY FechaGasto
    ";

            try
            {
                using (SqlConnection conn = new SqlConnection("server=localhost; database=dbSystemFitness; integrated security=true; Encrypt=False;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde);
                        cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                DateTime fecha = Convert.ToDateTime(reader["FechaGasto"]);
                                decimal totalEgresos = Convert.ToDecimal(reader["Monto"]);
                                string categoria = reader["Categoria"].ToString();
                                egresos.Add(new Egreso { Fecha = fecha, TotalEgresos = totalEgresos, Categoria = categoria });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los egresos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return egresos;
        }

    }

    // Clases para Ingreso y Egreso
    public class Ingreso
    {
        public DateTime Fecha { get; set; }
        public decimal TotalIngresos { get; set; }
    }

    public class Egreso
    {
        public DateTime Fecha { get; set; }
        public decimal TotalEgresos { get; set; }
        public string Categoria { get; set; }
    }
}
