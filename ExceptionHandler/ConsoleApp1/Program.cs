public class Program
{
    public static void Main()
    {
        try
        {
            int b = 0;
            int a = 1 / b;
        }
        catch (Exception ex) { Console.WriteLine(ex.ToString());}
        Console.WriteLine("YEs");
    }
}