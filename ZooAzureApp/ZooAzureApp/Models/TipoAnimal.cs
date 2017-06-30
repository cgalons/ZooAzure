using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooApp
{
    //CREAMOS LA CLASE TIPOANIMAL, QUE TIENE DOS DATOS DE TIPO PRIMITIVO, CON SUS GETTERS Y SETTERS
    public class TipoAnimal
    {
        public long idTipoAnimal { get; set; }
        public string denominacionTipoAnimal { get; set; }
    }
}