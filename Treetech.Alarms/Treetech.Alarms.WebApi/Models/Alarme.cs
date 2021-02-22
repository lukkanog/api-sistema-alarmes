using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Treetech.Alarms.WebApi.Models
{
    [Table("Alarmes")]
    public class Alarme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlarme { get; set; }

        [Column("Descricao", TypeName = "VARCHAR(250)")]
        [Required(ErrorMessage = "Informe a descrição do alarme.")]
        public string Descricao { get; set; }

        [Column("DataCadastro", TypeName = "DATETIME")]
        [Required(ErrorMessage = "Informe a data de cadastro do alarme.")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey("Classificacao")]
        [Required(ErrorMessage = "Informe a classificação do alarme.")]
        public int IdClassificacao { get; set; }
        public ClassificacaoAlarme Classificacao { get; set; }

        [ForeignKey("Equipamento")]
        [Required(ErrorMessage = "Informe o equipamento relacionado ao alarme")]
        public int IdEquipamento { get; set; }
        public Equipamento Equipamento { get; set; }

        public List<AlarmeAtuado> AlarmesAtuados { get; set; }

    }
}
