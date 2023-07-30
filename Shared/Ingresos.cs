using System.ComponentModel.DataAnnotations;
public class Ingresos : Transacciones
{
    public List<Transacciones> Transacciones { get; set; } = new List<Transacciones>();
}