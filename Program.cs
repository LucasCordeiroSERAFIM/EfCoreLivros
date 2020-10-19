using System;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {/*executando o contexto*/
            using(var db = new LivroContext())
            {
                /*Criar Banco*/
                 db.Database.EnsureCreated();

            }
        }
    }
/*configuração do banco manipulação dos dados*/
public class LivroContext:DbContext
{
public DbSet<Livro> Livros {get;set;}
/*configuração e modelagem dos dados*/

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
optionsBuilder.
UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore.Demo;Trusted_Connection=True;");
}

/*modelagem*/

protected override void OnModelCreating(ModelBuilder modelBuilder){
/*nome tabela*/
    modelBuilder.Entity<Livro>().ToTable("Livro");
 /*definindo a pk*/
    modelBuilder.Entity<Livro>().HasKey(p => p.LivroId);
/*tamanho dos caompos string , se eu nao por nada ele entende q sera varchar max*/
    modelBuilder.Entity<Livro>().Property(p => p.Titulo).HasColumnType("varchar(50)");
    modelBuilder.Entity<Livro>().Property(p => p.Autor).HasColumnType("varchar(50)");
}
}
    public class Livro{

        public int LivroId { get; set; }    
        public string Titulo { get; set; }  
        public string Autor { get; set; } 
        public int AnoPublicacao { get; set; }
    }
}
