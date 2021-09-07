using System.Collections.Generic;

namespace Assets.Scripts.Utils
{
    static class AlphabetDictionary
    {
        private static Dictionary<string, List<string>> _alphabetWords;
        private static string[] _letters = {"A", "B", "C", "Č", "Ć", "D", "DŽ", "Đ", "E", "F" , "G", "H", "I" , "J", "K", "L", "LJ", "M", "N", "NJ", "O", "P", "R", "S", "Š", "T", "U", "V", "Z", "Ž" }; 

        public static Dictionary<string, List<string>> CreateDictionary(string category)
        {
            _alphabetWords = new Dictionary<string, List<string>>();
            foreach (var letter in _letters)
            {
                switch (category)
                {
                    case "BASIC":
                        //if(WordsList.CreateBasicAlphabetList(letter).Count > 0)
                            _alphabetWords.Add(letter, WordsList.CreateBasicAlphabetList(letter));
                        break;
                    case "FOOD":
                        //if(WordsList.CreateBasicAlphabetList(letter).Count > 0)
                            _alphabetWords.Add(letter, WordsList.CreateFoodList(letter));
                        break;
                    case "ANIMAL":
                        //if (WordsList.CreateBasicAlphabetList(letter).Count > 0)
                            _alphabetWords.Add(letter, WordsList.CreateAnimalsList(letter));
                        break;
                }
            }

            return _alphabetWords;
        }

        public static Dictionary<string, List<string>> CreateReverseDictionary(string category)
        {
            _alphabetWords = new Dictionary<string, List<string>>();
            foreach (var letter in _letters)
            {
                switch (category)
                {
                    case "BASIC":
                        //if (ReverseWordsList.CreateBasicAlphabetList(letter).Count > 0)
                            _alphabetWords.Add(letter, ReverseWordsList.CreateBasicAlphabetList(letter));
                        break;
                    case "FOOD":
                        //if (ReverseWordsList.CreateBasicAlphabetList(letter).Count > 0)
                            _alphabetWords.Add(letter, ReverseWordsList.CreateFoodList(letter));
                        break;
                    case "ANIMAL":
                        //if (ReverseWordsList.CreateBasicAlphabetList(letter).Count > 0)
                            _alphabetWords.Add(letter, ReverseWordsList.CreateAnimalsList(letter));
                        break;
                }
            }

            return _alphabetWords;
        }
    }
}
