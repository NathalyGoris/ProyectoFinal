using System.ComponentModel.DataAnnotations;
public class Gastos : Transacciones
{
    public List<Transacciones> Transacciones { get; set; } = new List<Transacciones>();
}