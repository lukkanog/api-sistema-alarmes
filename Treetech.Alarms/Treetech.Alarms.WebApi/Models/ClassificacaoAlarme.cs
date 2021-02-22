using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Treetech.Alarms.WebApi.Models
{
    [Table("ClassificacoesAlarme")]
    public class ClassificacaoAlarme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClassificacao { get; set; }

        [Column("NomeClassificacao", TypeName = "VARCHAR(250)")]
        [Required(ErrorMessage = "É necessário informar o nome da classificação.")]
        public string NomeClassificacao { get; set; }

        public virtual ICollection<Alarme> Alarmes { get; set; }

    }
}
