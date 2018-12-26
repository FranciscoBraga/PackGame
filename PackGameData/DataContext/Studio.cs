namespace PackGameData.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Studio")]
    public partial class Studio
    {
        [Key]
        public int idStudio { get; set; }

        [StringLength(200)]
        public string nome { get; set; }

        public int? idImagem { get; set; }

        [StringLength(200)]
        public string descricao { get; set; }

        [StringLength(200)]
        public string emali { get; set; }

        [StringLength(200)]
        public string telefone { get; set; }

        public int? idLink { get; set; }

        public int? idUsuario { get; set; }

        public virtual Imagem Imagem { get; set; }

        public virtual Link Link { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
