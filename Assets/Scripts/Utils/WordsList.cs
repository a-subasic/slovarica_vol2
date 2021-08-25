using System;
using System.Collections.Generic;

namespace Assets.Scripts.Utils
{
    static class WordsList
    {
        private static List<string> _wordsList;
        public static List<string> CreateBasicAlphabetList(string letter)
        {
            switch (letter)
            {
                case "A":
                    _wordsList = new List<string>() { "Akvarij", "Ananas", "Auto", "Autobus", "Avion" };
                    break;
                case "B":
                    _wordsList = new List<string>() { "Bačva", "Banana", "Bicikla", "Bubamara", "Balon" };
                    break;
                case "C":
                    _wordsList = new List<string>() { "Cesta", "Cipela", "Crv", "Cvijet", "Cvrčak" };
                    break;
                case "Č":
                    _wordsList = new List<string>() { "Čarape", "Čaša", "Čavli", "Čekić", "Četkica" };
                    break;
                case "Ć":
                    _wordsList = new List<string>() { "Ćevap", "Ćup", "Ćuk" };
                    break;
                case "D":
                    _wordsList = new List<string>() { "Drvo", "Duga", "Dugme", "Dupin", "Dvorac" };
                    break;
                case "DŽ":
                    _wordsList = new List<string>() { "Džem", "Džemper", "Džip" };
                    break;
                case "Đ":
                    _wordsList = new List<string>() { "Đak" };
                    break;
                case "E":
                    _wordsList = new List<string>() { "Epruvete", "Eskim" };
                    break;
                case "F":
                    _wordsList = new List<string>() { "Fen", "Flauta", "Fotelja", "Fotoaparat", "Frizbi" };
                    break;
                case "G":
                    _wordsList = new List<string>() { "Gljiva", "Golub", "Grozd", "Guska", "Gitara" };
                    break;
                case "H":
                    _wordsList = new List<string>() { "Haljina", "Hamburger", "Hlače", "Hladnjak", "Hobotnica" };
                    break;
                case "I":
                    _wordsList = new List<string>() { "Igla", "Iglu", "Igrica", "Injekcija" };
                    break;
                case "J":
                    _wordsList = new List<string>() { "Jabuka", "Jaje", "Jakna", "Japanke", "Jastuci" };
                    break;
                case "K":
                    _wordsList = new List<string>() { "Kišobran", "Klavir", "Konj", "Krava", "Kruna" };
                    break;
                case "L":
                    _wordsList = new List<string>() { "Lak", "Lampa", "Lav", "Limun", "Lopta" };
                    break;
                case "LJ":
                    _wordsList = new List<string>() { "Ljepilo", "Ljubičica", "Ljuljačka" };
                    break;
                case "M":
                    _wordsList = new List<string>() { "Mačka", "Metla", "Miš", "Mrav", "Mrkva" };
                    break;
                case "N":
                    _wordsList = new List<string>() { "Naočale", "Naranča", "Noj", "Nos", "Nož", };
                    break;
                case "NJ":
                    _wordsList = new List<string>() { "Njoki", "Njuška" };
                    break;
                case "O":
                    _wordsList = new List<string>() { "Ogrlica", "Oko", "Olovka", "Orao", "Ormar" };
                    break;
                case "P":
                    _wordsList = new List<string>() { "Pauk", "Pingvin", "Pismo", "Prsten", "Puž" };
                    break;
                case "R":
                    _wordsList = new List<string>() { "Reket", "Riba", "Robot", "Romobil", "Ruksak" };
                    break;
                case "S":
                    _wordsList = new List<string>() { "Sat", "Slon", "Stol", "Sunce", "Svijeća" };
                    break;
                case "Š":
                    _wordsList = new List<string>() { "Šator", "Šešir", "Šibica", "Šiljilo", "Šišmiš" };
                    break;
                case "T":
                    _wordsList = new List<string>() { "Tava", "Televizor", "Torta", "Traktor", "Trava" };
                    break;
                case "U":
                    _wordsList = new List<string>() { "Udica", "Uho", "Ukosnica", "Usne", "Utičnica" };
                    break;
                case "V":
                    _wordsList = new List<string>() { "Vilica", "Vješalica", "Vjeverica", "Vrećica", "Vatra" };
                    break;
                case "Z":
                    _wordsList = new List<string>() { "Zmija", "Zec", "Zub", "Zvijezda", "Zvono" };
                    break;
                case "Ž":
                    _wordsList = new List<string>() { "Žaba", "Žarulja", "Žir", "Žirafa", "Žlica" };
                    break;
                default:
                    throw new ArgumentException(message: "Invalid letter");
            }

            return _wordsList;
        }

