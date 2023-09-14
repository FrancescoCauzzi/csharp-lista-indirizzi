using System.Runtime.CompilerServices;
using static System.Console;
namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Address> appAddresses = new List<Address>();
            try{
                StreamReader fileAppAddresses = File.OpenText("C:\\BOOLEAN_CSharp_Course\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\my-addresses.csv");

                int lineNumber = 0;
                // string invalidFormatMessage = "This address is not in a valid format.";
                // string emptyFieldsMessage = "There are empty fields in this address.";
                while (!fileAppAddresses.EndOfStream)
                {
                    string? line = fileAppAddresses.ReadLine();
                    lineNumber++;
                    if(lineNumber > 1){
                        
                        Address newAddress = AddressFileReader.ReadAnAddress(line);
                        appAddresses.Add(newAddress);

                    }
                    
                }
                
                fileAppAddresses.Close();

            }catch (Exception e){
                WriteLine(e.Message);
                
            }

            // now it's time to write the addresses in a file
            try
            {
                WriteLine();
                StreamWriter fileToWrite = File.CreateText("C:\\BOOLEAN_CSharp_Course\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\outputAddresses.txt");

                for (int i = 0; i < appAddresses.Count; i++)
                {
                    WriteLine($"{i + 1}. {appAddresses[i]}");
                    fileToWrite.WriteLine($"{i + 1}. {appAddresses[i]}");
                }

                fileToWrite.Close();

            }catch(Exception e){
                WriteLine(e.Message);
            }             
            
        }
    }
}