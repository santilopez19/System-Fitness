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
    public partial class Inicio : UserControl
    {
        public Inicio()
        {
            InitializeComponent();
            cmbCategoriaGasto.Items.Add("Comida");
            cmbCategoriaGasto.Items.Add("Suplementos");
            cmbCategoriaGasto.Items.Add("Infraestructura");
            cmbCategoriaGasto.Items.Add("Sueldos");
        }


        private void btnCargarGasto_Click(object sender, EventArgs e)
        {

            // Obtener los valores de los controles
            string categoria = cmbCategoriaGasto.SelectedItem.ToString();
            decimal monto = decimal.Parse(txtMonto.Text);
            DateTime fechaGasto = DateTime.Now; // Fecha actual
            string metodoPago = radiobuttonEfectivo.Checked ? "Efectivo" : "Otro"; // Dependiendo del método seleccionado
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
            }
            else
            {
                MessageBox.Show("Hubo un error al registrar el gasto.");
            }
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
    }
}
