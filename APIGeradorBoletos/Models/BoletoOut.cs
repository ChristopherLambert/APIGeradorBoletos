using System.IO;

namespace APIGerarBoletos.Models
{
    public class BoletoOut
    {
       public string Nome { get; set; } = "Boleto";
       public Stream Boleto { get; set; }
    }
}
