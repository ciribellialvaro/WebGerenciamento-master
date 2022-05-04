using Microsoft.EntityFrameworkCore;
using WebGerenciamento.Models;

namespace WebGerenciamento.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)//criando o construtor da classe pra receber o Option das configuração de conexão com o banco do app set
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        //Fora do construtor, colocando o dbSet, avisando quais objetos queremos que ele crie quando executar a migration e quais serão gerenciados
        public DbSet<Reacoes> Reacoes { get; set; }

        public DbSet<Medicamentos> Medicamentos { get; set; }

        public DbSet<Fabricante> Fabricante { get; set; }

    }
}
