using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace JoJoMania.Models.CustomCode
{
    public static class JoJoRandomizer
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int GetRandomNum(int minVal, int maxVal)
        {
            byte[] randNum = new byte[1];

            _generator.GetBytes(randNum);

            double valueOfRandNum = Convert.ToDouble(randNum[0]);

            double multiplier = Math.Max(0, (valueOfRandNum/255d) - 0.00000000001d);

            int range = maxVal - minVal + 1;

            double randValInRange = Math.Floor(multiplier*range);

            return (int) (minVal + randValInRange);
        }
    }
}