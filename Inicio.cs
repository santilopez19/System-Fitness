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
            // Calcular el lunes de la semana actual
            DateTime startOfWeek = currentDate.AddDays(-((int)currentDate.DayOfWeek - (int)DayOfWeek.Monday));

            // Actualizar los encabezados de las columnas
            for (int col = 1; col <= 5; col++)
            {
                DateTime diaSemana = startOfWeek.AddDays(col - 1);
                dgvProxClas.Columns[col].HeaderText = $"{diaSemana:dd/MM} - {diaSemana.ToString("dddd", new CultureInfo("es-ES"))}";
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

            for (int col = 1; col <= 5; col++) // Llenamos columnas de lunes a viernes
            {
                DateTime diaSemana = startOfWeek.AddDays(col - 1);

                string query = @"
        SELECT c.NombreClase, c.HoraInicio, c.HoraFin, c.CupoMaximo, c.FechaClase, 
               COUNT(i.InscripcionID) AS CuposOcupados
        FROM Clases c
        LEFT JOIN Inscripciones i ON c.ClaseID = i.ClaseID
        WHERE CAST(c.FechaClase AS DATE) = @FechaClase
        GROUP BY c.NombreClase, c.HoraInicio, c.HoraFin, c.CupoMaximo, c.FechaClase";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@FechaClase", diaSemana.Date) // Comparar la fecha exacta
                };

                DataTable dtClases = db.GetDataTable(query, parameters);

                // Limpiar las celdas de clases para el día actual
                for (int row = 0; row < dgvProxClas.RowCount; row++)
                {
                    dgvProxClas.Rows[row].Cells[col].Value = null; // Limpiar valores previos
                }

                if (dtClases != null && dtClases.Rows.Count > 0)
                {
                    foreach (DataRow row in dtClases.Rows)
                    {
                        string nombreClase = row["NombreClase"].ToString();
                        int cupoMaximo = Convert.ToInt32(row["CupoMaximo"]);
                        int cuposOcupados = Convert.ToInt32(row["CuposOcupados"]);
                        TimeSpan horaInicio = (TimeSpan)row["HoraInicio"];

                        // Construir el formato "ZUMBA 5/10"
                        string claseInfo = $"{nombreClase.ToUpper()} {cuposOcupados}/{cupoMaximo}";

                        // Obtener la fila correspondiente a la hora
                        int fila = GetRowForHour(horaInicio);

                        if (fila >= 0)
                        {
                            dgvProxClas.Rows[fila].Cells[col].Value = claseInfo;
                        }
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

















        private void CargarClientesActivos()
        {
            try
            {
                // Consulta SQL con JOIN
                string query = @"
            SELECT COUNT(DISTINCT Clientes.ClienteID) AS ClientesActivos
            FROM Clientes
            INNER JOIN Pagos ON Clientes.ClienteID = Pagos.ClienteID
            WHERE Pagos.FechaPago >= DATEADD(DAY, -30, GETDATE())";

                // Ejecutar la consulta
                dbQuery db = new dbQuery();
                object result = db.ExecuteScalar(query);

                if (result != null && int.TryParse(result.ToString(), out int clientesActivos))
                {
                    lblClientesActivos.Text = $"Clientes activos: {clientesActivos}";
                }
                else
                {
                    lblClientesActivos.Text = "Clientes activos: 0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los clientes activos: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






















        private void LimpiarCampos()
        {
            cmbCategoriaGasto.SelectedIndex = -1;
            txtMonto.Clear();
            txtObservacion.Clear();
            radiobuttonEfectivo.Checked = false;
            radiobuttonTransferencia.Checked = false;
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

        private void btnModificar_Click_1(object sender, EventArgs e)
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

        private void btnEliminar_Click_1(object sender, EventArgs e)
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
    }
}
