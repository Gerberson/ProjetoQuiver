using Microsoft.EntityFrameworkCore;
using ProjetoQuiver.Api.Models;

namespace ProjetoQuiver.Api.Data {
    public class DataContext : DbContext {
        public DataContext (DbContextOptions<DataContext> options) : base (options) { }
        
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Corretora> Corretora { get; set; }
    }
}