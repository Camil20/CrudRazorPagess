using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CrudRazorPages
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
            Pagos = new HashSet<Pago>();
        }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(1)]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1,2)]
        public int EstadoId { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
