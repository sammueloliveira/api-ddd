using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Message
    {
        [Column("MSN_ID")]
        public int Id { get; set; }

        [Column("MSN_TITULO")]
        [MaxLength(255)]
        public string Titulo { get; set; }

        [Column("MSN_ATIVO")]
        public bool Ativo { get; set; }

        [Column("MSN_DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Column("MSN_DATA_ALTERACAO")]
        public DateTime DataAlteracao { get; set; }
        public string UserId { get; set; }
    }
}
