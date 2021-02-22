using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Treetech.Alarms.WebApi.Models
{
    [Table("TiposEquipamento")]
    public class TipoEquipamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipo { get; set; }

        [Column("NomeTipo", TypeName = "VARCHAR(250)")]
        [Required(ErrorMessage = "É necessário informar o nome do tipo.")]
        public string NomeTipo { get; set; }

        public virtual ICollection<Equipamento> Equipamentos { get; set; }

    }
}
