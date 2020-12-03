using System;
using System.Collections.Generic;

namespace CasImportaciones.Core.Domain
{
    public partial class Ordencompra
    {
        public int IdCompra { get; set; }
        public string Referencia { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCompra { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual Persona IdUsuarioNavigation { get; set; }
        public virtual Producto ReferenciaNavigation { get; set; }
    }
}
