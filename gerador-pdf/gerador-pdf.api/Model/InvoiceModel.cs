using Microsoft.Extensions.Primitives;

namespace gerador_pdf.api.Model
{
    public class InvoiceModel
    {
        public string Number { get; set; }
        public IEnumerable<DetalhesRoteiro> DetalhesRoteiro { get; set; }

        public static InvoiceModel Example()
        {
            return new InvoiceModel()
            {
                DetalhesRoteiro = new List<DetalhesRoteiro>()
                {
                    new DetalhesRoteiro()
                    {
                        LiberadoEm = "17/03/2023",
                        Programa = " CPC NA FÉ",
                        DataGravacao = "24/03/2023 SEXTA-FEIRA",
                        Local = "",
                        Direcao = "",
                        DiretorFrente = "",
                        Observacao = "",
                        TotalPaginas = "8/8",
                        Roteiro = 1,
                        Versao = 2,
                        Estudio = "PEDIDO DE ROUPA",
                        Personagem = "JOÃO",
                        Roteiros = "--",
                        NomeArtistico = "JOSÉ LORETO",
                        HoraChegada = "--",
                        ItemRoupa = "R=1uni(1º)"
                    },
                }
            };
        }
    }
    public class DetalhesRoteiro
    {
        public string LiberadoEm { get; set; }
        public string Programa { get; set; }
        public string Direcao { get; set; }
        public string Local { get; set; }
        public string DiretorFrente { get; set; }
        public string Observacao { get; set; }
        public string TotalPaginas { get; set; }
        public int Roteiro { get; set; }
        public int Versao { get; set; }
        public string Estudio { get; set; }
        public string Personagem { get; set; }
        public string Roteiros { get; set; }
        public string NomeArtistico { get; set; }
        public string HoraChegada { get; set; }
        public string Comentario { get; set; }
        public string DataGravacao { get; set; }
        public string ItemRoupa { get; set; }
    }
}
