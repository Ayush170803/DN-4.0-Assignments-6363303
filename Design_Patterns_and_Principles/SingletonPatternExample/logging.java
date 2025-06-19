class Logger
{
    private static Logger instance;
    
    private Logger(){}
    
    public static Logger getInstance()
    {
        if(instance==null)
        {
            instance=new Logger();
        }
        return instance;
    }
    
    public void print(String message)
    {
        System.out.println(message);
    }
}

public class logging
{
    public static void main(String[] args)
    {
        Logger logger1=Logger.getInstance();
        Logger logger2=Logger.getInstance();
        
        logger1.print("Tracking from logger1");
        logger2.print("Tracking from logger2");
        
        System.out.println("Both Instance same or not:- "+(logger1==logger2));
    }
}