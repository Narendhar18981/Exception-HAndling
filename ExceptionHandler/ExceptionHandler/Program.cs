using System;
using System.IO;

class Program
{
    public static void Main()
    {
        string file = Console.ReadLine();
        string file1=Console.ReadLine();
        
        try
        {
            ProcessFile(file,file1);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.FileName);
        }
        catch (InvalidDataException ex)
        {
            Console.WriteLine("Invalid file format: " + ex.Message);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Insufficient file permissions.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }

        Console.WriteLine("Application completed.");
    }

    public static void ProcessFile(string filePath,string filePath1)
    {
        using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string fileContent = reader.ReadToEnd();
                Console.WriteLine(fileContent);
                FileStream? newFile = new(filePath1, FileMode.OpenOrCreate , FileAccess.ReadWrite);
                //newFile.CopyTo(file);
                StreamWriter writer = new StreamWriter(filePath1);
                writer.WriteLine(fileContent);
                writer.Flush();
                StreamReader reader1=new StreamReader(newFile);
                Console.WriteLine(reader1.ReadToEnd());
            }
        }
     }  
}

