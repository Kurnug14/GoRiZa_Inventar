global using Microsoft.EntityFrameworkCore;
using GoRiZa_Inventar.Model;
namespace GoRiZa_Inventar.Data
{
    public class GoRiZa_InventarContext : DbContext
    {
        public GoRiZa_InventarContext(DbContextOptions<GoRiZa_InventarContext> options) : base(options) { }
        public DbSet<Benutzer> Benutzers => Set<Benutzer>();
        public DbSet<Computer> Computers => Set<Computer>();
        public DbSet<Gegenstand> Gegs => Set<Gegenstand>();
        public DbSet<Kategorie> Kategories=> Set<Kategorie>();
        public DbSet<Material> Materials => Set<Material>();
        public DbSet<Raum> Raums => Set<Raum>();
        public DbSet<RaumGegenstand> RaumGegenstands=> Set<RaumGegenstand>();
    }
}
