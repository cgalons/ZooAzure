using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooAzureApp
{
    public class Especie
    {
        //CREAMOS LA CLASE ESPECIE, QUE TIENE 4 DATOS DE TIPO PRIMITIVO 
        //Y DOS PROPIEDADES COMPLEJAS (OBJETOS), CON SUS GETTERS Y SETTERS

        public long idEspecie { get; set; }
        public string nombre { get; set; }
        public int nPatas { get; set; }
        public bool esMascota { get; set; }
        public Clasificacion clasificacion { get; set; }
        public TipoAnimal tipoAnimal { get; set; }

    }
}