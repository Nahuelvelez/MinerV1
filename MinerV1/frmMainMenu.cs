using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinerV1
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmGame juego = new frmGame();
            juego.Show();
            this.Hide(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí se mostrarían las puntuaciones guardadas.", "Puntuaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
