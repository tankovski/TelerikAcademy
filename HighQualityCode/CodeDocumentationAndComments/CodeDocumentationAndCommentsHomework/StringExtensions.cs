// ********************************
// <copyright file="StringExtensions.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************    
namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Contains extension methods defined for the <see cref="System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///  Returns the MD5 hash of a string.
        /// </summary>
        /// <param name="input">>The string whose hash the method computes.</param>
        /// <returns>The 128-bit (16-byte) hash of the string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Check if the given string is the same like some true values(ex: true, ok, yes, 1, да)
        /// </summary>
        /// <param name="input">This is the string for checking</param>
        /// <returns>Boolean value true if the input string can be interpreted as the boolean values(ex: true, ok, yes, 1, да),else returns false</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Try to parse string to Signed 16-bit integer(<see cref="System.Int16"/>)
        /// </summary>
        /// <param name="input">The name of the string we try to parse</param>
        /// <returns>Signed 16-bit integer(short) if the parse is possible, and 0 if not</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Try to parse string to Signed Signed 32-bit integer(<see cref="System.Int32"/>)
        /// </summary>
        /// <param name="input">The name of the string we try to parse</param>
        /// <returns> Signed Signed 32-bit integer(int) if the parse is possible, and 0 if not</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Try to parse string Signed 64-bit integer(<see cref="System.Int64"/>)
        /// </summary>
        /// <param name="input">The name of the string we try to parse</param>
        /// <returns>Signed Signed 64-bit integer(long) if the parse is possible, and 0 if not</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the string to DateTime Structure(<see cref="System.DateTime"/>).
        /// </summary>
        /// <param name="input">The name of the string we try to parse</param>
        /// <returns>DateTime Structure if the parse is possible, and 1.1.0001 г. 0:00:00 if not </returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Make a copy of the given string with his first letter capital
        /// </summary>
        /// <param name="input">The name of the string whose first letter we try to make capital</param>
        /// <returns>Copy of the input string with capital first letter, and the same string if its empty or null</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Check the substring between two oder substrings in a given string starting from given position, 
        /// or from 0 if there is no start position given
        /// </summary>
        /// <param name="input">The name of the string we are checking</param>
        /// <param name="startString">The substring from which we start</param>
        /// <param name="endString">The substring where we must end</param>
        /// <param name="startFrom">The position from which we start </param>
        /// <returns>Copy of the substring between the given two substrings, and empty string if this is not possible</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Replaces all occurrences of Cyrillic letters in this instance with their Latin counterparts.
        /// </summary>
        /// <param name="input">The name of the string whose cyrillic letters we will convert to latin</param>
        /// <returns>A copy of the input string with the latin representation of his cyrillic letters</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        ///  Replaces all occurrences of Latin letters in this instance with their Cyrillic counterparts
        /// </summary>
        /// <param name="input">The name of the string whose latin letters we will convert to cyrillic</param>
        /// <returns>A copy of the input string with the cyrillic representation of his latin letters</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Make string to a valid user name: replace every cyrillic letter with latin and delete
        /// every character different than letter and number
        /// </summary>
        /// <param name="input">The name of the string that we will validate</param>
        /// <returns>Return copy of the input string, with only latin letters and numbers</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Make a string to a valid file name: replace every cyrillic letter with latin and delete
        /// every character different than number,letter, '_', '.', or '-'
        /// </summary>
        /// <param name="input">The name of the string that we will validate</param>
        /// <returns>Return copy of the input string, with only latin letters, numbers, '_', '.', and '-'</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Return first N characters of a string
        /// </summary>
        /// <param name="input">The string whose first characters we will take</param>
        /// <param name="charsCount">Number of characters that we want</param>
        /// <returns>The first N characters of a string or the whole string if N is bigger than his length</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns the extension of file
        /// </summary>
        /// <param name="fileName">The string whose extension we want to take</param>
        /// <returns>The extension of the string if there is such, if not or if the string is null or empty returns empty string</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// From string who represent file extension we get da content type of the file
        /// </summary>
        /// <param name="fileExtension">The string who represent the file extension</param>
        /// <returns>If the method recognise the string for file extension returns the file type content, else returns "application/octet-stream"</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a set of characters from the specified character array into a sequence of bytes.
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <returns>A byte array containing the specified set of characters.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}