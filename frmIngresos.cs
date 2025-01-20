using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Fitness
{
    public partial class frmIngresos : Form
    {
        public frmIngresos()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                control.Anchor = AnchorStyles.None; // Sin anclaje para que no se fije a los bordes
                if (control is Label label)
                {
                    label.TextAlign = ContentAlignment.MiddleCenter; // Centramos texto de etiquetas
                }
                if (control is Button button)
                {
                    button.TextAlign = ContentAlignment.MiddleCenter; // Centramos texto de botones
                }
                // Márgenes opcionales
                control.Margin = new Padding(10); // Ajusta según lo necesites
            }

        }
    }
}
