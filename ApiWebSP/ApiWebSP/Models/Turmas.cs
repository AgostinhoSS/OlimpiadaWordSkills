namespace ApiWebSP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Turmas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Turmas()
        {
            Avisos = new HashSet<Avisos>();
            TurmaAluno = new HashSet<TurmaAluno>();
        }

        public int Id { get; set; }

        public int? IdCurso { get; set; }

        [StringLength(20)]
        public string CodTurma { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataTermino { get; set; }

        public int? QtdMinima { get; set; }

        public int? QtdMaxima { get; set; }

        public int? IdDocente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avisos> Avisos { get; set; }

        public virtual Cursos Cursos { get; set; }

        public virtual Docentes Docentes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TurmaAluno> TurmaAluno { get; set; }
    }
}
