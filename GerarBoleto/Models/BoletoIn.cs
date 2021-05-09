namespace GerarBoleto.Models
{
    public class BoletoIn
    {
        public string Numero { get; set; }
        public string Vencimento { get; set; }
        public string Valor { get; set; }

        public bool isItau { get; set; }
        public bool isBradesco { get; set; }

#if DEBUG
        public bool Teste { get; } = true;
#else
        public bool Teste { get; } = false
#endif

        public CedenteIn Cedente { get; set; }
        public SacadoIn Sacado { get; set; }
    }
}
