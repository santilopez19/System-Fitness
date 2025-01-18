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
    public partial class Calendario : UserControl
    {
        public Calendario()
        {
            InitializeComponent();
            CargarClasesPredeterminadas();
            LoadClasesToGrid();
            CargarHorarios();
            dgvClases.AllowUserToAddRows = false;
        }

        private DateTime currentDate;

        private void dgvClases_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadClasesToGrid()
        {
            try
            {
                dbQuery db = new dbQuery();
                string query = "SELECT ClaseID, NombreClase, FechaClase, HoraInicio, HoraFin, CupoMaximo, Dia FROM Clases ORDER BY FechaClase, HoraInicio";

                // Ejecutar la consulta y recuperar el DataTable
                DataTable dt = db.ExecuteQuery(query); // Asegúrate de que ExecuteQuery devuelve un DataTable

                // Asignar el DataTable al DataGridView
                dgvClases.DataSource = dt;

                // Refrescar la grilla
                dgvClases.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las clases: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Calendario_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una clase en la grilla
            if (dgvClases.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor selecciona una clase para eliminar.");
                return;
            }

            // Obtener el ID de la clase seleccionada en la grilla
            int claseID = Convert.ToInt32(dgvClases.SelectedRows[0].Cells["ClaseID"].Value);

            // Crear la consulta para eliminar la clase
            string query = "DELETE FROM Clases WHERE ClaseID = @ClaseID";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@ClaseID", claseID)
            };

            dbQuery db = new dbQuery();
            int result = db.ExecuteNonQuery(query, parameters);

            if (result > 0)
            {
                MessageBox.Show("Clase eliminada con éxito.");
                LoadClasesToGrid(); // Recargar la grilla
            }
            else
            {
                MessageBox.Show("Error al eliminar la clase.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCupo.Text) || cmbHorario.SelectedItem == null || cmbClase.SelectedItem == null)
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            // Obtener el ID de la clase seleccionada en la grilla (suponiendo que tienes una columna con el ID)
            int claseID = Convert.ToInt32(dgvClases.SelectedRows[0].Cells["ClaseID"].Value);

            // Crear la consulta para modificar la clase
            string query = @"
    UPDATE Clases
    SET NombreClase = @NombreClase,
        HoraInicio = @HoraInicio,
        HoraFin = @HoraFin,
        CupoMaximo = @CupoMaximo,
        FechaClase = @FechaClase
    WHERE ClaseID = @ClaseID";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@NombreClase", cmbClase.SelectedItem.ToString()),
        new SqlParameter("@HoraInicio", cmbHorario.SelectedItem.ToString()), // Puedes convertir a Time si es necesario
        new SqlParameter("@HoraFin", cmbHorario.SelectedItem.ToString()), // Usa el mismo formato para hora de fin
        new SqlParameter("@CupoMaximo", txtCupo.Text),
        new SqlParameter("@FechaClase", dtpFechaClase.Value.Date),
        new SqlParameter("@ClaseID", claseID)
            };

            dbQuery db = new dbQuery();
            int result = db.ExecuteNonQuery(query, parameters); // Método que ejecuta una consulta sin resultados

            if (result > 0)
            {
                MessageBox.Show("Clase modificada con éxito.");
                LoadClasesToGrid(); // Recargar la grilla
            }
            else
            {
                MessageBox.Show("Error al modificar la clase.");
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

            try
            {
                string nombreClase = cmbClase.Text;
                string horaClase = cmbHorario.Text;
                DateTime fechaClase = dtpFechaClase.Value;
                int cupoMaximo;

                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(nombreClase) || string.IsNullOrWhiteSpace(horaClase) || !int.TryParse(txtCupo.Text, out cupoMaximo) || cupoMaximo <= 0)
                {
                    MessageBox.Show("Por favor, complete todos los campos correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que no sea sábado o domingo
                if (fechaClase.DayOfWeek == DayOfWeek.Saturday || fechaClase.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("No se pueden crear clases los fines de semana.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar si ya existe una clase en esa fecha y hora
                if (ClaseYaExiste(fechaClase, horaClase))
                {
                    MessageBox.Show("Ya existe una clase programada en esa fecha y hora.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insertar la clase en la base de datos
                InsertarClaseEnBaseDatos(nombreClase, fechaClase, horaClase, cupoMaximo);

                // Recargar la grilla
                LoadClasesToGrid(); // Asegúrate de que esta línea se ejecute


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la clase: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarClasesPredeterminadas()
        {
            List<string> clasesPredeterminadas = new List<string>
            {
                "Yoga",
                "Zumba",
                "Pilates",
                "Spinning",
                "CrossFit"
            };

            cmbClase.DataSource = clasesPredeterminadas;
        }
        private void CargarHorarios()
        {
            List<string> horarios = new List<string>
            {
                "08:00", "09:00", "10:00", "11:00", "12:00",
                "16:00", "17:00", "18:00", "19:00", "20:00"
            };

            cmbHorario.DataSource = horarios;
        }



        private void dgvClasess_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verificar que no sea un encabezado
            {
                // Obtener la fila seleccionada
                DataGridViewRow row = dgvClases.Rows[e.RowIndex];

                // Completar los campos con los valores de la fila
                cmbClase.Text = row.Cells["NombreClase"].Value?.ToString() ?? string.Empty;
                cmbHorario.Text = TimeSpan.Parse(row.Cells["HoraInicio"].Value?.ToString() ?? "00:00").ToString(@"hh\:mm");

                txtCupo.Text = row.Cells["CupoMaximo"].Value?.ToString() ?? string.Empty;

                if (DateTime.TryParse(row.Cells["FechaClase"].Value?.ToString(), out DateTime fecha))
                {
                    dtpFechaClase.Value = fecha;
                }
                else
                {
                    dtpFechaClase.Value = DateTime.Now; // Valor predeterminado si no hay una fecha válida
                }
            }
        }


        private void InsertarClaseEnBaseDatos(string nombreClase, DateTime fecha, string hora, int cupoMaximo)
        {
            try
            {
                dbQuery db = new dbQuery();
                string query = "INSERT INTO Clases (NombreClase, FechaClase, HoraInicio, HoraFin, CupoMaximo, Dia) " +
                               "VALUES (@NombreClase, @FechaClase, @HoraInicio, @HoraFin, @CupoMaximo, @Dia)";

                // Calcular el día de la semana en español
                string diaSemana = fecha.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));

                // Validar y convertir hora
                TimeSpan horaInicio = TimeSpan.Parse(hora);
                TimeSpan horaFin = horaInicio.Add(new TimeSpan(1, 0, 0)); // Duración de la clase: 1 hora

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@NombreClase", nombreClase),
            new SqlParameter("@FechaClase", fecha),
            new SqlParameter("@HoraInicio", horaInicio),
            new SqlParameter("@HoraFin", horaFin),
            new SqlParameter("@CupoMaximo", cupoMaximo),
            new SqlParameter("@Dia", diaSemana)
                };

                int rowsAffected = db.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Clase insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se insertó ninguna fila en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private bool ClaseYaExiste(DateTime fecha, string hora)
        {
            dbQuery db = new dbQuery();
            string query = "SELECT COUNT(*) FROM Clases WHERE FechaClase = @FechaClase AND HoraInicio = @HoraInicio";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@FechaClase", fecha.Date),
        new SqlParameter("@HoraInicio", TimeSpan.Parse(hora))
            };

            int count = Convert.ToInt32(db.ExecuteScalar(query, parameters));
            return count > 0;
        }
        private void cmbClase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaClaseClase_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCupo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
