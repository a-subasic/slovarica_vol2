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

    //public string date;



    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(@"scores.txt"))
        {
            StreamWriter sw = new StreamWriter(@"scores.txt", append: true);
            string output = "-|-||";
            for(int i  = 0; i < 6; i++)
            {
                sw.WriteLine(output);
            }
            sw.Close();
        }
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void save_score(double percentage, string date)
    {
        StreamWriter sw = new StreamWriter(@"scores.txt", append:true);
        string output = date + "|" + percentage.ToString() + "||";
        sw.WriteLine(output);
        sw.Close();
        if (File.ReadAllLines(@"scores.txt").Count() > 6)
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
        };

        _resultList = new List<TextMeshProUGUI>()
        {
            GameObject.Find("Result1").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Result2").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Result3").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Result4").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Result5").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("Result6").GetComponent<TextMeshProUGUI>(),
        };

        var lines = File.ReadAllLines(@"scores.txt").Reverse();

        int i = 0;
        foreach (string line in lines)
        {
            int To1 = line.IndexOf("|") + "|".Length;
            int From2 = line.IndexOf("|") + "|".Length;
            int To2 = line.LastIndexOf("||");

            _gameModeList[i].text = line.Substring(0, To1-1);
            if ("-".Equals(line.Substring(From2, To2 - From2)))
            {
                _resultList[i].text = line.Substring(From2, To2 - From2);
            } else
            {
                _resultList[i].text = line.Substring(From2, To2 - From2) + "%";
            }
            

            i++;
            //Debug.Log(line.Substring(0, To1 - 0) + " *** " + line.Substring(From2, To2 - From2 ));
        }
    }
}
