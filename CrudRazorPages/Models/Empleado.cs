using System;
using System.Collections.Generic;

#nullable disable

namespace CrudRazorPages
{
    public partial class Empleado
    {
        public int? EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public int? JefeId { get; set; }
    }
}
