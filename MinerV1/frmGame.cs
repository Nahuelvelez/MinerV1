using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BA_MINER;
namespace MinerV1
{
    public partial class frmGame : Form
    {
        private Juego juego;
        public frmGame()
        {
            InitializeComponent();
            InicializarInterfaz();
            juego = new Juego(); 
            juego.IniciarNuevoJuego();
        }

        private void InicializarInterfaz()
        {

            tableroPanel.Controls.Clear();

            int filas = 10;
            int columnas = 10;
            int tamañoBoton = 40;

            for (int fila = 0; fila < filas; fila++)
            {
                for (int columna = 0; columna < columnas; columna++)
                {
                    Button btnCelda = new Button();
                    btnCelda.Width = tamañoBoton;
                    btnCelda.Height = tamañoBoton;
                    btnCelda.Location = new Point(columna * tamañoBoton, fila * tamañoBoton);
                    btnCelda.Click += BtnCelda_Click;
                    btnCelda.Tag = new Point(fila, columna); 

                    tableroPanel.Controls.Add(btnCelda);
                }
            }
        }
        private void FinDelJuego()
        {
            MessageBox.Show("¡Has perdido todas tus vidas! Juego terminado.", "Fin del Juego");


            juego.GuardarPuntuacion("puntuacion.xml");


            DialogResult result = MessageBox.Show("¿Quieres jugar de nuevo?", "Reiniciar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                juego.IniciarNuevoJuego();
                InicializarInterfaz(); 
            }
            else
            {
                Close(); 
            }
        }

        private void ActualizarPuntajeYVidas()
        {
            Label lblPuntos = (Label)this.Controls["lblPuntos"];
            lblPuntos.Text = $"Puntos: {juego.Puntos}";

            Label lblVidas = (Label)this.Controls["lblVidas"];
            lblVidas.Text = $"Vidas: {juego.Vidas}";
        }

        private void AvanzarAlSiguienteNivel()
        {
            MessageBox.Show("¡Felicidades! Has pasado al siguiente nivel.", "Nivel Completado");

            juego.GuardarPuntuacion("puntuacion.xml");

   
            DialogResult result = MessageBox.Show("¿Quieres continuar al siguiente nivel?", "Continuar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                juego.IniciarNuevoJuego();
                InicializarInterfaz(); 
            }
            else
            {
                Close(); 
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainMenu menu = new frmMainMenu();
            menu.Show();
        }

        private void BtnReiniciar_Click(object sender, EventArgs e)
        {
            juego.IniciarNuevoJuego();
            foreach (Button btn in tableroPanel.Controls)
            {
                btn.Text = "";
                btn.Enabled = true;
            }
            lblPuntos.Text = "Puntos: 💎";
            lblVidas.Text = "Vidas: 💀";
        }
        private void BtnCelda_Click(object sender, EventArgs e)
        {
            Button celda = sender as Button;
            Point posicion = (Point)celda.Tag;

            string resultado = juego.MinarCelda(posicion.X, posicion.Y);

            if (resultado == "Mineral")
            {
                celda.Text = "💎";
                lblPuntos.Text = "Puntos: " + juego.Puntos;
            }
            else if (resultado == "Monstruo")
            {
                celda.Text = "💀";
                lblVidas.Text = "Vidas: " + juego.Vidas;

                if (juego.Vidas <= 0)
                {
                    FinDelJuego();
                    return;
                }
            }

            celda.Enabled = false;



        }

    }
}
