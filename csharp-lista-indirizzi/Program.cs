using System.Runtime.CompilerServices;
using static System.Console;
namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Address> appAddresses = new();
            StreamReader fileAppAddresses = File.OpenText("C:\\BOOLEAN_CSharp_Course\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\my-addresses.csv");

            int lineNumber = 0;

            while (!fileAppAddresses.EndOfStream)
            {
                try
                {
                    string? line = fileAppAddresses.ReadLine();
                    lineNumber++;
                    if (lineNumber > 1)
                    {

                        Address newAddress = AddressFileReader.ReadAnAddress(line!);
                        appAddresses.Add(newAddress);

                    }
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }
            fileAppAddresses.Close();
            // now it's time to write the addresses in a file
            try
            {
                WriteLine();
                StreamWriter fileToWrite = File.CreateText("C:\\BOOLEAN_CSharp_Course\\" +
                    "csharp-lista-indirizzi\\csharp-lista-indirizzi\\outputAddresses.txt");

                for (int i = 0; i < appAddresses.Count; i++)
                {
                    WriteLine($"{i + 1}. {appAddresses[i]}");
                    fileToWrite.WriteLine($"{i + 1}. {appAddresses[i]}");
                }

                fileToWrite.Close();

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            ReadKey();
        }
    }
}