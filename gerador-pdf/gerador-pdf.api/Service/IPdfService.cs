namespace gerador_pdf.api.Service
{
    public interface IPdfService
    {
        byte[] GeneratePdfFromHtml(string html);
    }
}
