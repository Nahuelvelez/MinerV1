using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BA_MINER;


namespace MinerV1
{
  
    public partial class frmLOGIN : Form
    {
        private GestorUsuarios gestorUsuarios = new GestorUsuarios();
        public frmLOGIN()
        {
            InitializeComponent();
        }
        private bool EsUsuarioValido(string username, string password)
        {

            Usuarios usuarioEncontrado = GestorUsuarios.LeerUsuarioDesdeXML(username);

            if (usuarioEncontrado != null && usuarioEncontrado.Contraseña == password)
            {
                return true; 
            }

            return false;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Usuarios nuevoUsuario = new Usuarios
            {
                NombreUsuario = textBox1.Text,
                Contraseña = textBox2.Text
            };

            gestorUsuarios.GuardarUsuario(nuevoUsuario);
            MessageBox.Show("Usuario registrado exitosamente.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EsUsuarioValido(textBox1.Text, textBox2.Text))
            {
                this.Hide();

                frmMainMenu menu = new frmMainMenu();
                menu.Show(); 

                menu.FormClosed += (s, args) => this.Close(); 
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
