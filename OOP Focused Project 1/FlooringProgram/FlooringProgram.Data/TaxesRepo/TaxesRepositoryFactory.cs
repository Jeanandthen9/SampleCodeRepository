using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Data.TaxesRepo
{
    public static class TaxesRepositoryFactory
    {
        public static TaxesRepository CreateTaxRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            TaxesRepository repo;

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new TaxesMockRepo();
                    break;
                case "PROD":
                    repo = new TaxesFileRepo();
                    break;
                default:
                    throw new Exception("That mode doesn't exist!");
            }
            return repo;
        }
    }
}
