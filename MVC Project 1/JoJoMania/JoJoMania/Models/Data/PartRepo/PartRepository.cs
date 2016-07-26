using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoJoMania.Models.Data.PartRepo
{
    public class PartRepository
    {
        private static List<Part> _parts;

        static PartRepository()
        {
            _parts = new List<Part>
            {
                new Part {PartName = "Undecided", PartNumber = 0},
                new Part {PartName = "Phantom Blood", PartNumber = 1},
                new Part {PartName = "Battle Tendancy", PartNumber = 2},
                new Part {PartName = "Stardust Crusaders", PartNumber = 3},
                new Part {PartName = "Diamond Is Unbreakable", PartNumber = 4},
                new Part {PartName = "Vento Aureo", PartNumber = 5},
                new Part {PartName = "Stone Ocean", PartNumber = 6},
                new Part {PartName = "Steel Ball Run", PartNumber = 7},
                new Part {PartName = "JoJolion", PartNumber = 8}
            };
        }

        public static IEnumerable<Part> GetAll()
        {
            return _parts;
        }

        public static Part Get(int partNum)
        {
            return _parts.FirstOrDefault(p => p.PartNumber == partNum);
        }

        public static void Add(string partName)
        {
           Part part = new Part();
            part.PartName = partName;
            part.PartNumber = _parts.Max(p => p.PartNumber) + 1;
            _parts.Add(part);
        }

        public static void Edit(Part part)
        {
            var selectedPart = _parts.FirstOrDefault(p => p.PartNumber == part.PartNumber);
            selectedPart.PartName = part.PartName;
        }

        public static void Delete(int partNum)
        {
            _parts.RemoveAll(p => p.PartNumber == partNum);
        }
    }
}