using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data.TaxesRepo
{
    class TaxesFileRepo : TaxesRepository
    {
        private const string FILENAME = @"C:\Users\Apprentice\Desktop\_Repository\jeannine-james-individual-work\FlooringProgram\FlooringProgram.Data\TaxesRepo\Taxes.txt";

        static TaxesFileRepo()
        {
            using (StreamReader sr = File.OpenText(FILENAME))
            {
                string inputLine = "";
                string[] inputParts;

                while ((inputLine = sr.ReadLine()) != null)
                {
                    inputParts = inputLine.Split(',');
                    State thisState = new State()
                    {
                        StateAbbreviation = inputParts[0],
                        StateName = inputParts[1],
                        TaxRate = decimal.Parse(inputParts[2]),
                    };

                    StateList.Add(thisState);
                }
            }
        }
    }
}