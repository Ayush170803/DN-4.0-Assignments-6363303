using System;

interface IDocument
{
    void Open();
    void Save();
}

class WordDocument:IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Word document");
    }

    public void Save()
    {
        Console.WriteLine("Saving Word document");
    }
}

class PdfDocument:IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening PDF document");
    }

    public void Save()
    {
        Console.WriteLine("Saving PDF document");
    }
}

class ExcelDocument:IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Excel document");
    }

    public void Save()
    {
        Console.WriteLine("Saving Excel document");
    }
}

abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

class WordFactory:DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new WordDocument();
    }
}

class PdfFactory:DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new PdfDocument();
    }
}

class ExcelFactory:DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new ExcelDocument();
    }
}

class DocumentFactoryMethod
{
    static void Main(string[] args)
    {
        DocumentFactory wordFactory=new WordFactory();
        IDocument wordDoc=wordFactory.CreateDocument();
        wordDoc.Open();
        wordDoc.Save();
        Console.WriteLine();

        DocumentFactory pdfFactory=new PdfFactory();
        IDocument pdfDoc=pdfFactory.CreateDocument();
        pdfDoc.Open();
        pdfDoc.Save();
        Console.WriteLine();

        DocumentFactory excelFactory=new ExcelFactory();
        IDocument excelDoc=excelFactory.CreateDocument();
        excelDoc.Open();
        excelDoc.Save();
        Console.WriteLine();
        Console.ReadLine();
    }
}
