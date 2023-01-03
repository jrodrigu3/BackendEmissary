using System;
using System.ComponentModel.DataAnnotations;

namespace API.models
{
    public class Direcciones
    {
        [Key]
        public int Id { get; set; } 
        public string Alias { get; set; }
        public int Telefono { get; set; }
        public int Pais { get; set; }
        public int CodigoPostal { get; set; }
        public string NombrePersona { get; set; }
        public string CalleNumero { get; set; }
        public string Referencia { get; set; }
        public string CorreoElectronico { get; set; }
        public string Ciudad { get; set; }
        public string Colonia { get; set; }
        public string estado { get; set; }


    }
}
