using System;
using System.Collections.Generic;

namespace Assets.Scripts.Utils
{
    static class ReverseWordsList
    {
        private static List<string> _reverseWordsList;
        public static List<string> CreateBasicAlphabetList(string letter)
        {
            switch (letter)
            {
                case "A":
                    _reverseWordsList = new List<string>() { 
                        "Bačva", "Banana", "Bicikla", "Bubamara", "Cesta", "Cipela","Čaša","Četkica","Duga","Flauta","Fotelja","Gljiva","Guska","Gitara","Haljina",
                        "Hobotnica","Igla","Igrica","Injekcija","Jabuka","Jakna","Krava","Kruna","Lampa","Lopta","Ljubičica","Ljuljačka","Mačka","Metla","Mrkva",
                        "Naranča","Njuška","Ogrlica","Olovka","Riba","Svijeća","Šibica","Tava","Torta","Trava","Udica","Ukosnica","Utičnica","Vilica","Vješalica",
                        "Vjeverica","Vrećica","Vatra","Zmija","Zvijezda","Žaba","Žarulja","Žirafa","Žlica" };
                    break;
                case "B":
                    _reverseWordsList = new List<string>() { "Zub" };
                    break;
                case "C":
                    _reverseWordsList = new List<string>() { "Dvorac", "Zec" };
                    break;
                case "Č":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "Ć":
                    _reverseWordsList = new List<string>() { "Čekić" };
                    break;
                case "D":
                    _reverseWordsList = new List<string>() { "Grozd" };
                    break;
                case "DŽ":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "Đ":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "E":
                    _reverseWordsList = new List<string>() { "Čarape", "Dugme", "Epruvete", "Hlače", "Jaje", "Japanke", "Naočale", "Sunce", "Usne" };
                    break;
                case "F":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "G":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "H":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "I":
                    _reverseWordsList = new List<string>() { "Čavli", "Frizbi", "Jastuci", "Njoki" };
                    break;
                case "J":
                    _reverseWordsList = new List<string>() { "Akvarij", "Noj" };
                    break;
                case "K":
                    _reverseWordsList = new List<string>() { "Cvrčak", "Đak", "Hladnjak", "Lak", "Ruksak" };
                    break;
                case "L":
                    _reverseWordsList = new List<string>() { "Romobil", "Stol" };
                    break;
                case "LJ":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "M":
                    _reverseWordsList = new List<string>() { "Džem", "Eskim" };
                    break;
                case "N":
                    _reverseWordsList = new List<string>() { "Avion", "Balon", "Dupin", "Fen", "Limun", "Pingvin", "Slon" };
                    break;
                case "NJ":
                    _reverseWordsList = new List<string>() { "Konj" };
                    break;
                case "O":
                    _reverseWordsList = new List<string>() { "Auto", "Drvo", "Ljepilo", "Oko", "Orao", "Pismo", "Šiljilo", "Uho", "Zvono" };
                    break;
                case "P":
                    _reverseWordsList = new List<string>() { "Ćevap", "Ćup", "Džip" };
                    break;
                case "R":
                    _reverseWordsList = new List<string>() { "Ormar", "Šator", "Šešir", "Televizor", "Traktor", "Žir" };
                    break;
                case "S":
                    _reverseWordsList = new List<string>() { "Ananas", "Autobus", "Nos" };
                    break;
                case "Š":
                    _reverseWordsList = new List<string>() { "Miš", "Šišmiš" };
                    break;
                case "T":
                    _reverseWordsList = new List<string>() { "Fotoaparat", "Reket", "Robot", "Sat" };
                    break;
                case "U":
                    _reverseWordsList = new List<string>() { "Iglu" };
                    break;
                case "V":
                    _reverseWordsList = new List<string>() { "Lav", "Mrav" };
                    break;
                case "Z":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "Ž":
                    _reverseWordsList = new List<string>() { "Nož", "Puž" };
                    break;
                default:
                    throw new ArgumentException(message: "Invalid letter");
            }

            return _reverseWordsList;
        }

