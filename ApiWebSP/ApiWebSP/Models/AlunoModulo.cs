namespace ApiWebSP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AlunoModulo")]
    public partial class AlunoModulo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? IdTurmaAluno { get; set; }

        public int? IdCursoModulo { get; set; }

        public int? Nota { get; set; }

        [StringLength(250)]
        public string Observacao { get; set; }

        public virtual CursoModulo CursoModulo { get; set; }

        public virtual TurmaAluno TurmaAluno { get; set; }
    }
}
