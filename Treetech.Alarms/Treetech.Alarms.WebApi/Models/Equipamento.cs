using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Treetech.Alarms.WebApi.Models
{
    [Table("Equipamentos")]
    public class Equipamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEquipamento { get; set; }

        [Column("NomeEquipamento", TypeName = "VARCHAR(250)")]
        [Required(ErrorMessage = "É necessário informar o nome do equipamento.")]
        public string NomeEquipamento { get; set; }

        [Column("NumeroSerie", TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "É necessário informar o nº de série do equipamento.")]
        public string NumeroSerie { get; set; }

        [ForeignKey("Tipo")]
        [Required(ErrorMessage = "É necessário informar o nº de série do equipamento.")]
        public int IdTipo { get; set; }
        public TipoEquipamento Tipo { get; set; }

        [Column("DataCadastro", TypeName = "DATETIME")]
        [Required(ErrorMessage = "Informe a data de cadastro do equipamento.")]
        public DateTime DataCadastro { get; set; }


        public virtual ICollection<Alarme> Alarmes { get; set; }
    }
}
