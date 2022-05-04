using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebGerenciamento.Models
{
    [Table("Medicamentos")]//Renomeando a tabela
    public class Medicamentos
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Registro")]
        [Display(Name = "Número Registro Anvisa")]
        public string Registro { get; set; }

        [Column("Medicamento")]
        [Display(Name = "Medicamento")]
        public string Medicamento { get; set; }

        [Column("Validade")]
        [Display(Name = "Validade")]
        public DateTime Validade { get; set; }

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Column("Preço")]
        [Display(Name = "Preço")]
        public double Preço { get; set; }

        [Column("Quantidade")]
        [Display(Name = "Quantidade de comprimidos")]
        public int Quantidade { get; set; }


        [Display(Name = "Fabricante")]
        [ForeignKey("Fabricante")]
        [Column(Order = 1)]
        public int IdFabricante { get; set; }
        public virtual Fabricante Fabricante { get; set; }


        [Column("ReacoesMedicamento")]    
        public string? ReacoesMedicamento { get; set; }
    }
}
