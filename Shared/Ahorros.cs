using System.ComponentModel.DataAnnotations;
public class Ahorros
{
    [Key]
    public int AhorroId { get; set; }
    public decimal MontoObjetivo { get; set; }
    public DateTime FechaLimite { get; set; }
    public Usuarios? Usuario { get; set; }
}