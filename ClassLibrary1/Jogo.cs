namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Jogo")]
    public partial class Jogo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jogo()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int idJogo { get; set; }

        [StringLength(200)]
        public string nome { get; set; }

        [Column(TypeName = "text")]
        public string descricao { get; set; }

        public int? idGenero { get; set; }

        public int? idImagem { get; set; }

        public int? idEtapa { get; set; }

        public virtual Etapa Etapa { get; set; }

        public virtual Genero Genero { get; set; }

        public virtual Imagem Imagem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
