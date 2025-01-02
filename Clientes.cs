using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace System_Fitness
{
    public partial class Clientes : UserControl
    {
        dbQuery query = new dbQuery();
        private int clienteIDSeleccionado = -1; // Reinicia la referencia al cliente seleccionado

        public Clientes()
        {
            InitializeComponent();
            cmbSexo.Items.Add("M");
            cmbSexo.Items.Add("F");
            dgvClientes.CellClick += dgvClientes_CellClick;
            dgvClientes.AllowUserToAddRows = false;
            CargarClientes(); // Recargar los datos en la grilla

        }


        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDni.Text = string.Empty;
            cmbSexo.SelectedIndex = -1;
            dtpFechaNac.Value = DateTime.Now;
            dtpFechaIngreso.Value = DateTime.Now;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void CargarClientesDesdeCache()
        {
            try
            {
                DataTable clientes = query.GetDataTable("SELECT * FROM Clientes");

                if (clientes != null && clientes.Rows.Count > 0)
                {
                    dgvClientes.DataSource = clientes;
                }
                else
                {
                    MessageBox.Show("No se encontraron clientes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(filtro))
            {
                try
                {
                    string queryText = "SELECT * FROM Clientes WHERE Nombre LIKE @Filtro OR Apellido LIKE @Filtro OR DNI LIKE @Filtro";
                    var parameters = new[] { new SqlParameter("@Filtro", $"%{filtro}%") };

                    DataTable clientesFiltrados = query.GetDataTable(queryText, parameters);
                    dgvClientes.DataSource = clientesFiltrados;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar clientes: {ex.Message}");
                }
            }
            else
            {
                CargarClientesDesdeCache();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteIDSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.");
                return;
            }

            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea eliminar a este cliente? Se eliminarán todos los registros relacionados.",
                                                            "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection connection = query.GetConnection();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string deleteRutinasQuery = "DELETE FROM Rutinas WHERE ClienteID = @ClienteID";
                        string deletePagosQuery = "DELETE FROM Pagos WHERE ClienteID = @ClienteID";
                        var parameters = new[] { new SqlParameter("@ClienteID", clienteIDSeleccionado) };

                        query.ExecuteNonQuery(deleteRutinasQuery, parameters, transaction);
                        query.ExecuteNonQuery(deletePagosQuery, parameters, transaction);

                        string deleteClienteQuery = "DELETE FROM Clientes WHERE ClienteID = @ClienteID";
                        query.ExecuteNonQuery(deleteClienteQuery, parameters, transaction);

                        transaction.Commit();
                        MessageBox.Show("Cliente y todos los registros relacionados eliminados exitosamente.");

                        // Eliminar el cliente de la grilla
                        foreach (DataGridViewRow row in dgvClientes.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["ClienteID"].Value) == clienteIDSeleccionado)
                            {
                                dgvClientes.Rows.Remove(row);
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error al eliminar cliente: {ex.Message}");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Eliminación cancelada.");
                }
                CargarClientes(); // Recargar los datos en la grilla

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el cliente: {ex.Message}");
            }
        }


        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClientes.Rows[e.RowIndex];
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                txtDni.Text = row.Cells["DNI"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                cmbSexo.SelectedItem = row.Cells["Sexo"].Value.ToString();
                dtpFechaNac.Value = Convert.ToDateTime(row.Cells["FechaNacimiento"].Value);
                dtpFechaIngreso.Value = Convert.ToDateTime(row.Cells["FechaIngreso"].Value);
                clienteIDSeleccionado = Convert.ToInt32(row.Cells["ClienteID"].Value);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (clienteIDSeleccionado == -1)
            {
                MessageBox.Show("No hay ningún cliente seleccionado para modificar.");
                return;
            }

            try
            {
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string dni = txtDni.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim();
                string sexo = cmbSexo.SelectedItem?.ToString();
                DateTime fechaNacimiento = dtpFechaNac.Value;

                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(sexo))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                    return;
                }

                string queryText = "UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Telefono = @Telefono, Email = @Email, Sexo = @Sexo, FechaNacimiento = @FechaNacimiento WHERE ClienteID = @ClienteID";
                var parameters = new[] {
            new SqlParameter("@Nombre", nombre),
            new SqlParameter("@Apellido", apellido),
            new SqlParameter("@DNI", dni),
            new SqlParameter("@Telefono", telefono),
            new SqlParameter("@Email", email),
            new SqlParameter("@Sexo", sexo),
            new SqlParameter("@FechaNacimiento", fechaNacimiento),
            new SqlParameter("@ClienteID", clienteIDSeleccionado)
        };

                query.ExecuteNonQuery(queryText, parameters);

                // Actualizar la fila correspondiente en la grilla
                foreach (DataGridViewRow row in dgvClientes.Rows)
                {
                    if (Convert.ToInt32(row.Cells["ClienteID"].Value) == clienteIDSeleccionado)
                    {
                        row.Cells["Nombre"].Value = nombre;
                        row.Cells["Apellido"].Value = apellido;
                        row.Cells["DNI"].Value = dni;
                        row.Cells["Telefono"].Value = telefono;
                        row.Cells["Email"].Value = email;
                        row.Cells["Sexo"].Value = sexo;
                        row.Cells["FechaNacimiento"].Value = fechaNacimiento.ToString("yyyy-MM-dd");
                        break;
                    }
                }
                CargarClientes(); // Recargar los datos en la grilla

                MessageBox.Show("Cliente modificado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el cliente: {ex.Message}");
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            clienteIDSeleccionado = -1;
            CargarClientes(); // Recargar los datos en la grilla

        }

        public void CargarClientes()
        {
            // Modificar la consulta SQL para incluir las columnas faltantes
            string query = "SELECT ClienteID, Nombre, Apellido, DNI, Sexo, FechaNacimiento, Email, Telefono, UsuarioWeb, ContraseñaWeb, FechaIngreso FROM Clientes";

            // Crear la instancia de dbQuery
            dbQuery db = new dbQuery();

            // Ahora puedes llamar al método GetDataTable con la instancia de dbQuery
            DataTable dtClientes = db.GetDataTable(query);

            if (dtClientes != null && dtClientes.Rows.Count > 0)
            {
                dgvClientes.DataSource = dtClientes;
            }
            else
            {
                MessageBox.Show("No se encontraron clientes.");
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

            // Validar que todos los campos tengan datos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(cmbSexo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                dtpFechaNac.Value == null ||
                dtpFechaIngreso.Value == null)
            {
                MessageBox.Show("Todos los campos son obligatorios. Por favor, complételos antes de continuar.");
                return;
            }

            // Si pasa la validación, proceder a crear el cliente
            try
            {
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string dni = txtDni.Text.Trim();
                string sexo = cmbSexo.Text.Trim();
                DateTime fechaNacimiento = dtpFechaNac.Value;
                DateTime fechaIngreso = dtpFechaIngreso.Value;
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim();

                // Crear el nombre de usuario y contraseña
                string usuario = nombre.Substring(0, 1).ToLower() + apellido.ToLower() + dni.Substring(0, 2);
                string contrasena = nombre.Substring(0, 1).ToLower() + dni;

                // Query para insertar el cliente
                string queryText = "INSERT INTO Clientes (Nombre, Apellido, DNI, Sexo, FechaNacimiento, FechaIngreso, Telefono, Email, UsuarioWeb, ContraseñaWeb) " +
                                   "VALUES (@Nombre, @Apellido, @DNI, @Sexo, @FechaNacimiento, @FechaIngreso, @Telefono, @Email, @UsuarioWeb, @ContraseñaWeb)";
                var parameters = new[] {
            new SqlParameter("@Nombre", nombre),
            new SqlParameter("@Apellido", apellido),
            new SqlParameter("@DNI", dni),
            new SqlParameter("@Sexo", sexo),
            new SqlParameter("@FechaNacimiento", fechaNacimiento),
            new SqlParameter("@FechaIngreso", fechaIngreso),
            new SqlParameter("@Telefono", telefono),
            new SqlParameter("@Email", email),
            new SqlParameter("@UsuarioWeb", usuario),
            new SqlParameter("@ContraseñaWeb", contrasena)
        };

                // Ejecutar la consulta
                query.ExecuteNonQuery(queryText, parameters);

                // Obtener el ID del nuevo cliente (asumiendo que es autoincremental)
                SqlConnection connection = query.GetConnection();
                SqlCommand cmd = new SqlCommand("SELECT SCOPE_IDENTITY()", connection);
                connection.Open();
                int clienteID = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();

                // Agregar el nuevo cliente directamente a la grilla
                dgvClientes.Rows.Add(clienteID, nombre, apellido, dni, sexo, fechaNacimiento.ToString("yyyy-MM-dd"), fechaIngreso.ToString("yyyy-MM-dd"), telefono, email, usuario);

                MessageBox.Show("Cliente creado exitosamente.");
                LimpiarCampos();
                CargarClientes(); // Recargar los datos en la grilla
            }
            catch
            {
                CargarClientes();
            }
        }
    }
}
