interface Document 
{
    void open();
    void save();
}

class WordDocument implements Document 
{
    public void open()
    {
        System.out.println("Opening Word document");
    }
    public void save()
    {
        System.out.println("Saving Word document");
    }
}

class PdfDocument implements Document 
{
    public void open()
    {
        System.out.println("Opening PDF document");
    }
    public void save() 
    {
        System.out.println("Saving PDF document");
    }
}

class ExcelDocument implements Document 
{
    public void open() 
    {
        System.out.println("Opening Excel document");
    }
    public void save() 
    {
        System.out.println("Saving Excel document");
    }
}


abstract class DocumentFactory 
{
    public abstract Document createDocument();
}


class WordFactory extends DocumentFactory 
{
    public Document createDocument() 
    {
        return new WordDocument();
    }
}

class PdfFactory extends DocumentFactory 
{
    public Document createDocument() 
    {
        return new PdfDocument();
    }
}

class ExcelFactory extends DocumentFactory 
{
    public Document createDocument() 
    {
        return new ExcelDocument();
    }
}

public class DocumentFactoryMethod 
{
    public static void main(String[] args) 
    {
        DocumentFactory wordFactory=new WordFactory();
        Document wordDoc=wordFactory.createDocument();
        wordDoc.open();
        wordDoc.save();
        System.out.println();

        DocumentFactory pdfFactory=new PdfFactory();
        Document pdfDoc=pdfFactory.createDocument();
        pdfDoc.open();
        pdfDoc.save();
        System.out.println();

        DocumentFactory excelFactory=new ExcelFactory();
        Document excelDoc=excelFactory.createDocument();
        excelDoc.open();
        excelDoc.save();
        System.out.println();
        
    }
}
