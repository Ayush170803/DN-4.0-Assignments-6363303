using System;
using System.Linq;
public class Product
{
    private int productId;
    private string productName;
    private string category;

    public int ProductId
    {
        get
        {
            return productId;
        }
        set
        {
            productId=value;
        }
    }

    public string ProductName
    {
        get
        {
            return productName;
        }
        set
        {
            productName=value;
        }
    }

    public string Category
    {
        get
        {
            return category;
        }
        set
        {
            category=value;
        }
    }

    public Product(int id,string name,string cat)
    {
        productId=id;
        productName=name;
        category=cat;
    }

    public override string ToString()
    {
        return $"{productId}:{productName} ({category})";
    }
}

public class ECommerceSearch
{
    public static Product? LinearSearch(Product[] products,string name)
    {
        foreach(var prod in products)
        {
            if(prod.ProductName.Equals(name,StringComparison.OrdinalIgnoreCase))
                return prod;
        }
        return null;
    }

    public static Product? BinarySearch(Product[] products, string name)
    {
        int si=0;
        int ei=products.Length-1;

        while(si<=ei)
        {
            int mid=si+(ei-si)/2;
            int check=string.Compare(products[mid].ProductName,name,StringComparison.OrdinalIgnoreCase);
            if(check==0)
            {
                return products[mid];
            }
            else if(check<0)
            {
                si=mid+1;
            }
            else
            {
                ei=mid-1;
            }
        }
        return null;
    }

    public static void Main()
    {
        Product[] products ={
            new Product(1,"Dairy Milk","Food"),
            new Product(2,"Mobile","Electronics"),
            new Product(3,"Book","Education"),
            new Product(4,"Chips","Food"),
        };

        Console.WriteLine("Linear Search:- ");
        var result1 = LinearSearch(products, "Dairy Milk");
        Console.WriteLine(result1!= null?$"Found:{result1}":"Not Found");

        Console.WriteLine("\nBinary Search:-");
        var sortedProducts=products.OrderBy(p=>p.ProductName).ToArray();
        var result2 = BinarySearch(sortedProducts,"apple");
        Console.WriteLine(result2!=null?$"Found:{result2}":"Not Found");

        Console.WriteLine("\nBinary Search:-");
        var result3=BinarySearch(sortedProducts,"Chips");
        Console.WriteLine(result3!=null?$"Found:{result3}":"Not Found");
    }
}
