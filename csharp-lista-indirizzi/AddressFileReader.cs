using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace csharp_lista_indirizzi
{
    public static class AddressFileReader
    {
        public static Address ReadAnAddress(string textLine)
        {
            string invalidFormatMessage = "This address is not in a valid format.";
            string emptyFieldsMessage = "There are empty fields in this address.";
            string[] addressSplits = textLine.Split(',');
            if (addressSplits.Length != 6)
            {
                // throw new Exception("Errore nel file");
                throw new Exception(invalidFormatMessage);
            }
            else
            {
                /*
                hard-coded, this is not good
                    if(addressSplits[0] == "" | addressSplits[1] == "" | addressSplits[2] == "" | addressSplits[3] == "" | addressSplits[4] == "" | addressSplits[5] == "" ){
                        WriteLine(invalidFormatMessage);  
                        continue;                         
                    }
                */
                // down here I check if some fields are empty in a dynamic way

                bool hasEmptyField = false;

                foreach (string field in addressSplits)
                {
                    if (string.IsNullOrWhiteSpace(field))
                    {
                        hasEmptyField = true;
                        break;
                    }
                }

                if (hasEmptyField)
                {
                    // Print a message to the user if any of the field is empty
                    throw new Exception(emptyFieldsMessage);
                    // if an exception is thrown within a method, the code that follows the throw statement in the same block will not be executed. The control will immediately exit the current block and propagate up to the nearest enclosing catch block, if any. 
                }

                string name = addressSplits[0];
                string surname = addressSplits[1];
                string street = addressSplits[2];
                string city = addressSplits[3];
                string province = addressSplits[4];
                string zipCode = addressSplits[5];

                WriteLine($"The address of {name} {surname}: {street}, {city}, {province}, ZIP: {zipCode}");

                return new Address(name, surname, street, city, province, zipCode);
            }

        }
    }
}
