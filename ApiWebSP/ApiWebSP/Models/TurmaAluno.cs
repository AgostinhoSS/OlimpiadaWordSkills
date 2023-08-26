namespace ApiWebSP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TurmaAluno")]
    public partial class TurmaAluno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TurmaAluno()
        {
            AlunoModulo = new HashSet<AlunoModulo>();
        }

        public int Id { get; set; }

        public int? IdTurma { get; set; }

        public int? IdAluno { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlunoModulo> AlunoModulo { get; set; }

        public virtual Alunos Alunos { get; set; }

        public virtual Turmas Turmas { get; set; }
    }
}
