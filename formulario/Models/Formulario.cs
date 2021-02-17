using System;
using System.Collections.Generic;

#nullable disable

namespace formulario.Models
{
    public partial class Formulario
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int? Precio { get; set; }
    }
}
