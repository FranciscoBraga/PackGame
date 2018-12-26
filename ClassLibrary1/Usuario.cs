namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Studio = new HashSet<Studio>();
            Studio1 = new HashSet<Studio>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idUsuario { get; set; }

        [StringLength(200)]
        public string nome { get; set; }

        [StringLength(200)]
        public string email { get; set; }

        [StringLength(50)]
        public string senha { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dataNascimento { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPerfil { get; set; }

        public int? idImagem { get; set; }

        public int idJogo { get; set; }

        public virtual Imagem Imagem { get; set; }

        public virtual Jogo Jogo { get; set; }

        public virtual Perfil Perfil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Studio> Studio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Studio> Studio1 { get; set; }
    }
}
