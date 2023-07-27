using System.ComponentModel.DataAnnotations;
public class Usuarios 
{
    [Key]
    public int ID { get; set; }
    public string? Nombre { get; set; }
    public string? Correo { get; set; }
    public string? Contrasena { get; set; }
    public decimal SaldoTotal { get; set; }
    public List<MetaAhorros>? L_MetasAhorro { get; set; }
   
}