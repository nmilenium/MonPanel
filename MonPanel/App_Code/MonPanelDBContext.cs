using System.Data.Entity;


namespace MonPanel
{
    public class MonPanelDBContext : DbContext
    {
        public MonPanelDBContext() : base("name=MonPanel")
        {
        }
        public DbSet<Host> Hosts { get; set; }
    }
}