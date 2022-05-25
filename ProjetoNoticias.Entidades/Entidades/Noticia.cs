using ProjetoNoticias.Entidades.Notificacoes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoNoticias.Entidades.Entidades
{
    [Table("NOTICIA")]
    public class Noticia : Notifica
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("TITULO")]
        [MaxLength(255)]
        public string Titulo { get; set; }
        [Column("INFORMACAO")]
        [MaxLength(255)]
        public string Informacao { get; set; }
        [Column("ATIVO")]
        public bool Ativo { get; set; }
        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }
        [Column("DATA_ALTERACAO")]
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}
