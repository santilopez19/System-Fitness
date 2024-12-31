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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void ShowUserControl(UserControl control)
        {
            // Limpia el panel y carga el nuevo UserControl
            mainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(control);
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Inicio());
        }
    }
}
