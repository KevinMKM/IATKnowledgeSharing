namespace DesignPatterns.Behavioral.TemplateMethod;

using System;

// Abstract base class
abstract class ReportGenerator
{
    // Template method
    public void GenerateReport()
    {
        FetchData();
        FormatData();
        GenerateOutput();
    }

    // Common step
    private void FetchData()
    {
        Console.WriteLine("Fetching data...");
    }

    // Abstract step (to be implemented by subclasses)
    protected abstract void FormatData();

    // Abstract step (to be implemented by subclasses)
    protected abstract void GenerateOutput();
}

// Concrete subclass for PDF reports
class PDFReport : ReportGenerator
{
    protected override void FormatData()
    {
        Console.WriteLine("Formatting data for PDF...");
    }

    protected override void GenerateOutput()
    {
        Console.WriteLine("Generating PDF report...");
    }
}

// Concrete subclass for Excel reports
class ExcelReport : ReportGenerator
{
    protected override void FormatData()
    {
        Console.WriteLine("Formatting data for Excel...");
    }

    protected override void GenerateOutput()
    {
        Console.WriteLine("Generating Excel report...");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        ReportGenerator pdfReport = new PDFReport();
        pdfReport.GenerateReport();

        ReportGenerator excelReport = new ExcelReport();
        excelReport.GenerateReport();
    }
}