using gerador_pdf.api.Dependencias;
using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Reflection.PortableExecutable;
using static Stimulsoft.Report.StiOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Dependencia();
builder.Services.AddControllersWithViews();
builder.Services.AddJsReport(new LocalReporting().UseBinary(JsReportBinary.GetBinary()).KillRunningJsReportProcesses().AsUtility().Create());

var app = builder.Build();
app.UseStaticFiles();
app.UseFileServer();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
