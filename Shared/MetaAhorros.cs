using System.ComponentModel.DataAnnotations;
public class MetaAhorros
{
    public int Id { get; set; }
    public decimal MontoObjetivo { get; set; }
    public DateTime FechaLimite { get; set; }
    public Usuarios? Usuario { get; set; }
}