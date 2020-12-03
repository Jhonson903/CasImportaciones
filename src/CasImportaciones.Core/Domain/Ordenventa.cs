using System;
using System.Collections.Generic;

namespace CasImportaciones.Core.Domain
{
    public partial class Ordenventa
    {
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public int Cantidad { get; set; }
        public double ValorTotal { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Persona IdUsuarioNavigation { get; set; }
    }
}
