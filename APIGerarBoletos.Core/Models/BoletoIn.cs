namespace APIGerarBoletos.Models
{
    public class BoletoIn
    {
        public string Vencimento { get; set; }
        public string Valor { get; set; }

#if DEBUG
        public bool Teste { get; } = true;
#else
        public bool Teste { get; } = false
#endif

        public CedenteIn Cedente { get; set; }
        public SacadoIn Sacado { get; set; }
    }
}
