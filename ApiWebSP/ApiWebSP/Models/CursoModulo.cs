namespace ApiWebSP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CursoModulo")]
    public partial class CursoModulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CursoModulo()
        {
            AlunoModulo = new HashSet<AlunoModulo>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? IdCurso { get; set; }

        public int? IdModulo { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlunoModulo> AlunoModulo { get; set; }

        public virtual Cursos Cursos { get; set; }

        public virtual Modulos Modulos { get; set; }
    }
}
