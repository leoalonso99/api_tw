using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_tw.Models
{
    [Table("eventos")]
    public partial class Eventos
    {
        [Key]
        [Column("id_evento")]
        public int IdEvento { get; set; }
        [Column("nome_evento")]
        [StringLength(100)]
        public string NomeEvento { get; set; }
        [Column("descricao", TypeName = "text")]
        public string Descricao { get; set; }
        [Column("data_evento", TypeName = "datetime")]
        public DateTime? DataEvento { get; set; }
        [Column("data_criacao", TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column("ativo")]
        public int? Ativo { get; set; }
        [Column("localizacao")]
        [StringLength(100)]
        public string Localizacao { get; set; }
        [Column("id_categoria")]
        public int? IdCategoria { get; set; }
        [Column("id_usuario")]
        public int? IdUsuario { get; set; }
        [Column("id_responsavel")]
        public int? IdResponsavel { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(Categoria.Eventos))]
        public virtual Categoria IdCategoriaNavigation { get; set; }
        [ForeignKey(nameof(IdResponsavel))]
        [InverseProperty(nameof(Usuario.EventosIdResponsavelNavigation))]
        public virtual Usuario IdResponsavelNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.EventosIdUsuarioNavigation))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
