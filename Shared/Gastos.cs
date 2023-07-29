using System.ComponentModel.DataAnnotations;
public class Gastos
{
    [Key]
    public int GastosId { get; set; }
    public string? Nombre { get; set; }
    public List<Transacciones> Transacciones { get; set; } = new List<Transacciones>();
}