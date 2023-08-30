using Microsoft.EntityFrameworkCore;

namespace trilha_net_api_desafio.Model;

public class DBAppContext : DbContext
{
    public DBAppContext(DbContextOptions<DBAppContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Tarefa>? Tarefas { get; set; }

}
