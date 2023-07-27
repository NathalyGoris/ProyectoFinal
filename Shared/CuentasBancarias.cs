using System.ComponentModel.DataAnnotations;
public class CuentasBancarias
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El nombre del banco es requerido.")]
    public string? NombreBanco { get; set; }

    [Required(ErrorMessage = "El número de cuenta es requerido.")]
    public string? NumeroCuenta { get; set; }
    public decimal SaldoActual { get; set; }
    public Usuarios? Usuario { get; set; }

}