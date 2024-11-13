using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_MINER
{
    public class Juego
    {
        public int Puntos { get; private set; }
        public int Vidas { get; private set; }
        public int PuntosParaSiguienteNivel { get; private set; } = 100;
        public Juego()
        {
            IniciarNuevoJuego();
        }

        public void IniciarNuevoJuego()
        {
            Puntos = 0;
            Vidas = 5;
        }

        public string MinarCelda(int fila, int columna)
        {
            Random random = new Random();
            if (random.NextDouble() < 0.3)
            {
                Vidas--;
                return "Monstruo";
            }
            else
            {
                Puntos += 10;
                return "Mineral";
            }
        }

        public void GuardarPuntuacion(string rutaArchivo)
        {
            var puntuacion = new Verpuntuacion(Puntos, Vidas);
            puntuacion.GuardarEnXml(rutaArchivo);
        }


    }
}
