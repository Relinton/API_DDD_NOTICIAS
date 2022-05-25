using Microsoft.AspNetCore.Identity;
using ProjetoNoticias.Entidades.Entidades.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoNoticias.Entidades.Entidades
{
    public class ApplicationUser : IdentityUser
    {
        [Column("IDADE")]
        public int Idade { get; set; }
        [Column("CELULAR")]
        public string Celular { get; set; }
        [Column("TIPOUSUARIO")]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
