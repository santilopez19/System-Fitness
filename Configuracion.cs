using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xpand.Extensions.Windows.Manager;

namespace System_Fitness
{
    public partial class Configuracion : UserControl
    {
        dbQuery db = new dbQuery();

        public Configuracion()
        {
            InitializeComponent();
            CargarConfiguracion();  // Cargar los ajustes guardados al abrir el UserControl
        }

        private void CargarConfiguracion()
        {
            dbQuery db = new dbQuery();
            DataTable dt = db.ObtenerConfiguracion();

            if (dt.Rows.Count > 0)
            {
                // Asignar valores a los controles
                txtNombreGimnasio.Text = dt.Rows[0]["NombreGimnasio"].ToString();
                btnColorFondo.FillColor = ColorTranslator.FromHtml(dt.Rows[0]["ColorFondo"].ToString());
                btnColorBarraLateral.FillColor = ColorTranslator.FromHtml(dt.Rows[0]["ColorBarraLateral"].ToString());
                btnColorBarraSuperior.FillColor = ColorTranslator.FromHtml(dt.Rows[0]["ColorSuperior"].ToString());
                btnColorFondoIngreso.FillColor = ColorTranslator.FromHtml(dt.Rows[0]["ColorFondoIngreso"].ToString());
                btnColorBordeCartelIngreso.FillColor = ColorTranslator.FromHtml(dt.Rows[0]["ColorBordeCartelIngreso"].ToString());
                txtCartelIngreso.Text = dt.Rows[0]["CartelIngreso"].ToString();

                // Asignar el ForeColor al botón btnNombreGimnasio
                btnNombreGimnasio.FillColor = ColorTranslator.FromHtml(dt.Rows[0]["ForeColorNombreGimnasio"].ToString());
            }
        }



        public void ActualizarConfiguracion(string colorFondo, string colorBarraLateral, string colorSuperior, string logo, string nombreGimnasio, string colorFondoIngreso, string colorBordeCartelIngreso, string cartelIngreso, string foreColorNombreGimnasio)
        {
            string query = "UPDATE AjustesSistema SET " +
                           "ColorFondo = @ColorFondo, " +
                           "ColorBarraLateral = @ColorBarraLateral, " +
                           "ColorSuperior = @ColorSuperior, " +
                           "Logo = @Logo, " +
                           "NombreGimnasio = @NombreGimnasio, " +
                           "ColorFondoIngreso = @ColorFondoIngreso, " +
                           "ColorBordeCartelIngreso = @ColorBordeCartelIngreso, " +
                           "CartelIngreso = @CartelIngreso, " +
                           "ForeColorNombreGimnasio = @ForeColorNombreGimnasio " +
                           "WHERE AjusteID = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@ColorFondo", colorFondo ?? (object)DBNull.Value),
        new SqlParameter("@ColorBarraLateral", colorBarraLateral ?? (object)DBNull.Value),
        new SqlParameter("@ColorSuperior", colorSuperior ?? (object)DBNull.Value),
        new SqlParameter("@Logo", logo ?? (object)DBNull.Value),
        new SqlParameter("@NombreGimnasio", nombreGimnasio ?? (object)DBNull.Value),
        new SqlParameter("@ColorFondoIngreso", colorFondoIngreso ?? (object)DBNull.Value),
        new SqlParameter("@ColorBordeCartelIngreso", colorBordeCartelIngreso ?? (object)DBNull.Value),
        new SqlParameter("@CartelIngreso", cartelIngreso ?? (object)DBNull.Value),
        new SqlParameter("@ForeColorNombreGimnasio", foreColorNombreGimnasio ?? (object)DBNull.Value)
            };

            dbQuery db = new dbQuery();
            int result = db.ExecuteNonQuery(query, parameters);

            if (result > 0)
            {
                MessageBox.Show("Configuración guardada exitosamente.");
            }
            else
            {
                MessageBox.Show("Hubo un error al guardar la configuración.");
            }
        }



        // Métodos para seleccionar los colores
        private void btnColorFondo_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color colorSeleccionado = colorDialog1.Color;
                btnColorFondo.FillColor = colorSeleccionado;
            }
        }

        private void btnColorBarraLateral_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color colorSeleccionado = colorDialog1.Color;
                btnColorBarraLateral.FillColor = colorSeleccionado;
            }
        }

        private void btnColorBarraSuperior_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color colorSeleccionado = colorDialog1.Color;
                btnColorBarraSuperior.FillColor = colorSeleccionado;
            }
        }

        private void btnColorFondoIngreso_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color colorSeleccionado = colorDialog1.Color;
                btnColorFondoIngreso.FillColor = colorSeleccionado;
            }
        }

        private void btnColorBordeCartelIngreso_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color colorSeleccionado = colorDialog1.Color;
                btnColorBordeCartelIngreso.FillColor = colorSeleccionado;
            }
        }

        // Guardar la configuración
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string colorFondo = ColorTranslator.ToHtml(btnColorFondo.FillColor);
            string colorBarraLateral = ColorTranslator.ToHtml(btnColorBarraLateral.FillColor);
            string colorSuperior = ColorTranslator.ToHtml(btnColorBarraSuperior.FillColor);
            string logo = ""; // Placeholder si no hay logo
            string nombreGimnasio = txtNombreGimnasio.Text;
            string colorFondoIngreso = ColorTranslator.ToHtml(btnColorFondoIngreso.FillColor);
            string colorBordeCartelIngreso = ColorTranslator.ToHtml(btnColorBordeCartelIngreso.FillColor);
            string cartelIngreso = txtCartelIngreso.Text;

            // Obtener el ForeColor del botón btnNombreGimnasio
            string foreColorNombreGimnasio = ColorTranslator.ToHtml(btnNombreGimnasio.FillColor);

            dbQuery db = new dbQuery();
            db.ActualizarConfiguracion(colorFondo, colorBarraLateral, colorSuperior, logo, nombreGimnasio, colorFondoIngreso, colorBordeCartelIngreso, cartelIngreso, foreColorNombreGimnasio);

        }

        private void btnNombreGimnasio_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color colorSeleccionado = colorDialog1.Color;
                btnNombreGimnasio.FillColor = colorSeleccionado;
            }
        }
        public void ActualizarConfiguracionLogo(string logoPath)
        {
            string query = "UPDATE AjustesSistema SET Logo = @Logo WHERE AjusteID = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Logo", logoPath)
            };

            int result = db.ExecuteNonQuery(query, parameters);  // Ejecuta la consulta para actualizar la ruta

            if (result > 0)
            {
                MessageBox.Show("Logo guardado correctamente.");
            }
            else
            {
                MessageBox.Show("Hubo un error al guardar el logo.");
            }
        }

        private void btnSubirlogo_Click(object sender, EventArgs e)
        {

            // Abrir el cuadro de diálogo para seleccionar un archivo
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Todos los archivos|*.*";  // Filtros de archivo

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo
                string logoPath = openFileDialog.FileName;

                // Actualizar la base de datos con la ruta del archivo
                ActualizarConfiguracionLogo(logoPath);
            }
        }
    }
}
