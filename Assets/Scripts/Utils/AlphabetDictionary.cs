using System.Collections.Generic;

namespace Assets.Scripts.Utils
{
    static class AlphabetDictionary
    {
        private static Dictionary<string, List<string>> _alphabetWords = new Dictionary<string, List<string>>();
        private static string[] _letters = {"A", "B", "C", "Č", "Ć", "D", "DŽ", "Đ", "E", "F" , "G", "H", "I" , "J", "K", "L", "LJ", "M", "N", "NJ", "O", "P", "R", "S", "Š", "T", "U", "V", "Z", "Ž" }; 

        public static Dictionary<string, List<string>> CreateDictionary()
        {
            foreach (var letter in _letters)
            {
                _alphabetWords.Add(letter, WordsList.CreateWordsList(letter));
            }

            return _alphabetWords;
        }
    }
}
