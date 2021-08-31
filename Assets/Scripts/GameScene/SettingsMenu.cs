﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject LetterChecker; //checker za veliko slovo A
    public GameObject DwellChecker;

    void Start() {
      
        if (PlayerPrefs.HasKey("LETTER") is true)
        {
            string value = PlayerPrefs.GetString("LETTER");
            Debug.Log("VRIJEDNOST U REG:" + value);
            if (value.Equals("A")) LetterChecker.transform.GetComponent<Toggle>().isOn = true;
            else LetterChecker.transform.GetComponent<Toggle>().isOn = false;
        }
        else
        {
            PlayerPrefs.SetString("LETTER", "A");
            PlayerPrefs.Save();
            Debug.Log("INICIJALNO: A");
        }
    
        ////LOGIKA ZA DWELL TIME
        if (PlayerPrefs.HasKey("DWELL") is true)
        {
            string value = PlayerPrefs.GetString("DWELL");
            Debug.Log("DWELL U REG:" + value);
            if(value.Equals("T")) DwellChecker.transform.GetComponent<Toggle>().isOn = true;
            else DwellChecker.transform.GetComponent<Toggle>().isOn = false;
        }
        else //inicijalno postavi na false
        {
            PlayerPrefs.SetString("DWELL", "F");
            PlayerPrefs.Save();
            Debug.Log("INICIJALNO DWELL: FALSE" );
        }
    }

    public void SubmitAnswer()
    {
        bool letter = ReadCheckers(LetterChecker);
        if (letter is true) PlayerPrefs.SetString("LETTER", "A");
        else PlayerPrefs.SetString("LETTER", "a");
        PlayerPrefs.Save();

        bool dwell = ReadCheckers(DwellChecker);
        if (dwell is true)
        {
            PlayerPrefs.SetString("DWELL", "T");
        }
        else PlayerPrefs.SetString("DWELL", "F");
        PlayerPrefs.Save();
    }


    bool ReadCheckers(GameObject check) {
        if (check.transform.GetComponent<Toggle>().isOn) return true;
        return false;
    }

}