        public static List<string> CreateAnimalsList(string letter)
        {
            switch (letter)
            {
                case "A":
                    _wordsList = new List<string>() { "Antilopa" };
                    break;
                case "B":
                    _wordsList = new List<string>() { "Bik" };
                    break;
                case "C":
                    _wordsList = new List<string>() { "Crv" };
                    break;
                case "Č":
                    _wordsList = new List<string>() { "Čaplja" };
                    break;
                case "Ć":
                    _wordsList = new List<string>() { "Ćuk" };
                    break;
                case "D":
                    _wordsList = new List<string>() { "Deva" };
                    break;
                case "DŽ":
                    _wordsList = new List<string>() { "" };
                    break;
                case "Đ":
                    _wordsList = new List<string>() { "" };
                    break;
                case "E":
                    _wordsList = new List<string>() { "Emu" };
                    break;
                case "F":
                    _wordsList = new List<string>() { "Flamingo" };
                    break;
                case "G":
                    _wordsList = new List<string>() { "Golub"};
                    break;
                case "H":
                    _wordsList = new List<string>() { "Hobotnica" };
                    break;
                case "I":
                    _wordsList = new List<string>() { "Insekt" };
                    break;
                case "J":
                    _wordsList = new List<string>() { "Jež" };
                    break;
                case "K":
                    _wordsList = new List<string>() { "Klokan" };
                    break;
                case "L":
                    _wordsList = new List<string>() { "Leptir" };
                    break;
                case "LJ":
                    _wordsList = new List<string>() { "Ljenjivac" };
                    break;
                case "M":
                    _wordsList = new List<string>() { "Majmun" };
                    break;
                case "N":
                    _wordsList = new List<string>() { "Nosorog" };
                    break;
                case "NJ":
                    _wordsList = new List<string>() { "" };
                    break;
                case "O":
                    _wordsList = new List<string>() { "Ovca" };
                    break;
                case "P":
                    _wordsList = new List<string>() { "Pas" };
                    break;
                case "R":
                    _wordsList = new List<string>() { "Rak" };
                    break;
                case "S":
                    _wordsList = new List<string>() { "Svinja" };
                    break;
                case "Š":
                    _wordsList = new List<string>() { "Škorpion" };
                    break;
                case "T":
                    _wordsList = new List<string>() { "Tigar" };
                    break;
                case "U":
                    _wordsList = new List<string>() { "" };
                    break;
                case "V":
                    _wordsList = new List<string>() { "Vjeverica" };
                    break;
                case "Z":
                    _wordsList = new List<string>() { "Zebra" };
                    break;
                case "Ž":
                    _wordsList = new List<string>() { "Žirafa" };
                    break;
                default:
                    throw new ArgumentException(message: "Invalid letter");
            }

            return _wordsList;
        }

        public static List<string> CreateFoodList(string letter)
        {
            switch (letter)
            {
                case "A":
                    _wordsList = new List<string>() { "Ananas" };
                    break;
                case "B":
                    _wordsList = new List<string>() { "Bundeva" };
                    break;
                case "C":
                    _wordsList = new List<string>() { "Cedevita" };
                    break;
                case "Č":
                    _wordsList = new List<string>() { "Čips" };
                    break;
                case "Ć":
                    _wordsList = new List<string>() { "Ćevap" };
                    break;
                case "D":
                    _wordsList = new List<string>() { "Dinja" };
                    break;
                case "DŽ":
                    _wordsList = new List<string>() { "Džem" };
                    break;
                case "Đ":
                    _wordsList = new List<string>() { "Đuveđ" };
                    break;
                case "E":
                    _wordsList = new List<string>() { "" };
                    break;
                case "F":
                    _wordsList = new List<string>() { "Feferoni" };
                    break;
                case "G":
                    _wordsList = new List<string>() { "Grašak" };
                    break;
                case "H":
                    _wordsList = new List<string>() { "Hrenovke" };
                    break;
                case "I":
                    _wordsList = new List<string>() { "" };
                    break;
                case "J":
                    _wordsList = new List<string>() { "Jagoda" };
                    break;
                case "K":
                    _wordsList = new List<string>() { "Kukuruz" };
                    break;
                case "L":
                    _wordsList = new List<string>() { "Lubenica" };
                    break;
                case "LJ":
                    _wordsList = new List<string>() { "Lješnjak" };
                    break;
                case "M":
                    _wordsList = new List<string>() { "Mrkva" };
                    break;
                case "N":
                    _wordsList = new List<string>() { "Nutela" };
                    break;
                case "NJ":
                    _wordsList = new List<string>() { "Njoki" };
                    break;
                case "O":
                    _wordsList = new List<string>() { "Orah" };
                    break;
                case "P":
                    _wordsList = new List<string>() { "Paprika" };
                    break;
                case "R":
                    _wordsList = new List<string>() { "Rajčica" };
                    break;
                case "S":
                    _wordsList = new List<string>() { "Sendvić" };
                    break;
                case "Š":
                    _wordsList = new List<string>() { "Špinat" };
                    break;
                case "T":
                    _wordsList = new List<string>() { "Tost" };
                    break;
                case "U":
                    _wordsList = new List<string>() { "Umak" };
                    break;
                case "V":
                    _wordsList = new List<string>() { "Višnja" };
                    break;
                case "Z":
                    _wordsList = new List<string>() { "Zob" };
                    break;
                case "Ž":
                    _wordsList = new List<string>() { "Žitarice" };
                    break;
                default:
                    throw new ArgumentException(message: "Invalid letter");
            }

            return _wordsList;
        }
    }
}
