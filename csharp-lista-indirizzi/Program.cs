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
                string invalidFormatMessage = "This address is not in a valid format.";
                string emptyFieldsMessage = "There are empty fields in this address.";
                while (!fileAppAddresses.EndOfStream)
                {
                    string? line = fileAppAddresses.ReadLine();
                    lineNumber++;
                    if(lineNumber > 1){

                        string[] addressSplits = line.Split(',');
                        if(addressSplits.Length != 6 ){
                            
                            // throw new Exception("Errore nel file");
                            WriteLine(invalidFormatMessage);
                        }else{
                            
                            /*
                            hardcoded, this is not good
                            if(addressSplits[0] == "" | addressSplits[1] == "" | addressSplits[2] == "" | addressSplits[3] == "" | addressSplits[4] == "" | addressSplits[5] == "" ){
                                WriteLine(invalidFormatMessage);  
                                continue;                         
                            }
                            */
                            // down here I check if some fields are empty in a dinamic way
                            bool hasEmptyField = false;

                            foreach (string field in addressSplits)
                            {
                                if (string.IsNullOrEmpty(field))
                                {
                                    hasEmptyField = true;
                                    break;
                                }
                            }

                            if (hasEmptyField)
                            {
                                // Print a message to the user if any of the field is empty
                                WriteLine(emptyFieldsMessage);
                                continue;
                            }
                         
                            string name = addressSplits[0];
                            string surname = addressSplits[1];
                            string street = addressSplits[2];
                            string city = addressSplits[3];
                            string province = addressSplits[4];
                            string zipCode = addressSplits[5];

                            WriteLine($"The address of {name} {surname}: {street}, {city}, {province}, ZIP: {zipCode}");

                            Address newAddress = new Address(name, surname, street, city, province, zipCode);

                            appAddresses.Add(newAddress);

                        }
                    
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