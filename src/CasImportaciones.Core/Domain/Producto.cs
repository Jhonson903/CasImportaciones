using System;
using System.Collections.Generic;

namespace CasImportaciones.Core.Domain
{
    public partial class Producto
    {
        public Producto()
        {
            Inventario = new HashSet<Inventario>();
            Ordencompra = new HashSet<Ordencompra>();
        }

        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Marca { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdProveedor { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
        public virtual ICollection<Ordencompra> Ordencompra { get; set; }
    }
}
