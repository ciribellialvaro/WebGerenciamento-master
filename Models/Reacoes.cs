using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebGerenciamento.Models
{
    [Table("Reacoes")]//Renomeando a tabela
    public class Reacoes
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Column("Descricao")]
        [Display(Name = "Descrição")]
        public string Nome { get; set; }

        [NotMapped]
        public bool Checked { get; set; }
    }
}
