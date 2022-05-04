using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebGerenciamento.Models
{
    [Table("Fabricante")]
    public class Fabricante
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descrição")]
        public string Nome { get; set; }
    }
}
