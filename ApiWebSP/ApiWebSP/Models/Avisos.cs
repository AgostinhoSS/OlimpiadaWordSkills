namespace ApiWebSP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Avisos
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        [StringLength(50)]
        public string Titulo { get; set; }

        [StringLength(250)]
        public string Aviso { get; set; }

        public int? IdCurso { get; set; }

        public int? IdTurma { get; set; }

        [StringLength(50)]
        public string Imagem { get; set; }

        public virtual Cursos Cursos { get; set; }

        public virtual Turmas Turmas { get; set; }
    }
}
