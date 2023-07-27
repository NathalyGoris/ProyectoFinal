using System.ComponentModel.DataAnnotations;
public class CategoriaGastos
{
    [Key]
    public int ID { get; set; }
    public string? Nombre { get; set; }
}