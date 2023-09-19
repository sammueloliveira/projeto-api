using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class Contexto : IdentityDbContext
    {
        public Contexto()
        { }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Noticia> Noticias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(Getconnectionstring());

            base.OnConfiguring(optionsBuilder);
        }
        private string Getconnectionstring()
        {
            return "Data Source=SAMUEL;Initial Catalog=ApiNoticia;Integrated Security=True;Encrypt=false";
        }
    }
}
