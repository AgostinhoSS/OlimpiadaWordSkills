namespace ApiWebSP.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    public partial class Usuarios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Usuario { get; set; }

        [StringLength(50)]
        public string Senha { get; set; }

        [StringLength(50)]
        public string PalavraChave { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Pessoas Pessoas { get; set; }
    }
}
