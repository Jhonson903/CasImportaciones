using System;
using System.Collections.Generic;

namespace CasImportaciones.Core.Domain
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Inventario = new HashSet<Inventario>();
            Ordencompra = new HashSet<Ordencompra>();
            Producto = new HashSet<Producto>();
        }

        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public double Telefono { get; set; }
        public string Ciudad { get; set; }
        public int? IdTipo { get; set; }
        public int? Identificacion { get; set; }

        public virtual Tipoidentificacion IdTipoNavigation { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
        public virtual ICollection<Ordencompra> Ordencompra { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
