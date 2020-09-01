using System;
using System.Collections.Generic;
using System.Text;

namespace ESIXamarinLib.Models
{
    public static class RandomLib
    {
        public static Random random = new Random();

        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder sb = new StringBuilder(size);
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                sb.Append(@char);
            }

            return lowerCase ? sb.ToString().ToLower() : sb.ToString();
        }
    }
}
