class Logger
{
    private static Logger instance;

    private Logger() {}

    public static Logger GetInstance()
    {
        if(instance==null)
        {
            instance=new Logger();
        }
        return instance;
    }

    public void Print(string message)
    {
        Console.WriteLine(message);
    }
}

class Logging
{
    static void Main(string[] args)
    {
        Logger logger1=Logger.GetInstance();
        Logger logger2=Logger.GetInstance();

        logger1.Print("Tracking from logger1");
        logger2.Print("Tracking from logger2");

        Console.WriteLine("Both Instance same or not:- "+(logger1==logger2));
        Console.ReadLine();
    }
} 


