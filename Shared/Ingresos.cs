using System.ComponentModel.DataAnnotations;
public class Ingresos
{
    [Key]
    public int ID { get; set; }
    public string? Nombre { get; set; }
}