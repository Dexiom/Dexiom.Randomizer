using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Dexiom.Randomizer
{
    public class StringGenerator
    {
        private const char MaskToken = '*';

        /// <summary>
        /// Generate a random string with the specified length
        /// </summary>
        /// <param name="length"></param>
        /// <param name="caracterTypes"></param>
        /// <returns></returns>
        public static string CreateRandomString(int length, params CaracterType[] caracterTypes)
        {
            var retVal = new char[length];
            
            for (var i = 0; i < length; i++)
            {
                var actualCaracterTypes = caracterTypes.Any()
                    ? caracterTypes
                    : typeof(CaracterType).GetEnumValues().Cast<CaracterType>().ToArray();
                retVal[i] = Randomizer.GetRandomCaracter(actualCaracterTypes);
            }

            return new string(retVal);
        }

        /// <summary>
        /// Generate a random serial number
        /// </summary>
        /// <param name="format"></param>
        /// <param name="caracterTypes"></param>
        /// <returns></returns>
        public static string CreateRandomString(string format = "*****-*****-*****-*****", params CaracterType[] caracterTypes)
        {
            var retVal = format.ToCharArray().Select(c => c == MaskToken ? Randomizer.GetRandomCaracter(CaracterType.UpperCaseLetter, CaracterType.Number) : c);
            return string.Join(string.Empty, retVal);
        }
    }
}
