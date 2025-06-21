using System;

public class Forecast
{
    public static double Future(double p,double r,int y)
    {
        if(y==0)
        {
            return p;
        }
        return Future(p,r,y-1)*(1+r);
    }

    public static void Print(double p,double r,int y)
    {
        Console.WriteLine("\nprediction:-");
        for(int i=0;i<=y;i++)
        {
            double val=Future(p,r,i);
            Console.WriteLine($"year {i}: ₹ {val:F2}");
        }
    }

    public static void Main()
    {
        try
        {
            Console.Write("Initial amount: ");
            double p=Convert.ToDouble(Console.ReadLine());
            Console.Write("Growth rate(%): ");
            double r=Convert.ToDouble(Console.ReadLine())/100;
            Console.Write("Years: ");
            int y=Convert.ToInt32(Console.ReadLine());

            double final=Future(p,r,y);
            Console.WriteLine($"\nFinal Value: ₹ {final:F2}");
            Print(p,r,y);
        }
        catch
        {
            Console.WriteLine("Invalid input");
        }
    }
}
