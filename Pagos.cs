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
    public partial class Pagos : UserControl
    {
        public Pagos()
        {
            InitializeComponent();
            CargarPagos();
            // En el constructor o donde inicialices el DataGridView
            dgvPagos.AllowUserToAddRows = false;

        }

        private void lblMonto_Click(object sender, EventArgs e)
        {

        }
        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            
        }

        // Método para insertar el pago
        private void btnCargarPago_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el monto ingresado en el txtMonto
                decimal monto = Convert.ToDecimal(txtMonto.Text);

                // Verificar si el monto es válido
                if (monto <= 0)
                {
                    MessageBox.Show("Por favor ingrese un monto válido.");
                    return;
                }

                // Obtener el DNI del cliente desde txtDniCliente
                string dniCliente = txtDniCliente.Text.Trim();

                // Validar que se haya ingresado un DNI
                if (string.IsNullOrEmpty(dniCliente))
                {
                    MessageBox.Show("Por favor ingrese el DNI del cliente.");
                    return;
                }

                // Determinar el método de pago seleccionado
                string metodoPago = string.Empty;

                if (rbEfect.Checked)
                {
                    metodoPago = "Efectivo";
                }
                else if (rbTransfe.Checked)
                {
                    metodoPago = "Transferencia";
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un método de pago.");
                    return;
                }

                // Asegurarse de que el DNI existe en la base de datos (puedes usar una consulta para verificar)
                dbQuery db = new dbQuery();
                string query = "SELECT COUNT(*) FROM Clientes WHERE DNI = @DNI";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@DNI", dniCliente)
                };

                int clienteCount = Convert.ToInt32(db.ExecuteScalar(query, parameters));

                if (clienteCount == 0)
                {
                    MessageBox.Show("El DNI ingresado no corresponde a ningún cliente.");
                    return;
                }

                // Crear la fecha de pago (puedes usar la fecha actual)
                DateTime fechaPago = DateTime.Now;

                // Insertar el pago en la base de datos utilizando el DNI directamente
                query = "INSERT INTO Pagos (ClienteID, FechaPago, Monto, MetodoPago, DNI) " +
                        "VALUES ((SELECT ClienteID FROM Clientes WHERE DNI = @DNI), @FechaPago, @Monto, @MetodoPago, @DNI);";

                SqlParameter[] insertParameters = new SqlParameter[]
                {
            new SqlParameter("@DNI", dniCliente),
            new SqlParameter("@FechaPago", fechaPago),
            new SqlParameter("@Monto", monto),
            new SqlParameter("@MetodoPago", metodoPago)
                };

                int resultado = db.ExecuteNonQuery(query, insertParameters);

                // Verificar el resultado
                if (resultado > 0)
                {
                    MessageBox.Show("Pago cargado exitosamente.");
                    LimpiarCampos();
                    CargarPagos();
                }
                else
                {
                    MessageBox.Show("Hubo un error al cargar el pago.");
                }
            }
            catch (Exception ex)
            {
                // Mostrar el error completo en el mensaje de la excepción
                MessageBox.Show($"Error: {ex.Message}\n\nDetalles: {ex.StackTrace}");
            }
            
        }



        private void LimpiarCampos()
        {
            // Limpiar los campos
            txtDniCliente.Clear();
            txtMonto.Clear();
            rbEfect.Checked = false;
            rbTransfe.Checked = false;
        }
        private void CargarPagos()
        {
            try
            {
                dbQuery db = new dbQuery();
                string query = "SELECT PagoID, DNI, Monto, MetodoPago, FechaPago FROM Pagos"; // Ajusta la consulta según tus necesidades

                DataTable dtPagos = db.GetDataTable(query);

                // Asigna los datos a la grilla
                dgvPagos.DataSource = dtPagos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pagos: {ex.Message}");
            }
        }



        private void txtDniCliente_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void rbEfect_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEfect.Checked)
            {
                rbTransfe.Checked = false;
            }
        }

        private void rbTransfe_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTransfe.Checked)
            {
                rbEfect.Checked = false;
            }
        }
        private void dgvPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verifica que la fila seleccionada no sea la cabecera
                if (e.RowIndex >= 0)
                {
                    // Obtiene la fila seleccionada
                    DataGridViewRow row = dgvPagos.Rows[e.RowIndex];

                    // Carga los datos de la fila en los controles
                    txtMonto.Text = row.Cells["Monto"].Value.ToString();
                    txtDniCliente.Text = row.Cells["DNI"].Value.ToString();

                    // Determina el método de pago y marca el radio button correspondiente
                    string metodoPago = row.Cells["MetodoPago"].Value.ToString();
                    if (metodoPago == "Efectivo")
                    {
                        rbEfect.Checked = true;
                    }
                    else if (metodoPago == "Transferencia")
                    {
                        rbTransfe.Checked = true;
                    }

                    // Si necesitas la fecha de pago:
                    // txtFechaPago.Text = Convert.ToDateTime(row.Cells["FechaPago"].Value).ToString("yyyy-MM-dd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        private void txtModificarPago_Click(object sender, EventArgs e)
        {
                try
                {
                    // Obtener los valores de los campos de texto
                    decimal monto = Convert.ToDecimal(txtMonto.Text);
                    string dniCliente = txtDniCliente.Text.Trim();
                    string metodoPago = rbEfect.Checked ? "Efectivo" : "Transferencia";
                    DateTime fechaPago = DateTime.Now; // O la fecha seleccionada, si la tienes en otro control

                    // Verificar que los campos obligatorios no estén vacíos
                    if (string.IsNullOrEmpty(dniCliente) || monto <= 0)
                    {
                        MessageBox.Show("Por favor complete todos los campos.");
                        return;
                    }

                    // Modificar el pago en la base de datos (asumiendo que tienes el PagoID en algún lugar)
                    int pagoId = Convert.ToInt32(dgvPagos.SelectedRows[0].Cells["PagoID"].Value);

                    // Ejecutar la actualización en la base de datos
                    dbQuery db = new dbQuery();
                    string query = "UPDATE Pagos SET Monto = @Monto, MetodoPago = @MetodoPago, FechaPago = @FechaPago " +
                                   "WHERE PagoID = @PagoID AND DNI = @DNI";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
            new SqlParameter("@PagoID", pagoId),
            new SqlParameter("@Monto", monto),
            new SqlParameter("@MetodoPago", metodoPago),
            new SqlParameter("@FechaPago", fechaPago),
            new SqlParameter("@DNI", dniCliente)
                    };

                    int resultado = db.ExecuteNonQuery(query, parameters);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Pago modificado correctamente.");
                        // Opcional: Refrescar la grilla para mostrar los cambios
                        CargarPagos(); // Suponiendo que tengas un método para recargar la grilla
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al modificar el pago.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }

        }

        private void txtFiltroPago_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Obtener el valor del texto que el usuario ha ingresado
                string filtroDNI = txtFiltroPago.Text.Trim();

                // Si el filtro está vacío, mostrar todos los pagos
                if (string.IsNullOrEmpty(filtroDNI))
                {
                    CargarPagos(); // Método que recarga todos los pagos
                }
                else
                {
                    // Filtrar pagos por DNI
                    dbQuery db = new dbQuery();
                    string query = "SELECT PagoID, DNI, Monto, MetodoPago, FechaPago " +
                                   "FROM Pagos " +
                                   "WHERE DNI LIKE @FiltroDNI"; // Utilizamos LIKE para hacer una búsqueda parcial

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                new SqlParameter("@FiltroDNI", "%" + filtroDNI + "%") // El % al principio y al final permite buscar cualquier parte del texto
                    };

                    // Obtener los pagos filtrados
                    DataTable dtPagos = db.GetDataTable(query, parameters);

                    // Asignar los pagos filtrados a la grilla
                    dgvPagos.DataSource = dtPagos;
                }
            }
            catch
            {
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado alguna fila en la grilla
                if (dgvPagos.SelectedRows.Count > 0)
                {
                    // Obtener el PagoID del pago seleccionado
                    int pagoId = Convert.ToInt32(dgvPagos.SelectedRows[0].Cells["PagoID"].Value);

                    // Confirmar la eliminación
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este pago?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        // Ejecutar la consulta para eliminar el pago de la base de datos
                        dbQuery db = new dbQuery();
                        string query = "DELETE FROM Pagos WHERE PagoID = @PagoID";

                        SqlParameter[] parameters = new SqlParameter[]
                        {
                    new SqlParameter("@PagoID", pagoId)
                        };

                        int rowsAffected = db.ExecuteNonQuery(query, parameters);

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Pago eliminado correctamente.");
                            // Opcional: Refrescar la grilla para mostrar los cambios
                            CargarPagos(); // Llamar al método que recarga los pagos
                        }
                        else
                        {
                            MessageBox.Show("Hubo un problema al eliminar el pago.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un pago para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el pago: {ex.Message}");
            }
        }

    }
}