        public static List<string> CreateAnimalsList(string letter)
        {
            switch (letter)
            {
                case "A":
                    _reverseWordsList = new List<string>() { "Antilopa" };
                    break;
                case "B":
                    _reverseWordsList = new List<string>() { "Golub" };
                    break;
                case "C":
                    _reverseWordsList = new List<string>() { "Ljenjivac" };
                    break;
                case "Č":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "Ć":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "D":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "DŽ":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "Đ":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "E":
                    _reverseWordsList = new List<string>() { "Emu" };
                    break;
                case "F":
                    _reverseWordsList = new List<string>() { "Flamingo" };
                    break;
                case "G":
                    _reverseWordsList = new List<string>() { "Nosorog" };
                    break;
                case "H":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "I":
                    _reverseWordsList = new List<string>() { "Insekt" };
                    break;
                case "J":
                    _reverseWordsList = new List<string>() { "Jež" };
                    break;
                case "K":
                    _reverseWordsList = new List<string>() { "Bik" };
                    break;
                case "L":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "LJ":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "M":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "N":
                    _reverseWordsList = new List<string>() { "Klokan" };
                    break;
                case "NJ":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "O":
                    _reverseWordsList = new List<string>() { "Flamingo" };
                    break;
                case "P":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "R":
                    _reverseWordsList = new List<string>() { "Tigar" };
                    break;
                case "S":
                    _reverseWordsList = new List<string>() { "Pas" };
                    break;
                case "Š":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "T":
                    _reverseWordsList = new List<string>() { "Insekt" };
                    break;
                case "U":
                    _reverseWordsList = new List<string>() { "Emu" };
                    break;
                case "V":
                    _reverseWordsList = new List<string>() { "Crv" };
                    break;
                case "Z":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "Ž":
                    _reverseWordsList = new List<string>() { };
                    break;
                default:
                    throw new ArgumentException(message: "Invalid letter");
            }

            return _reverseWordsList;
        }

        public static List<string> CreateFoodList(string letter)
        {
            switch (letter)
            {
                case "A":
                    _reverseWordsList = new List<string>() { "Bundeva" };
                    break;
                case "B":
                    _reverseWordsList = new List<string>() { "Zob" };
                    break;
                case "C":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "Č":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "Ć":
                    _reverseWordsList = new List<string>() { "Sendvić" };
                    break;
                case "D":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "DŽ":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "Đ":
                    _reverseWordsList = new List<string>() { "Đuveđ" };
                    break;
                case "E":
                    _reverseWordsList = new List<string>() { "Žitarice" };
                    break;
                case "F":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "G":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "H":
                    _reverseWordsList = new List<string>() { "Orah" };
                    break;
                case "I":
                    _reverseWordsList = new List<string>() { "Njoki" };
                    break;
                case "J":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "K":
                    _reverseWordsList = new List<string>() { "Grašak" };
                    break;
                case "L":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "LJ":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "M":
                    _reverseWordsList = new List<string>() { "Džem" };
                    break;
                case "N":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "NJ":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "O":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "P":
                    _reverseWordsList = new List<string>() { "Ćevap" };
                    break;
                case "R":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "S":
                    _reverseWordsList = new List<string>() { "Ananas" };
                    break;
                case "Š":
                    _reverseWordsList = new List<string>() { }; ;
                    break;
                case "T":
                    _reverseWordsList = new List<string>() { "Tost" };
                    break;
                case "U":
                    _reverseWordsList = new List<string>() { }; 
                    break;
                case "V":
                    _reverseWordsList = new List<string>() { };
                    break;
                case "Z":
                    _reverseWordsList = new List<string>() { "Kukuruz" };
                    break;
                case "Ž":
                    _reverseWordsList = new List<string>() { };
                    break;
                default:
                    throw new ArgumentException(message: "Invalid letter");
            }

            return _reverseWordsList;
        }
    }
}
