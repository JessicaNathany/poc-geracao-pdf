using gerador_pdf.api.Model;
using jsreport.AspNetCore;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;

namespace gerador_pdf.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsReportGeradorPdfController : Controller
    {
        [HttpGet]
        [Route("gerador-pdf")]
        [MiddlewareFilter(typeof(JsReportPipeline))]
        public async Task<IActionResult> InvoiceDownloadAsync()
            {
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf)
                .OnAfterRender((r) => HttpContext.Response.Headers["Content-Disposition"] = "attachment; filename=\"roteiro-gravacao.pdf\"");

            return View("Index", InvoiceModel.Example());
        }
    }
}
