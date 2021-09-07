using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public double percentage = 0;
    public string game_mode = "none";
    public string fileName = @"scores.txt";

    private List<TextMeshProUGUI> _gameModeList;
    private List<TextMeshProUGUI> _resultList;
    private List<TextMeshProUGUI> _dateList;
    private string type;
    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(@"scores.txt"))
        {
            StreamWriter sw = new StreamWriter(@"scores.txt", append: true);
            string output = "-|-|-|";
            for(int i  = 0; i < 7; i++)
            {
                sw.WriteLine(output);
            }
            sw.Close();
        }
    }

    void Update()
    {
        show_score();
    }

    public void save_score(string choiceType, string letterOrderType, double percentage, string date)
    {
        switch (choiceType)
        {
            case "ALL":
                type = "Sva slova";
                break;
            case "SA":
                type = "Samoglasnici";
                break;
            case "SU":
                type = "Suglasnici";
                break;
            case "ML":
                type = "Moja slova";
                break;
            case "Prijedlozi":
                type = "Prijedlozi";
                break;
        }

        type += letterOrderType;
     
        StreamWriter sw = new StreamWriter(@"scores.txt", append:true);
        string output = date + "|" + type + "|" + percentage.ToString() + "|";
        sw.WriteLine(output);
        sw.Close();
        if (File.ReadAllLines(@"scores.txt").Count() > 7)
        {
            List<string> lines = File.ReadAllLines(@"scores.txt").ToList();
            File.WriteAllLines(@"scores.txt", lines.GetRange(1, lines.Count-1).ToArray());
        }
    }

    public void show_score()
    {
        _gameModeList = new List<TextMeshProUGUI>()
        {
            GameObject.Find("GameMode1").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("GameMode2").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("GameMode3").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("GameMode4").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("GameMode5").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("GameMode6").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("GameMode7").GetComponent<TextMeshProUGUI>(),
        };

        _resultList = new List<TextMeshProUGUI>()
        {
            GameObject.Find("Result1").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Result2").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Result3").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Result4").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Result5").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Result6").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Result7").GetComponent<TextMeshProUGUI>(),
        };

        _dateList = new List<TextMeshProUGUI>()
        {
            GameObject.Find("Date1").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Date2").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Date3").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Date4").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Date5").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Date6").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Date7").GetComponent<TextMeshProUGUI>(),
        };

        var lines = File.ReadAllLines(@"scores.txt").Reverse();

        int i = 0;
        foreach (string line in lines)
        {
            var listStrLineElements = line.Split('|').ToList();

            _gameModeList[i].text = i + 1 + "." + " " + listStrLineElements[1];
            _resultList[i].text = listStrLineElements[2] + "%";
            _dateList[i].text = listStrLineElements[0];

            i++;
        }
    }
}
