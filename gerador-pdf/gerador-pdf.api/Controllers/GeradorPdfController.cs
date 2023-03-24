using gerador_pdf.api.Model;
using gerador_pdf.api.Service;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Microsoft.AspNetCore.Mvc;
using Document = iTextSharp.text.Document;

namespace gerador_pdf.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeradorPdfController : Controller
    {
        private readonly IGeradorPdfServices service;

        public GeradorPdfController(IGeradorPdfServices geradorPdfServices)
        {
            service = geradorPdfServices;
        }

        // teste com biblioteca iTextShartp
        [HttpGet]
        [Route("pdf-pessoas")]
        public async Task<ActionResult> GerarRelatorioPdfPessoas()
        {
            var pessoas = service.ObtendoArquivoJsonESerializandoEmUmObjeto("pessoas");
            var memoryStream = new MemoryStream();

            var producao = "relatorio-gravacao";

            if (pessoas.Count == 0)
                return NoContent();

            int totalPaginas = 1;
            if (pessoas.Count > 24)
                totalPaginas += (int)Math.Ceiling((pessoas.Count - 24) / 29F);

            //configurar dados para criar PDF
            var pixelsPorMilimetro = 90 / 40.2F;
            var pdf = new Document(PageSize.A4, 15 * pixelsPorMilimetro, 15 * pixelsPorMilimetro, 15 * pixelsPorMilimetro, 20 * pixelsPorMilimetro);

            // cria o arquivo 
            var nomeArquivo = $"pessoas.{producao}.pdf";
            var arquivo = new FileStream(nomeArquivo, FileMode.Create);
            var pdfWriter = PdfWriter.GetInstance(pdf, arquivo).CloseStream = false;
            pdf.Open();

            // bloco para montar o layout do PDF
            var fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

            //adiciona título
            var fonteHeader = new Font(fonteBase, 10, Font.BOLD, BaseColor.Black);
            var fonteHeaderData = new Font(fonteBase, 8, Font.NORMAL, BaseColor.Black);
            var headerTitulo1 = "SISTEMAS DE GESTÃO DE PROGRAMAS";
            var dataHeader = DateTime.Now.ToString();

            //add linha do tipo HR
            LineSeparator line = new LineSeparator(5f, 100f, BaseColor.Black, Element.ALIGN_CENTER, -1);

            Paragraph header = new Paragraph($"{headerTitulo1}\n\n", fonteHeader);
            Paragraph headerData = new Paragraph($"{dataHeader}\n\n", fonteHeaderData);
            headerData.Add(new Paragraph(10f));
            header.Alignment = Element.ALIGN_RIGHT;
            headerData.Alignment = Element.ALIGN_LEFT;
            pdf.Add(header);
            pdf.Add(line);
            pdf.Add(headerData);

            //adiciona uma tabela
            var tabela = new PdfPTable(5);
            float[] larguras = { 0.6f, 2f, 1.5f, 1f, 1f };
            tabela.SetWidths(larguras);
            tabela.DefaultCell.BorderWidth = 0;
            tabela.WidthPercentage = 100;

            //adiciona os títulos das colunas
            CriarCelulasTextoPessoas(tabela);

            PercorreListaPessoasAssociaValorNasTabela(pessoas, tabela);

            pdf.Add(tabela);
            pdf.Close();
            arquivo.Close();

            return new FileStreamResult(memoryStream, "application/pdf")
            {
                FileDownloadName = nomeArquivo
            };
        }

        private void CriarCelulasTextoPessoas(PdfPTable tabela)
        {
            service.CriarCelulaTextoPessoas(new PdfCelulaTextoModel
            {
                Tabela = tabela,
                Texto = "Código",
                Alinhamento = PdfPCell.ALIGN_LEFT,
                Negrito = true,
                Italico = false,
                TamanhoFonte = 12,
                AlturaCelula = 25
            });

            service.CriarCelulaTextoPessoas(new PdfCelulaTextoModel
            {
                Tabela = tabela,
                Texto = "Nome",
                Alinhamento = PdfPCell.ALIGN_LEFT,
                Negrito = true,
                Italico = false,
                TamanhoFonte = 12,
                AlturaCelula = 25
            });

            service.CriarCelulaTextoPessoas(new PdfCelulaTextoModel
            {
                Tabela = tabela,
                Texto = "Profissão",
                Alinhamento = PdfPCell.ALIGN_LEFT,
                Negrito = true,
                Italico = false,
                TamanhoFonte = 12,
                AlturaCelula = 25
            });


            service.CriarCelulaTextoPessoas(new PdfCelulaTextoModel
            {
                Tabela = tabela,
                Texto = "Salário",
                Alinhamento = PdfPCell.ALIGN_LEFT,
                Negrito = true,
                Italico = false,
                TamanhoFonte = 12,
                AlturaCelula = 25
            });

            service.CriarCelulaTextoPessoas(new PdfCelulaTextoModel
            {
                Tabela = tabela,
                Texto = "Empregada",
                Alinhamento = PdfPCell.ALIGN_LEFT,
                Negrito = true,
                Italico = false,
                TamanhoFonte = 12,
                AlturaCelula = 25
            });
        }

        private void PercorreListaPessoasAssociaValorNasTabela(List<Pessoa> pessoas, PdfPTable tabela)
        {
            foreach (var pessoa in pessoas)
            {
                service.CriarCelulaTextoPessoas(new PdfCelulaTextoModel
                {
                    Tabela = tabela,
                    Texto = pessoa.IdPessoa.ToString("D6"),
                    Alinhamento = PdfPCell.ALIGN_LEFT,
                    Negrito = false,
                    Italico = false
                });

                service.CriarCelulaTextoPessoas(new PdfCelulaTextoModel
                {
                    Tabela = tabela,
                    Texto = pessoa.Nome + " " + pessoa.Sobrenome,
                    Alinhamento = PdfPCell.ALIGN_LEFT,
                    Negrito = false,
                    Italico = false
                });

                service.CriarCelulaTextoPessoas(new PdfCelulaTextoModel
                {
                    Tabela = tabela,
                    Texto = pessoa.Profissao.Nome,
                    Alinhamento = PdfPCell.ALIGN_LEFT,
                    Negrito = false,
                    Italico = false
                });

                service.CriarCelulaTextoPessoas(new PdfCelulaTextoModel
                {
                    Tabela = tabela,
                    Texto = pessoa.Salario.ToString("C2"),
                    Alinhamento = PdfPCell.ALIGN_LEFT,
                    Negrito = false,
                    Italico = false
                });
            }
        }
    }
}
