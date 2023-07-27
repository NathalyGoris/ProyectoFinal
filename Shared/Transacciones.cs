using System.ComponentModel.DataAnnotations;

public class Transacciones
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Monto { get; set; }
    public string? Descripcion { get; set; }
    public Usuarios? Usuario { get; set; }
    public CategoriaGastos? Categoria { get; set; }
}
