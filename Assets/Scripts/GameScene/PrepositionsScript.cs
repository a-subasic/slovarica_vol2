using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Assets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class PrepositionsScript : MonoBehaviour
{
    private static string[] _prepositions = { "iza", "ispred", "pored", "između", "iznad", "ispod", "u", "na" };
    private TextMeshProUGUI _result;
    private List<TextMeshProUGUI> _prepositionsList;
    private Image _preposition;
    private string _currentPrepositionText;
    private List<Button> _buttonsList;
    private Random _rand = new Random();
    private static int _correctAnswerPosition = 0, _currentIndex;
    AudioSource _audioSource;
    private static AudioClip[] _clip = new AudioClip[3];
    private static bool _hovered;
    private static float _currentStatus, _speed = 15;
    private static Button _hoveredButton;
    private static string _imagesFolder = "Prepositions";
    private static double percentage = 0, count = 0, points = 0;

    void Awake()
    {
        _preposition = GameObject.Find("Preposition").GetComponent<Image>();
        _currentPrepositionText = _preposition.sprite.name;
        _result = GameObject.Find("Result").GetComponent<TextMeshProUGUI>();

        _prepositionsList = new List<TextMeshProUGUI>()
        {
            GameObject.Find("FirstPreposition").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("SecondPreposition").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("ThirdPreposition").GetComponent<TextMeshProUGUI>(),
        };

        _buttonsList = new List<Button>()
        {
            GameObject.Find("FirstImage").GetComponent<Button>(),
            GameObject.Find("SecondImage").GetComponent<Button>(),
            GameObject.Find("ThirdImage").GetComponent<Button>(),
        };

        _result.text = "";
        _currentIndex = 0;
        _hovered = false;

        GenerateScene();
    }

    void Update()
    {
        _result = GameObject.Find("Result").GetComponent<TextMeshProUGUI>();

        if (_hovered)
        {
            if (_currentStatus >= 101)
            {
                _currentStatus = 0;
                _hovered = false;
                CheckAnswer(_hoveredButton);
            }
            else
            {
                _currentStatus += _speed * Time.deltaTime;
            }

            if (_hoveredButton.name.Contains("irst")) GameObject.Find("FirstLoadingBar").GetComponent<Image>().fillAmount = _currentStatus / 100;
            else if (_hoveredButton.name.Contains("econd")) GameObject.Find("SecondLoadingBar").GetComponent<Image>().fillAmount = _currentStatus / 100;
            else if (_hoveredButton.name.Contains("hird")) GameObject.Find("ThirdLoadingBar").GetComponent<Image>().fillAmount = _currentStatus / 100;
        }

        if (_result.text.Equals("Točno"))
        {
            points++;


            try
            {
                _audioSource = GetComponent<AudioSource>();
                var resultAudios = Resources.LoadAll<AudioClip>($"Audios/ResultAudios/Correct");
                _audioSource.PlayOneShot(resultAudios[_rand.Next(resultAudios.Length)]);

            }
            catch (Exception e) { }
            _result.text = "";

            IncreaseCurrentIndex();
            CheckIfGameFinished();
            GenerateScene();
        }
    }

    private void IncreaseCurrentIndex()
    {
        _currentIndex++;   
    }

    private void CheckIfGameFinished()
    {
        if (_currentIndex != _prepositions.Count()) return;
        _currentIndex = 0;

        if (count != 0)
        {
            percentage = (points / count) * 100;
        }
        else
        {
            percentage = 0;
        }
        //GameObject.Find("ScoreScript").GetComponent<ScoreScript>().save_score(Math.Round(percentage, 1), DateTime.Now.ToString("M/d/yyyy"));
        percentage = 0;
        count = 0;
        points = 0;

        SceneManager.LoadScene("Scenes/Game/Slovarica/EndGameScene");
    }

    public void CheckAnswer(Button button)
    {
        var clickedButtonPosition = 0;
        if (button.name.Contains("irst")) clickedButtonPosition = 0;
        else if (button.name.Contains("econd")) clickedButtonPosition = 1;
        else if (button.name.Contains("hird")) clickedButtonPosition = 2;

        _result.text = _correctAnswerPosition == clickedButtonPosition ? "Točno" : "Netočno";

        count++;
        if (_result.text.Equals("Netočno"))
        {
            try
            {
                _audioSource = GetComponent<AudioSource>();
                var resultAudios = Resources.LoadAll<AudioClip>($"Audios/ResultAudios/Wrong");
                _audioSource.PlayOneShot(resultAudios[_rand.Next(resultAudios.Length)]);

            }
            catch (Exception e) { }
            Thread.Sleep(500);
        }
    }

    public void SkipPreposition()
    {
        count++;
        IncreaseCurrentIndex();
        _result.text = "";

        CheckIfGameFinished();
        GenerateScene();
    }

    private void GenerateScene()
    {
        _currentPrepositionText = _prepositions[_rand.Next(_prepositions.Length)];
        _preposition.sprite = Resources.Load<Sprite>($"Images/{_imagesFolder}/mis_{_currentPrepositionText}");

        _correctAnswerPosition = _rand.Next(_prepositionsList.Count);

        var correctPreposition = _currentPrepositionText;

        _prepositionsList[_correctAnswerPosition].text = correctPreposition;
        _buttonsList[_correctAnswerPosition].image.sprite = Resources.Load<Sprite>($"Images/{_imagesFolder}/{correctPreposition.ToLowerInvariant()}");
        _clip[_correctAnswerPosition] = Resources.Load<AudioClip>($"Audios/{_imagesFolder}/{_buttonsList[_correctAnswerPosition].image.sprite.name.ToLowerInvariant()}");

        for (int i = 0; i < _prepositionsList.Count; i++)
        {
            var randomPreposition = GenerateRandomPreposition();

            if (i != _correctAnswerPosition)
            {
                _prepositionsList[i].text = randomPreposition;
                _buttonsList[i].image.sprite = Resources.Load<Sprite>($"Images/{_imagesFolder}/{randomPreposition}");
                _clip[i] = Resources.Load<AudioClip>($"Audios/{_imagesFolder}/{randomPreposition}");
            }
            _prepositionsList[i].autoSizeTextContainer = true;
        }
    }

    private string GenerateRandomPreposition()
    {
        var currentPreposition = _preposition.sprite.name;
        currentPreposition = currentPreposition.Substring(4, currentPreposition.Length - 4);
        Debug.Log(currentPreposition);
        while (true)
        {
            var randomLetterPosition = _rand.Next(_prepositions.Length);
            if (!_prepositions[randomLetterPosition].Equals(currentPreposition)) return _prepositions[randomLetterPosition];
        }
    }

    public void PlayAudio(Button button)
    {
        _audioSource = GetComponent<AudioSource>();

        if (button.name.Contains("irst")) _audioSource.PlayOneShot(_clip[0]);
        else if (button.name.Contains("econd")) _audioSource.PlayOneShot(_clip[1]);
        else if (button.name.Contains("hird")) _audioSource.PlayOneShot(_clip[2]);
    }

    public void ButtonHovered(Button button)
    {
        Debug.Log("entered");
        //Image progress = null, progressLoading = null, progressCenter = null;
        //if (button.name.Contains("irst"))
        //{
        //    progress = GameObject.Find("FirstProgressBar").GetComponent<Image>();
        //    progressLoading = GameObject.Find("FirstLoadingBar").GetComponent<Image>();
        //    progressCenter = GameObject.Find("FirstCenter").GetComponent<Image>();
        //}
        //else if (button.name.Contains("econd"))
        //{
        //    progress = GameObject.Find("SecondProgressBar").GetComponent<Image>();
        //    progressLoading = GameObject.Find("SecondLoadingBar").GetComponent<Image>();
        //    progressCenter = GameObject.Find("SecondCenter").GetComponent<Image>();
        //}
        //else if (button.name.Contains("hird"))
        //{
        //    progress = GameObject.Find("ThirdProgressBar").GetComponent<Image>();
        //    progressLoading = GameObject.Find("ThirdLoadingBar").GetComponent<Image>();
        //    progressCenter = GameObject.Find("ThirdCenter").GetComponent<Image>();
        //}

        //if (!_dwellStatus.Equals("T")) return;
        //progress.enabled = true;
        //progressCenter.enabled = true;
        //progressLoading.enabled = true;
        //_hovered = true;
        //_hoveredButton = button;
    }

    public void ButtonHoverLeft(Button button)
    {
        Debug.Log("left");
        //Image progress = null, progressLoading = null, progressCenter = null;
        //if (button.name.Contains("irst"))
        //{
        //    progress = GameObject.Find("FirstProgressBar").GetComponent<Image>();
        //    progressLoading = GameObject.Find("FirstLoadingBar").GetComponent<Image>();
        //    progressCenter = GameObject.Find("FirstCenter").GetComponent<Image>();
        //}
        //else if (button.name.Contains("econd"))
        //{
        //    progress = GameObject.Find("SecondProgressBar").GetComponent<Image>();
        //    progressLoading = GameObject.Find("SecondLoadingBar").GetComponent<Image>();
        //    progressCenter = GameObject.Find("SecondCenter").GetComponent<Image>();
        //}
        //else if (button.name.Contains("hird"))
        //{
        //    progress = GameObject.Find("ThirdProgressBar").GetComponent<Image>();
        //    progressLoading = GameObject.Find("ThirdLoadingBar").GetComponent<Image>();
        //    progressCenter = GameObject.Find("ThirdCenter").GetComponent<Image>();
        //}

        //if (!_dwellStatus.Equals("T")) return;
        //progress.enabled = false;
        //progressCenter.enabled = false;
        //progressLoading.enabled = false;
        //_hovered = false;
        //_currentStatus = 0;
    }
}
