using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Transacciones> Transacciones { get; set; }
    public DbSet<Gastos> Gastos { get; set; }
    public DbSet<Ingresos> Ingresos { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Ahorros> Ahorros { get; set; }
    public DbSet<CuentasBancarias> cuentasBancarias { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }

  
}
