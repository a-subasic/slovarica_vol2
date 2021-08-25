using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utils;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Početne postavke, ABECEDNO, CIJELA ABECEDA, OPĆI POJMOVI
 */

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(Button button)
    {
        SceneManager.LoadScene(button.name);
    }

    public void QuitGame()
    {   
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void LoadSettingsScene()
    {
        GameScript.SetCreateDictionaryState();
        SceneManager.LoadScene("Scenes/Main");
    }

    public void LoadPrepositionsScene()
    {
        GameScript.SetCreateDictionaryState();
        SceneManager.LoadScene("Scenes/Game/Slovarica/Prepositions");
    }

    public void ResetGame()
    {
        GameScript.SetCreateDictionaryState();
        SceneManager.LoadScene("Scenes/Game/Slovarica/Alphabet");
    }
}
