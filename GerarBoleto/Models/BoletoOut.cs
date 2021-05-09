using System.IO;

namespace GerarBoleto.Models
{
    public class BoletoOut
    {
       public bool Sucesso { get; set; }
       public string Mensagem { get; set; }

       public string Nome { get; set; } = "Boleto";
       public Stream Boleto { get; set; }
    }
}
