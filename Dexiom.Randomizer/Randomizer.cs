using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dexiom.Randomizer
{
    public static class Randomizer
    {
        private const string SpecialCaracters = "#!@$%&?()[]{}<>;:_-+=";

        /// <summary>
        /// Return a random number between the bounds
        /// </summary>
        /// <param name="min">Inclusive lower bound</param>
        /// <param name="max">Inclusive upper bound</param>
        /// <returns></returns>
        /// <remarks>This class provide a number that is really random. Random class always return the same values in the same order for a defined seed but we don't want that.</remarks>
        public static int GetRandomNumber(int min, int max)
        {
            var a = new byte[1];
            var crypto = new System.Security.Cryptography.RNGCryptoServiceProvider();
            crypto.GetBytes(a);
            var rnd = new Random(a[0]);
            return rnd.Next(min, max + 1);
        }

        /// <summary>
        /// Returns a random caracter of one of the specified types
        /// </summary>
        /// <param name="types">Possible caracter types</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static char GetRandomCaracter(params CaracterType[] types)
        {
            var retVal = '\0';
            var iChr = 0;
            var chPunctuations = SpecialCaracters.ToCharArray();

            //if nothing is specified, take anything
            var availableTypes = types.Any()
                ? types
                : typeof(CaracterType).GetEnumValues().Cast<CaracterType>().ToArray();
            var chosenType = availableTypes[GetRandomNumber(0, availableTypes.Length - 1)];

            switch (chosenType)
            {
                case CaracterType.UpperCaseLetter:
                    iChr = GetRandomNumber(Convert.ToInt32("A"[0]), Convert.ToInt32("Z"[0]));
                    break;
                case CaracterType.LowerCaseLetter:
                    iChr = GetRandomNumber(Convert.ToInt32("a"[0]), Convert.ToInt32("z"[0]));
                    break;
                case CaracterType.Number:
                    iChr = GetRandomNumber(Convert.ToInt32("0"[0]), Convert.ToInt32("9"[0]));
                    break;
                case CaracterType.Special:
                    iChr = Convert.ToInt32(chPunctuations[GetRandomNumber(0, chPunctuations.Length - 1)]);
                    break;
            }

            retVal = Convert.ToChar(iChr);
            return retVal;
        }
    }
}
