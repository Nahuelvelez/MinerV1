using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BA_MINER
{
    [XmlRoot("Usuarios")]
    public class ListaUsuarios
    {
        [XmlElement("Usuario")]
        public List<Usuarios> Usuarios { get; set; }
    }
}
