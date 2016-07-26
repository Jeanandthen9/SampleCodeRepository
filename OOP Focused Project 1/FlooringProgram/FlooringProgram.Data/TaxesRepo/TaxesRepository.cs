using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data.TaxesRepo
{
    public abstract class TaxesRepository
    {
        //protected static Dictionary<string, State> StateList { get; private set; }
        protected static List<State> StateList { get; private set; }

        static TaxesRepository()
        {
            StateList = new List<State>();
        }

        public virtual State GetStateByFullName(string stateFullName)
        {
            State state = null;

            var list = from s in StateList
                where s.StateName.Equals(stateFullName, StringComparison.InvariantCultureIgnoreCase)
                select s;

            foreach (var s in list)
            {
                state = s;
            }

            return state;
        }
    }
}
