using System;
using System.Net;

class Program
{
    static void Main()
    {
        try
        {
            ConnectToExternalService();
        }
        catch (WebException ex)
        {
            Console.WriteLine("Network error occurred: " + ex.Message);

            NotifyUser("A network error occurred. Please try again later.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }

        Console.WriteLine("Application completed.");
    }

    static void ConnectToExternalService()
    {
        try
        {
            WebClient client = new WebClient();
            string response = client.DownloadString("https://www.example.com");

            Console.WriteLine("Response from external service: " + response);
        }
        catch (WebException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception("An unexpected error occurred while connecting to the external service.", ex);
        }
    }

    static void NotifyUser(string message)
    {
        Console.WriteLine("Notification: " + message);
    }
}
