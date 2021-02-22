using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Treetech.Alarms.WebApi.Models
{
    [Table("AlarmesAtuados")]
    public class AlarmeAtuado 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlarmeAtuado { get; set; }

        [ForeignKey("Alarme")]
        [Required(ErrorMessage = "Informe o Id do alarme atuado (ativo ou não).")]
        public int IdAlarme { get; set; }
        public Alarme Alarme { get; set; }

        [Column("DataEntrada", TypeName = "DATETIME")]
        [Required(ErrorMessage = "Informe a data de entrada do alarme atuado.")]
        public DateTime DataEntrada { get; set; }

        [Column("DataEntrada", TypeName = "DATETIME")]
        [Required(ErrorMessage = "Informe a data de saída do alarme atuado.")]
        public DateTime DataSaida { get; set; }

        [Column("Ativo", TypeName = "BIT")]
        [Required(ErrorMessage = "Informe o status do alarme atuado (ativo ou não).")]
        public bool Ativo { get; set; }


    }
}
