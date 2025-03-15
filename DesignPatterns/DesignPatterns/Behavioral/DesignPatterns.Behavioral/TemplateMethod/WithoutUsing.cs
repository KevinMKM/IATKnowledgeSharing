namespace DesignPatterns.Behavioral.TemplateMethod;

using System;

class PDFReport
{
    public void GenerateReport()
    {
        Console.WriteLine("Fetching data...");
        Console.WriteLine("Formatting data for PDF...");
        Console.WriteLine("Generating PDF report...");
    }
}

class ExcelReport
{
    public void GenerateReport()
    {
        Console.WriteLine("Fetching data...");
        Console.WriteLine("Formatting data for Excel...");
        Console.WriteLine("Generating Excel report...");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        PDFReport pdfReport = new PDFReport();
        pdfReport.GenerateReport();

        ExcelReport excelReport = new ExcelReport();
        excelReport.GenerateReport();
    }
}