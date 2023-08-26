namespace ApiWebSP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cursos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cursos()
        {
            Avisos = new HashSet<Avisos>();
            CursoModulo = new HashSet<CursoModulo>();
            Turmas = new HashSet<Turmas>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        public int? CargaHoraria { get; set; }

        [Column(TypeName = "image")]
        public byte[] Imagem { get; set; }

        public string Descricao { get; set; }

        public int? IdArea { get; set; }

        public virtual Areas Areas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avisos> Avisos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CursoModulo> CursoModulo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Turmas> Turmas { get; set; }
    }
}
