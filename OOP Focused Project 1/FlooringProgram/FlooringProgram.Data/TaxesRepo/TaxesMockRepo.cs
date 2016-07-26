using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data.TaxesRepo
{
    class TaxesMockRepo : TaxesRepository
    {
        private Dictionary<string, State> FakeTaxesList = new Dictionary<string, State>()
        {
            {"OHIO", new State() {StateName = "Ohio", StateAbbreviation = "OH", TaxRate = 0.06250m } },
            {"PENNSYLVANIA", new State() {StateName = "Pennsylvania", StateAbbreviation = "PA", TaxRate = 0.0675m} },
            {"MICHIGAN", new State() {StateName = "Michigan", StateAbbreviation = "NY", TaxRate = 0.0575m} },
            {"INDIANA", new State() {StateName = "Indiana", StateAbbreviation = "IN", TaxRate = 0.0600m} }
        };

        public override State GetStateByFullName(string stateFullName)
        {
            State state = null;
            if (FakeTaxesList.ContainsKey(stateFullName))
            {
                state = FakeTaxesList[stateFullName];
            }
            return state;
        }
    }
}
