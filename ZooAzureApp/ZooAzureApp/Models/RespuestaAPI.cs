using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooApp
{
    
    public class RespuestaAPI
    {
       
        public int totalData { get; set; }

        public string error { get; set; }

        public List<TipoAnimal> dataTipoAnimal { get; set; }

        public List<Clasificacion> dataClasificacion { get; set; }

        public List<Especie> dataEspecie { get; set; }

    }
}