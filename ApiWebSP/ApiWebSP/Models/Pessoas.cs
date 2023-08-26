namespace ApiWebSP.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    public partial class Pessoas
    {
        public int Id { get; set; }

        [StringLength(80)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string CPF { get; set; }

        [StringLength(50)]
        public string Telefone { get; set; }

        [StringLength(225)]
        public string Email { get; set; }

        [StringLength(1)]
        public string Sexo { get; set; }

        [Column(TypeName = "image")]
        public byte[] Foto { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Alunos Alunos { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Docentes Docentes { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Usuarios Usuarios { get; set; }
    }
}
