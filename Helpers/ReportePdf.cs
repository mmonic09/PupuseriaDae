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
        public static void Generar(
            string ruta, DateTime desde, DateTime hasta,
            int transacciones, decimal ingreso, string productoEstrella,
            List<(int IdVenta, DateTime Fecha, string Vendedor, string MetodoPago, decimal Total)> ventas)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(doc => doc.Page(p =>
            {
                p.Size(PageSizes.A4);
                p.Margin(40);
                p.DefaultTextStyle(t => t.FontSize(10));

                p.Header().Column(c =>
                {
                    c.Item().Text("Pupuseria - Reporte de ventas").FontSize(20).Bold().FontColor("#E65100");
                    c.Item().Text($"Del {desde:dd/MM/yyyy} al {hasta:dd/MM/yyyy}").FontColor(Colors.Grey.Darken1);
                });

                p.Content().PaddingVertical(15).Column(c =>
                {
                    c.Spacing(10);
                    c.Item().Text($"Ingreso total: ${ingreso:N2}").Bold().FontSize(11);
                    c.Item().Text($"Total de transacciones: {transacciones}").FontSize(11);
                    c.Item().Text($"Producto estrella: {productoEstrella}").FontSize(11);

                    c.Item().Table(t =>
                    {
                        t.ColumnsDefinition(cd =>
                        {
                            cd.RelativeColumn(1);   // No. venta
                            cd.RelativeColumn(2);   // Fecha
                            cd.RelativeColumn(3);   // Vendedor
                            cd.RelativeColumn(2);   // Método de pago
                            cd.RelativeColumn(1.5f); // Total
                        });

                        t.Header(h =>
                        {
                            h.Cell().Element(Celda).Text("No. venta").Bold();
                            h.Cell().Element(Celda).Text("Fecha").Bold();
                            h.Cell().Element(Celda).Text("Vendedor").Bold();
                            h.Cell().Element(Celda).Text("Método de pago").Bold();
                            h.Cell().Element(Celda).AlignRight().Text("Total").Bold();
                        });

                        foreach (var v in ventas)
                        {
                            t.Cell().Element(Celda).Text(v.IdVenta.ToString());
                            t.Cell().Element(Celda).Text($"{v.Fecha:dd/MM/yyyy HH:mm}");
                            t.Cell().Element(Celda).Text(v.Vendedor);
                            t.Cell().Element(Celda).Text(v.MetodoPago);
                            t.Cell().Element(Celda).AlignRight().Text($"${v.Total:N2}");
                        }
                    });
                });

                p.Footer().AlignCenter().Text(x => { x.Span("Pagina "); x.CurrentPageNumber(); });
            })).GeneratePdf(ruta);
        }



        // Estilo común de cada celda
        private static IContainer Celda(IContainer c) =>
            c.BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).PaddingVertical(4);
    }
}

