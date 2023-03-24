using DinkToPdf;
using DinkToPdf.Contracts;
using System;

namespace gerador_pdf.api.Service
{
    public class PdfService : IPdfService
    {
        private readonly IConverter _converter;
        public PdfService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GeneratePdfFromHtml(string html)
        {


            var document = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4
            },
                Objects = { new ObjectSettings() { HtmlContent = html }
            }
            };

            return _converter.Convert(document);
        }
    }
}

