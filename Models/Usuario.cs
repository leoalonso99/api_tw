using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_tw.Models
{
    [Table("usuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            EventosIdResponsavelNavigation = new HashSet<Eventos>();
            EventosIdUsuarioNavigation = new HashSet<Eventos>();
        }

        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Column("nome_usuario")]
        [StringLength(50)]
        public string NomeUsuario { get; set; }
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Column("senha")]
        [StringLength(100)]
        public string Senha { get; set; }
        [Column("telefone_movel")]
        [StringLength(20)]
        public string TelefoneMovel { get; set; }
        [Column("id_tipo")]
        public int? IdTipo { get; set; }

        [ForeignKey(nameof(IdTipo))]
        [InverseProperty(nameof(TipoUsuario.Usuario))]
        public virtual TipoUsuario IdTipoNavigation { get; set; }
        [InverseProperty(nameof(Eventos.IdResponsavelNavigation))]
        public virtual ICollection<Eventos> EventosIdResponsavelNavigation { get; set; }
        [InverseProperty(nameof(Eventos.IdUsuarioNavigation))]
        public virtual ICollection<Eventos> EventosIdUsuarioNavigation { get; set; }
    }
}
