using System;
using System.Collections.Generic;

#nullable disable

namespace CrudRazorPages
{
    public partial class ClienteSolicitud
    {
        public int? ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int? EstadoId { get; set; }
        public string Cedula { get; set; }
        public bool? Validado { get; set; }
    }
}
