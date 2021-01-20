namespace APIGerarBoletos.Models
{
    public class BoletoIn
    {
        public string Vencimento { get; set; }
        public string Valor { get; set; }
        public string Sacado { get; set; }
        public string Morada { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
    }
}
