using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public GameObject[] CheckersArr;
    public GameObject SettingsMenu, Category;
    public string key;
    
    void Start()
    {
        int position = 0;
        if (PlayerPrefs.HasKey(key) is true)
        {
            string current_value = PlayerPrefs.GetString(key);
            Debug.Log("TRENUTNO U REG: " + current_value);
            //pronađi koji bi checker trenutno trebao biti aktivan, upali ga i prikaži na SettingsMenuPanelu
            for (int i = 0; i < CheckersArr.Length; i++)
            {
                if (CheckersArr[i].name.Equals(current_value))
                {
                    position = i;
                    break;
                }
            }
        }
        else
        {
            PlayerPrefs.SetString(key, CheckersArr[position].name);
            PlayerPrefs.Save();
            Debug.Log("INICIJALNO: " + CheckersArr[position].name);
        } 
        
        CheckersArr[position].transform.GetComponent<Toggle>().isOn = true;
        string name = ReadCheckerFullName(position);
        DisplayChoice(name);
    }

    public void SubmitAnswer() {
        int position = ReadCheckersState(CheckersArr);
        PlayerPrefs.SetString(key, CheckersArr[position].name);
        PlayerPrefs.Save();
        string name = ReadCheckerFullName(position);
        DisplayChoice(name);
    }

    string ReadCheckerFullName(int position)
    {
        return CheckersArr[position].transform.Find("Label").GetComponent<TextMeshProUGUI>().text;
    }

    int ReadCheckersState(GameObject[] Checkers) {
        for (int i = 0; i < Checkers.Length; i++) {
            if (Checkers[i].transform.GetComponent<Toggle>().isOn) {
                return i;
            }
        }
        return 0;
    }

    public void DisplayChoice(string name)
    {
        string path = "PostavkePanel/" + Category.name + "/SelectedOption";
        SettingsMenu.transform.Find(path).GetComponent<TextMeshProUGUI>().text = name;
    }
}