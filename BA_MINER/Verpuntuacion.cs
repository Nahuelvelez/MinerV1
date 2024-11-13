using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BA_MINER
{
    public class Verpuntuacion
    {
        public int Puntos { get; set; }
        public int Vidas { get; set; }
        public DateTime Fecha { get; set; }

        public Verpuntuacion(int puntos, int vidas)
        {
            Puntos = puntos;
            Vidas = vidas;
            Fecha = DateTime.Now;
        }

        public void GuardarEnXml(string rutaArchivo)
        {
            var doc = new XDocument(
                new XElement("Puntuacion",
                    new XElement("Puntos", Puntos),
                    new XElement("Vidas", Vidas),
                    new XElement("Fecha", Fecha.ToString("yyyy-MM-dd HH:mm:ss"))
                )
            );

            doc.Save(rutaArchivo);
        }
    }
}
