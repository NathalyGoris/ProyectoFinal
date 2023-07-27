using System.ComponentModel.DataAnnotations;
public class CategoriaIngresos
{
    [Key]
    public int ID { get; set; }
    public string? Nombre { get; set; }
}