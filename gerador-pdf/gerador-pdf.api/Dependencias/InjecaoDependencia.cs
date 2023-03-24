using DinkToPdf.Contracts;
using DinkToPdf;
using gerador_pdf.api.Service;
using jsreport.Shared;

namespace gerador_pdf.api.Dependencias
{
    public static class InjecaoDependencia
    {
        public static void Dependencia(this IServiceCollection services)
        {
            services.AddTransient<IGeradorPdfServices, GeradorPdfService>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddScoped<PdfService>();
        }
    }
}
