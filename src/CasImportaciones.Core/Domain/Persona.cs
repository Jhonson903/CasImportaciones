using System;
using System.Collections.Generic;

namespace CasImportaciones.Core.Domain
{
    public partial class Persona
    {
        public Persona()
        {
            Ordencompra = new HashSet<Ordencompra>();
            Ordenventa = new HashSet<Ordenventa>();
        }

        public int IdUsuario { get; set; }
        public int Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public int? IdTipo { get; set; }
        public string Id { get; set; }

        public virtual Aspnetusers IdNavigation { get; set; }
        public virtual Tipoidentificacion IdTipoNavigation { get; set; }
        public virtual ICollection<Ordencompra> Ordencompra { get; set; }
        public virtual ICollection<Ordenventa> Ordenventa { get; set; }
    }
}
