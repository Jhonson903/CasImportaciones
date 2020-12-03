using System;
using System.Collections.Generic;

namespace CasImportaciones.Core.Domain
{
    public partial class Tipoidentificacion
    {
        public Tipoidentificacion()
        {
            Persona = new HashSet<Persona>();
            Proveedor = new HashSet<Proveedor>();
        }

        public int IdTipo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
