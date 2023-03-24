using gerador_pdf.api.Model;

namespace gerador_pdf.api.Service
{
    public interface IGeradorPdfServices
    {
        List<Pessoa> ObtendoArquivoJsonESerializandoEmUmObjeto(string parametro);

        void CriarCelulaTextoPessoas(PdfCelulaTextoModel celulaTexto);
    }
}
