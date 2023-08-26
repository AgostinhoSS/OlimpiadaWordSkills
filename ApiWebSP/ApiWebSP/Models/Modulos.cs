namespace ApiWebSP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Modulos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Modulos()
        {
            CursoModulo = new HashSet<CursoModulo>();
            Modulos1 = new HashSet<Modulos>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Descricao { get; set; }

        public int? IdPai { get; set; }

        public int? IdTipo { get; set; }

        public int? Seq { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CursoModulo> CursoModulo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Modulos> Modulos1 { get; set; }

        public virtual Modulos Modulos2 { get; set; }

        public virtual TiposAtividade TiposAtividade { get; set; }
    }
}
