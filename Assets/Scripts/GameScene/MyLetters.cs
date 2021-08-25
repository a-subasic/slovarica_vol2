using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utils;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyLetters : MonoBehaviour
{
    public Text selectedLetters;
    public GameObject letters;
    public GameObject ML_cheker;
    private Button[] letterButtons;
    private string value = "";
    public void Start()
    {
        
        //na početku prikaži stanje u registru, ako ga nema postavi inicijalno 
        string tmp = "";
        string key = "MYLETTERS";
        if (PlayerPrefs.HasKey(key))
        {
            tmp = PlayerPrefs.GetString(key);
            Debug.Log("TRENUTNO U REGISTRU: " + tmp);
        }
        else
        {
            tmp = "A,B,C,D";
            PlayerPrefs.SetString(key, tmp);
            PlayerPrefs.Save();
            Debug.Log("POSTAVLJAM INICIJALNO: A, B, C, D");
        } 
        selectedLetters.text = tmp;
        
        letterButtons = letters.GetComponentsInChildren<Button>();
        for (int i = 0; i < letterButtons.Length; i++)
        {
            Button btn = letterButtons[i];
            btn.onClick.AddListener(() => ToggleLetterButton(btn));
        }
    }

    public void SubmitMyAnswer()
    {
        //ako smo samo ušli pogledati što ima i idemo klik spremi, spremi ono što je već u registru, inače ono što smo utipkali
        if (value == "")
        {
            value = PlayerPrefs.GetString("MYLETTERS");
        }
        Debug.Log("Spremam:" + value);
        PlayerPrefs.SetString("MYLETTERS", value);
        PlayerPrefs.Save();
        
        //za svaki slučaj upali cheker "MOJA SLOVA" 
        ML_cheker.transform.GetComponent<Toggle>().isOn = true;
    }
    
    void ToggleLetterButton(Button btn)
    {
        ColorBlock colors = btn.colors;
        Color pressedButtonColor = new Color32(0, 86, 120, 168);
        if (colors.normalColor == Color.white)
        {
            colors.normalColor = pressedButtonColor;
            colors.selectedColor = pressedButtonColor;
        }
        else if (colors.normalColor == pressedButtonColor)
        {
            colors.normalColor = Color.white;
            colors.selectedColor = Color.white;
        }

        btn.colors = colors;

        List<string> selectedLettersList = new List<string>();

        for (int i = 0; i < letterButtons.Length; i++)
        {
            if (letterButtons[i].colors.normalColor == pressedButtonColor)
            {
                selectedLettersList.Add(letterButtons[i].GetComponentInChildren<TextMeshProUGUI>().text);
            }
            selectedLetters.text = String.Join(",", selectedLettersList.ToArray());
        }
        value = String.Join(",", selectedLettersList.ToArray());
    }
}