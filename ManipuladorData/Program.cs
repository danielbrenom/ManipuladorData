// See https://aka.ms/new-console-template for more information

using ManipuladorData.Enums;
using ManipuladorData.Extensions;

Console.WriteLine("Hello, World!");
Console.WriteLine($"Hoje {DateTime.Now.ChangeDateRange(TimeManipulationSpans.Hoje)[0]} - {DateTime.Now.ChangeDateRange(TimeManipulationSpans.Hoje)[1]}");
Console.WriteLine($"Ontem {DateTime.Now.ChangeDateRange(TimeManipulationSpans.Ontem)[0]} - {DateTime.Now.ChangeDateRange(TimeManipulationSpans.Ontem)[1]}");
Console.WriteLine($"Esta semana {DateTime.Now.ChangeDateRange(TimeManipulationSpans.EstaSemana)[0]} - {DateTime.Now.ChangeDateRange(TimeManipulationSpans.EstaSemana)[1]}");
Console.WriteLine($"Este Mês {DateTime.Now.ChangeDateRange(TimeManipulationSpans.EsteMes)[0]} - {DateTime.Now.ChangeDateRange(TimeManipulationSpans.EsteMes)[1]}");
Console.WriteLine($"Ultimos 30 dias {DateTime.Now.ChangeDateRange(TimeManipulationSpans.Ultimos30Dias)[0]} - {DateTime.Now.ChangeDateRange(TimeManipulationSpans.Ultimos30Dias)[1]}");
Console.WriteLine($"Mes anterior {DateTime.Now.ChangeDateRange(TimeManipulationSpans.MesAnterior)[0]} - {DateTime.Now.ChangeDateRange(TimeManipulationSpans.MesAnterior)[1]}");
Console.WriteLine($"Ultimos 3 meses {DateTime.Now.ChangeDateRange(TimeManipulationSpans.Ultimos3Meses)[0]} - {DateTime.Now.ChangeDateRange(TimeManipulationSpans.Ultimos3Meses)[1]}");
Console.WriteLine($"Ultimos 6 meses {DateTime.Now.ChangeDateRange(TimeManipulationSpans.Ultimos6Meses)[0]} - {DateTime.Now.ChangeDateRange(TimeManipulationSpans.Ultimos6Meses)[1]}");