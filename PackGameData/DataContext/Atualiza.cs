namespace PackGameData.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Atualiza")]
    public partial class Atualiza
    {
        [Key]
        public int idAtualiza { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [Column(TypeName = "text")]
        public string descricao { get; set; }

        public int idJogo { get; set; }

        public virtual Jogo Jogo { get; set; }
    }
}
