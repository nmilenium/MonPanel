using System.Data.Entity;


namespace MPanel
{
    public class MonPanelDBContext : DbContext
    {
        public MonPanelDBContext() : base("name=Servers")
        {
        }
        public DbSet<Host> Hosts { get; set; }
    }
}