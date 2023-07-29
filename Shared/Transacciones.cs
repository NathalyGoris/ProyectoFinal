using System.ComponentModel.DataAnnotations;

public class Transacciones
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateTime Fecha { get; set; } = DateTime.Now;
    
    [Required(ErrorMessage = "El Monto es obligatorio.")]
    public decimal Monto { get; set; }
    
    [Required(ErrorMessage = "El Monto Objetivo es obligatorio.")]
    public string? Descripcion { get; set; }
    public Usuarios? Usuario { get; set; }
    public Ingresos? Categoria { get; set; }
}
