using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace System_Fitness
{
    public partial class Inicio : UserControl
    {
        private int gastoIdSeleccionado;

        private DateTime currentDate;

        public Inicio()
        {
            InitializeComponent();
            cmbCategoriaGasto.Items.Add("Comida");
            cmbCategoriaGasto.Items.Add("Suplementos");
            cmbCategoriaGasto.Items.Add("Infraestructura");
            cmbCategoriaGasto.Items.Add("Sueldos");
            CargarClientesActivos();
            CargarGastos();
            dgvProxClas.AllowUserToAddRows = false;
            dgvGastos.AllowUserToAddRows = false;
            currentDate = DateTime.Now;
            InitializeCalendar();
            LoadClasesToGrid();

            dgvProxClas.AllowUserToAddRows = false;

        }
        private void InitializeCalendar()
        {
            // Establecer los días de la semana (lunes a viernes)
            dgvProxClas.ColumnCount = 6;
            dgvProxClas.RowCount = 12; // Horas disponibles (1 fila por cada hora)
            dgvProxClas.Columns[0].Name = "Hora";

            // Inicializar las horas de las clases en la primera columna
            string[] horas = { "8:00", "9:00", "10:00", "11:00", "12:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" };
            for (int i = 0; i < horas.Length; i++)
            {
                dgvProxClas.Rows[i].Cells[0].Value = horas[i];
            }

            // Ajustar la visualización de los días (lunes a viernes)
            UpdateCalendar();
        }
        private void UpdateCalendar()
        {
            // Calcular el primer día de la semana (lunes)
            DateTime startOfWeek = currentDate.AddDays(-((int)currentDate.DayOfWeek - (int)DayOfWeek.Monday));

            // Limpiar el DataGridView
            for (int col = 1; col < 6; col++)
            {
                dgvProxClas.Columns[col].HeaderText = $"{startOfWeek.AddDays(col - 1):dd/MM} - {startOfWeek.AddDays(col - 1).ToString("dddd", new CultureInfo("es-ES"))}";
            }

            // Si quieres cambiar los días para que cambien cuando se avance o retroceda de semana:
            for (int col = 1; col <= 5; col++)
            {
                dgvProxClas.Columns[col].HeaderText = $"{startOfWeek.AddDays(col - 1):dd/MM} - {startOfWeek.AddDays(col - 1).ToString("dddd", new CultureInfo("es-ES"))}";
            }
        }
        private int GetRowForHour(TimeSpan hora)
        {
            string[] horas = { "8:00", "9:00", "10:00", "11:00", "12:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" };
            for (int i = 0; i < horas.Length; i++)
            {
                if (hora == TimeSpan.Parse(horas[i]))
                {
                    return i;  // Regresa la fila correspondiente a la hora
                }
            }
            return -1; // Si no se encuentra, retornar -1
        }

        private void LoadClasesToGrid()
        {
            dbQuery db = new dbQuery();

            // Calcular el primer día de la semana (lunes) basado en la fecha actual
            DateTime startOfWeek = currentDate.AddDays(-((int)currentDate.DayOfWeek - (int)DayOfWeek.Monday));

            for (int col = 1; col <= 5; col++)  // Llenamos columnas de lunes a viernes
            {
                DateTime diaSemana = startOfWeek.AddDays(col - 1);
                string query = @"
SELECT c.NombreClase, c.HoraInicio, c.HoraFin, c.CupoMaximo, c.FechaClase, 
       COUNT(i.InscripcionID) AS CuposOcupados 
FROM Clases c 
LEFT JOIN Inscripciones i ON c.ClaseID = i.ClaseID 
WHERE c.FechaClase = @FechaClase 
GROUP BY c.NombreClase, c.HoraInicio, c.HoraFin, c.CupoMaximo, c.FechaClase";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@FechaClase", diaSemana.Date)
                };

                DataTable dtClases = db.GetDataTable(query, parameters);

                // Limpiar las celdas de clases para el día actual
                for (int row = 0; row < dgvProxClas.RowCount; row++)
                {
                    dgvProxClas.Rows[row].Cells[col].Value = null; // Limpiar valores previos
                }

                // Si no hay clases, mostrar mensaje de depuración
                if (dtClases == null || dtClases.Rows.Count == 0)
                {
                    Console.WriteLine($"No se encontraron clases para: {diaSemana.ToString("dd/MM/yyyy")}");
                }
                else
                {
                    // Llenar el DataGridView con las clases para el día actual
                    foreach (DataRow row in dtClases.Rows)
                    {
                        string nombreClase = row["NombreClase"].ToString();
                        int cupoMaximo = Convert.ToInt32(row["CupoMaximo"]);
                        int cuposOcupados = Convert.ToInt32(row["CuposOcupados"]);

                        // Mostrar solo el nombre de la clase y los cupos ocupados en el formato adecuado
                        string claseInfo = $"{nombreClase} ({cuposOcupados}/{cupoMaximo})";  // Formato requerido

                        // Agregar la clase en la celda correspondiente
                        dgvProxClas.Rows[GetRowForHour((TimeSpan)row["HoraInicio"])].Cells[col].Value = claseInfo;
                    }
                }
            }
        }
    



        private void btnAnterior_Click_1(object sender, EventArgs e)
        {

            // Retroceder una semana
            currentDate = currentDate.AddDays(-7);
            UpdateCalendar();  // Actualiza los días de la grilla
            LoadClasesToGrid();  // Carga las clases para la nueva semana
        }

        private void btnSiguiente_Click_1(object sender, EventArgs e)
        {

            // Avanzar una semana
            currentDate = currentDate.AddDays(7);
            UpdateCalendar();  // Actualiza los días de la grilla
            LoadClasesToGrid();  // Carga las clases para la nueva semana
        }

































        private void LimpiarCampos()
        {
            cmbCategoriaGasto.SelectedIndex = -1;
            txtMonto.Clear();
            txtObservacion.Clear();
            radiobuttonEfectivo.Checked = false;
            radiobuttonTransferencia.Checked = false;
        }

        private void cmbCategoriaGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void guna2CustomRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
        }

        private void radiobuttonEfectivo_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
        }
        private void CargarClientesActivos()
        {
            try
            {
                // Consulta SQL para obtener clientes activos (los que pagaron en los últimos 30 días)
                string query = @"
            SELECT COUNT(*) AS ClientesActivos
            FROM Clientes
            WHERE FechaUltimoPago >= DATEADD(DAY, -30, GETDATE())";

                // Ejecutar la consulta y obtener el resultado
                dbQuery db = new dbQuery();
                object result = db.ExecuteScalar(query);

                if (result != null && int.TryParse(result.ToString(), out int clientesActivos))
                {
                    // Mostrar la cantidad de clientes activos en el label
                    lblClientesActivos.Text = $"Clientes activos: {clientesActivos}";
                }
                else
                {
                    lblClientesActivos.Text = "Clientes activos: ! ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los clientes activos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificamos si se ha seleccionado un gasto
                if (gastoIdSeleccionado == 0)
                {
                    MessageBox.Show("Por favor, seleccione un gasto para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Preguntamos al usuario si está seguro de eliminar el gasto
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar este gasto?", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Consulta SQL para eliminar el gasto
                    string query = "DELETE FROM Gastos WHERE GastoID = @GastoID";

                    // Creamos los parámetros para la consulta
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                new SqlParameter("@GastoID", gastoIdSeleccionado)
                    };

                    // Ejecutamos la consulta
                    dbQuery db = new dbQuery();
                    int rowsAffected = db.ExecuteNonQuery(query, parameters);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Gasto eliminado con éxito.");
                        CargarGastos(); // Recargamos los gastos en la grilla
                        LimpiarCampos(); // Limpiamos los campos
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al eliminar el gasto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el gasto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void dgvGastos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos si se ha hecho clic en una fila válida (no en los encabezados)
            if (e.RowIndex >= 0)
            {
                // Obtenemos los valores de las celdas seleccionadas
                DataGridViewRow row = dgvGastos.Rows[e.RowIndex];
                gastoIdSeleccionado = Convert.ToInt32(row.Cells["GastoID"].Value);  // Guardamos el GastoID

                string categoria = row.Cells["Categoria"].Value.ToString();
                decimal monto = Convert.ToDecimal(row.Cells["Monto"].Value);
                string metodoPago = row.Cells["MetodoPago"].Value.ToString();
                string observacion = row.Cells["Observacion"].Value.ToString();

                // Cargamos los valores en los controles correspondientes
                cmbCategoriaGasto.SelectedItem = categoria;
                txtMonto.Text = monto.ToString();
                txtObservacion.Text = observacion;

                // Establecemos el método de pago en el control adecuado
                if (metodoPago == "Efectivo")
                    radiobuttonEfectivo.Checked = true;
                else
                    radiobuttonTransferencia.Checked = true;
            }
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificamos si se ha seleccionado un gasto
                if (gastoIdSeleccionado == 0)
                {
                    MessageBox.Show("Por favor, seleccione un gasto para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string categoria = cmbCategoriaGasto.SelectedItem.ToString();
                decimal monto = Convert.ToDecimal(txtMonto.Text);
                string metodoPago = radiobuttonEfectivo.Checked ? "Efectivo" : "Transferencia";
                string observacion = txtObservacion.Text;

                // Consulta SQL para modificar el gasto
                string query = "UPDATE Gastos SET Categoria = @Categoria, Monto = @Monto, MetodoPago = @MetodoPago, Observacion = @Observacion WHERE GastoID = @GastoID";

                // Creamos los parámetros para la consulta
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@GastoID", gastoIdSeleccionado),
            new SqlParameter("@Categoria", categoria),
            new SqlParameter("@Monto", monto),
            new SqlParameter("@MetodoPago", metodoPago),
            new SqlParameter("@Observacion", observacion)
                };

                // Ejecutamos la consulta
                dbQuery db = new dbQuery();
                int result = db.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Gasto modificado con éxito.");
                    CargarGastos(); // Recargamos los gastos en la grilla
                    LimpiarCampos(); // Limpiamos los campos
                }
                else
                {
                    MessageBox.Show("Hubo un error al modificar el gasto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el gasto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGastos()
        {
            try
            {
                // Consulta para obtener los gastos de la base de datos
                string query = "SELECT GastoID, Categoria, Monto, FechaGasto, MetodoPago, Observacion FROM Gastos";

                // Usamos el dbQuery para ejecutar la consulta
                dbQuery db = new dbQuery();
                DataTable dtGastos = db.GetDataTable(query); // Obtener los datos

                // Asignamos los datos obtenidos a la grilla
                dgvGastos.DataSource = dtGastos;

                // Opcional: Configuramos las columnas para mostrar los datos de forma más clara
                dgvGastos.Columns["GastoID"].Visible = false; // Ocultar el ID del gasto en la grilla
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los gastos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnCargarGasto_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validar los campos antes de continuar
                if (cmbCategoriaGasto.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione una categoría de gasto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMonto.Text) || !decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
                {
                    MessageBox.Show("Ingrese un monto válido mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!radiobuttonEfectivo.Checked && !radiobuttonTransferencia.Checked)
                {
                    MessageBox.Show("Seleccione un método de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los valores de los controles
                string categoria = cmbCategoriaGasto.SelectedItem.ToString();
                DateTime fechaGasto = DateTime.Now; // Fecha actual
                string metodoPago = radiobuttonEfectivo.Checked ? "Efectivo" : "Otro";
                string observacion = txtObservacion.Text;

                // Crear la consulta SQL para insertar el gasto
                string query = "INSERT INTO Gastos (Categoria, Monto, FechaGasto, MetodoPago, Observacion) " +
                               "VALUES (@Categoria, @Monto, @FechaGasto, @MetodoPago, @Observacion)";

                // Crear los parámetros
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Categoria", categoria),
                    new SqlParameter("@Monto", monto),
                    new SqlParameter("@FechaGasto", fechaGasto),
                    new SqlParameter("@MetodoPago", metodoPago),
                    new SqlParameter("@Observacion", observacion)
                };

                // Ejecutar la consulta
                dbQuery db = new dbQuery();
                int result = db.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Gasto registrado con éxito.");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Hubo un error al registrar el gasto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el gasto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtObservacion_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
