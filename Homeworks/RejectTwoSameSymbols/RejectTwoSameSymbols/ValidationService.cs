using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RejectTwoSameSymbols
{
    public class ValidationService
    {
        private const string two_same_symbols = @"(.)\1";
        private Regex twoSameSymbolsRegex = new Regex(two_same_symbols);

        /// <summary>
        /// Проверяет, имеет ли строка 2 одинаковых символа подряд
        /// </summary>
        /// <returns>Имеет ли строка 2 одинаковых символа подряд</returns>
        public bool IsTwoSameSymbols(string input) => twoSameSymbolsRegex.IsMatch(input) ? true : false;
    }
}
