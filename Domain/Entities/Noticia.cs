using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TB_NOTICIA")]
    public class Noticia
    {
        [Column("NTC_ID")]
        public int Id { get; set; }

        [Column("NTC_TITULO")]
        [MaxLength(255)]
        public string Titulo { get; set; }

        [Column("NTC_INFORMACAO")]
        [MaxLength(255)]
        public string Informacao { get; set; }

        [Column("NTC_ATIVO")]
        public bool Ativo { get; set; }

        [Column("NTC_DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Column("NTC_DATA_ALTERACAO")]
        public DateTime DataAlteracao { get; set; }

        public string UserId { get; set; }
    }
}
