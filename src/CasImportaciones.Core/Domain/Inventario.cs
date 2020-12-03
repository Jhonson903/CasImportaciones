using System;
using System.Collections.Generic;

namespace CasImportaciones.Core.Domain
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public string Referencia { get; set; }
        public int? Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int? IdProveedor { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual Producto ReferenciaNavigation { get; set; }
    }
}
