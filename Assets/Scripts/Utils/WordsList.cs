using System;
using System.Collections.Generic;

namespace Assets.Scripts.Utils
{
    static class WordsList
    {
        private static List<string> _wordsList;
        public static List<string> CreateWordsList(string letter)
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
           /* letter switch
            {
                "A" => new List<string>() { "Auto", "Avion", "Ananas" },
                "B" => new List<string>() { "Brod", "Bicikla", "Bor" },
                "C" => new List<string>() { "Cipela", "Crv", "C" },
                "D" => new List<string>() { "Drvo", "Dabar", "Duh" },
                "E" => new List<string>() { "Eskim", "E", "E" },
                "F" => new List<string>() { "Flauta", "F", "F" },
                "G" => new List<string>() { "Gljiva", "Glava", "G" },
                "H" => new List<string>() { "Hrčak", "Helikopter", "H" },
                "I" => new List<string>() { "Igla", "Iglu", "I" },
                "J" => new List<string>() { "Jakna", "Jastuk", "Jabuka" },
                "K" => new List<string>() { "Kruška", "Kišobran", "Kuća" },
                "L" => new List<string>() { "Lav", "Leptir", "List" },
                "LJ" => new List<string>() { "Ljuljačka", "Ljubičica", "Lj" },
                "M" => new List<string>() { "Mrkva", "Mrav", "Miš" },
                "N" => new List<string>() { "Naranča", "Nos", "Nit" },
                "NJ" => new List<string>() { "Njok", "Nj", "Nj" },
                "O" => new List<string>() { "Osa", "Oblak", "Olovka" },
                "P" => new List<string>() { "Pas", "Ptica", "Prasac" },
                "R" => new List<string>() { "Riba", "Rak", "Ruža" },
                "S" => new List<string>() { "Staklo", "Slon", "Sir" },
                "Š" => new List<string>() { "Šišmiš", "Šal", "Šalica" },
                "T" => new List<string>() { "Traktor", "Torba", "Torta" },
                "U" => new List<string>() { "Usne", "Uho", "Udica" },
                "V" => new List<string>() { "Vlak", "Višnja", "Vrata" },
                "Z" => new List<string>() { "Zid", "Zastava", "Zlato" },
                "Ž" => new List<string>() { "Žaba", "Žito", "Ž" },
                _ => throw new ArgumentException(message: "Invalid letter"),
            };*/
        }
    }
}
