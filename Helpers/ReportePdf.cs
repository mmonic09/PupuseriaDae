using System;
using System.Collections.Generic;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Text;

namespace Pupuseria.Helpers
{
    public static class ReportePdf
    {
        public static void Generar (
            string ruta, DateTime desde, DateTime hasta,
            int transacciones, decimal ingreso, string productoEstrella,
            List<(string Categoria, int Unidades, decimal Ingreso)> categorias,
            byte[]? grafica)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(doc => doc.Page(p =>
            {
                p.Size(PageSizes.A4);
                p.Margin(40);
                p.DefaultTextStyle(t => t.FontSize(11));

                p.Header().Column(c =>
                {
                    c.Item().Text("Pupuseria - Reporte de ventas").FontSize(20).Bold().FontColor("#E65100");
                    c.Item().Text($"Del {desde:dd/MM/yyyy} al {hasta:dd/MM/yyyy}").FontColor(Colors.Grey.Darken1);
                });

                p.Content().PaddingVertical(15).Column(c =>
                {
                    c.Spacing(10);
                    c.Item().Text($"Ingreso total: ${ingreso:N2}").Bold();
                    c.Item().Text($"Total de transacciones: {transacciones}");
                    c.Item().Text($"Producto estrella: {productoEstrella}");

                    if (grafica != null)
                        c.Item().Image(grafica);

                    c.Item().Table(t =>
                    {
                        t.ColumnsDefinition(cd => { cd.RelativeColumn(3); cd.RelativeColumn(); });
                        t.Header(h =>
                        {
                            h.Cell().Text("Categoría").Bold();
                            h.Cell().AlignRight().Text("Unidades").Bold();
                            h.Cell().AlignRight().Text("Ingreso").Bold();
                        });
                        foreach (var f in categorias)
                        {
                            t.Cell().Text(f.Categoria);
                            t.Cell().AlignRight().Text(f.Unidades.ToString());
                            t.Cell().AlignRight().Text($"${f.Ingreso:N2}");
                        }
                    });
                });

                p.Footer().AlignCenter().Text(x => { x.Span("Pagina "); x.CurrentPageNumber(); });
            })).GeneratePdf(ruta);
        }
    }
}
