using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Transacciones> Transacciones { get; set; }
    public DbSet<CategoriaGastos> CategoriaGastos { get; set; }
    public DbSet<CategoriaIngresos> CategoriaIngresos { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<MetaAhorros> MetaAhorros { get; set; }
    public DbSet<CuentasBancarias> cuentasBancarias { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }

  
}
