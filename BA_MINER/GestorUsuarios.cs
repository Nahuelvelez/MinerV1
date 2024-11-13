using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace BA_MINER
{
    public class GestorUsuarios
    {
        private readonly string rutaXml = "usuarios.xml";

        public void GuardarUsuario(Usuarios usuario)
        {
            XDocument xmlDoc;
            if (File.Exists(rutaXml))
            {
                xmlDoc = XDocument.Load(rutaXml);
            }
            else
            {
                xmlDoc = new XDocument(new XElement("Usuarios"));
            }

            XElement nuevoUsuario = new XElement("Usuario",
                new XElement("NombreUsuario", usuario.NombreUsuario),
                new XElement("Contraseña", usuario.Contraseña));

            xmlDoc.Element("Usuarios").Add(nuevoUsuario);
            xmlDoc.Save(rutaXml); 
        }

        public static Usuarios LeerUsuarioDesdeXML(string NombreUsuario)
        {
            string archivoXML = "usuarios.xml";

            if (!File.Exists(archivoXML))
            {
                return null; 
            }

            XmlSerializer serializer = new XmlSerializer(typeof(ListaUsuarios));

            using (StreamReader reader = new StreamReader(archivoXML))
            {
                ListaUsuarios listaUsuarios = (ListaUsuarios)serializer.Deserialize(reader);
                return listaUsuarios.Usuarios.FirstOrDefault(u => u.NombreUsuario == NombreUsuario);
            }
        }

        public bool VerificarUsuario(string nombreUsuario, string contraseña)
        {
            if (!File.Exists(rutaXml))
            {
                return false;
            }

            XDocument xmlDoc = XDocument.Load(rutaXml);
            var usuario = xmlDoc.Descendants("Usuario")
                .FirstOrDefault(u => u.Element("NombreUsuario").Value == nombreUsuario &&
                                     u.Element("Contraseña").Value == contraseña);

            return usuario != null;
        }


    }
}
