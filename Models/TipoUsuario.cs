using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_tw.Models
{
    [Table("tipo_usuario")]
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        [Column("id_tipo")]
        public int IdTipo { get; set; }
        [Column("nome_tipo_usuario")]
        [StringLength(50)]
        public string NomeTipoUsuario { get; set; }

        [InverseProperty("IdTipoNavigation")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
