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
    private static string[] _sentences = { "Zec se nalazi ____ stabla.", "Slon se nalazi ____ stolice.", "Djevojčica sjedi ____ kutije.", "Mačka se nalazi ____ dva psa.", "Ptica leti ____ kutije.", "Pas spava ____ stola.", "Ptica sjedi ____ gnijezdu.", "Medvjedić stoji ____ stolu." };
    List<int> shownPrepositions = new List<int>();
    private TextMeshProUGUI _result;
    private TextMeshProUGUI _sentence;
    private List<TextMeshProUGUI> _prepositionsList;
    private Image _preposition;
    private string _currentPrepositionText;
    private List<Button> _buttonsList;
    private Random _rand = new Random();
    private static int _correctAnswerPosition = 0, _currentIndex;
    AudioSource _audioSource;
    private static AudioClip[] _clip = new AudioClip[3];
    private static AudioClip _sentenceClip;
    private static AudioClip _questionClip;
    private static bool _hovered;
    private static float _currentStatus, _speed = 15;
    private static Button _hoveredButton;
    private static Button _questionButton;
    private static string _imagesFolder = "Prepositions";
    private static double percentage = 0, count = 0, points = 0;
    private string _dwellStatus;
    private int rand;

    void Awake()
    {
        _dwellStatus = PlayerPrefs.GetString("DWELL");

        _preposition = GameObject.Find("Preposition").GetComponent<Image>();
        _currentPrepositionText = _preposition.sprite.name;
        _result = GameObject.Find("Result").GetComponent<TextMeshProUGUI>();
        _sentence = GameObject.Find("Sentence").GetComponent<TextMeshProUGUI>();
        _questionButton = GameObject.Find("QuestionAudio").GetComponent<Button>();

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
        _dwellStatus = PlayerPrefs.GetString("DWELL");
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
                if (_audioSource == null) _audioSource = gameObject.AddComponent<AudioSource>();

                var resultAudios = Resources.LoadAll<AudioClip>($"Audios/ResultAudios/Correct");
                var r = _rand.Next(resultAudios.Length);
                var resultAudio = resultAudios[r];
                _audioSource.PlayOneShot(resultAudio);
                _audioSource.clip = resultAudio;

                if (_audioSource.clip)
                    Invoke("NextPreposition", _audioSource.clip.length + 1);
            }

            catch (Exception e) { Debug.Log(e); }
            _result.text = "";
        }
    }

    void NextPreposition()
    {
        IncreaseCurrentIndex();
        CheckIfGameFinished();
    }

    private void IncreaseCurrentIndex()
    {
        _currentIndex++;   
    }

    private void CheckIfGameFinished()
    {
        if (_currentIndex != _prepositions.Count())
        {
            GenerateScene();
            return;
        }
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

        SceneManager.LoadScene("Scenes/Game/Slovarica/EndGamePrepositions");
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
                if (_audioSource == null) _audioSource = gameObject.AddComponent<AudioSource>();
                var resultAudios = Resources.LoadAll<AudioClip>($"Audios/ResultAudios/Wrong");
                _audioSource.PlayOneShot(resultAudios[_rand.Next(resultAudios.Length)]);
            }
            catch (Exception e) { Debug.Log(e); }
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
        var rand = 0;

        if (!_dwellStatus.Equals("T"))
        {
            rand = _rand.Next(_prepositions.Length);
            while(shownPrepositions.Contains(rand)) rand = _rand.Next(_prepositions.Length);
            shownPrepositions.Add(rand);
        }
        else
        {
            rand = _currentIndex;
        }

        _currentPrepositionText = _prepositions[rand];

        _sentence.text = _sentences[rand];
        _sentenceClip = Resources.Load<AudioClip>($"Audios/{_imagesFolder}/Sentences/{_currentPrepositionText}");

        _preposition.sprite = Resources.Load<Sprite>($"Images/{_imagesFolder}/mis_{_currentPrepositionText}");

        _correctAnswerPosition = _rand.Next(_prepositionsList.Count);

        var correctPreposition = _currentPrepositionText;

        _prepositionsList[_correctAnswerPosition].text = correctPreposition;
        _buttonsList[_correctAnswerPosition].image.sprite = Resources.Load<Sprite>($"Images/{_imagesFolder}/{correctPreposition.ToLowerInvariant()}");
        _clip[_correctAnswerPosition] = Resources.Load<AudioClip>($"Audios/{_imagesFolder}/{_buttonsList[_correctAnswerPosition].image.sprite.name.ToLowerInvariant()}");

        for (int i = 0; i < _prepositionsList.Count; i++)
        {
            var randomPreposition = GenerateRandomPreposition(i);

            if (i != _correctAnswerPosition)
            {
                _prepositionsList[i].text = randomPreposition;
                _buttonsList[i].image.sprite = Resources.Load<Sprite>($"Images/{_imagesFolder}/{randomPreposition}");
                _clip[i] = Resources.Load<AudioClip>($"Audios/{_imagesFolder}/{randomPreposition}");
            }
            _prepositionsList[i].autoSizeTextContainer = true;
        }

        _questionClip = Resources.Load<AudioClip>($"Audios/{_imagesFolder}/Sentences/Questions/{_currentPrepositionText}");
        PlayAudio(_questionButton);
    }

    private string GenerateRandomPreposition(int currentIndex)
    {
        var currentPreposition = _preposition.sprite.name;
        currentPreposition = currentPreposition.Substring(4, currentPreposition.Length - 4);

        var otherPreposition = 0;

        for(int i = 0; i < 3; i++)
        {
            if (i != _correctAnswerPosition && i != currentIndex) 
                otherPreposition = i;
        }
       
        while (true)
        {
            var randomPrepositionPosition = _rand.Next(_prepositions.Length);

            if (!_prepositions[randomPrepositionPosition].Equals(currentPreposition) && !_prepositions[randomPrepositionPosition].Equals(_prepositionsList[otherPreposition].text)) 
                return _prepositions[randomPrepositionPosition];
             
        }
    }

    public void PlayAudio(Button button)
    {
        _audioSource = GetComponent<AudioSource>();
        
        if (_audioSource == null) return;

        if (button.name.Contains("irst")) _audioSource.PlayOneShot(_clip[0]);
        else if (button.name.Contains("econd")) _audioSource.PlayOneShot(_clip[1]);
        else if (button.name.Contains("hird")) _audioSource.PlayOneShot(_clip[2]);
        else if (button.name.Contains("entence")) _audioSource.PlayOneShot(_sentenceClip);
        else if (button.name.Contains("uestion")) _audioSource.PlayOneShot(_questionClip);
    }

    public void ButtonHovered(Button button)
    {
        Image progress = null, progressLoading = null, progressCenter = null;
        if (button.name.Contains("irst"))
        {
            progress = GameObject.Find("FirstProgressBar").GetComponent<Image>();
            progressLoading = GameObject.Find("FirstLoadingBar").GetComponent<Image>();
            progressCenter = GameObject.Find("FirstCenter").GetComponent<Image>();
        }
        else if (button.name.Contains("econd"))
        {
            progress = GameObject.Find("SecondProgressBar").GetComponent<Image>();
            progressLoading = GameObject.Find("SecondLoadingBar").GetComponent<Image>();
            progressCenter = GameObject.Find("SecondCenter").GetComponent<Image>();
        }
        else if (button.name.Contains("hird"))
        {
            progress = GameObject.Find("ThirdProgressBar").GetComponent<Image>();
            progressLoading = GameObject.Find("ThirdLoadingBar").GetComponent<Image>();
            progressCenter = GameObject.Find("ThirdCenter").GetComponent<Image>();
        }

        if (!_dwellStatus.Equals("T")) return;
        progress.enabled = true;
        progressCenter.enabled = true;
        progressLoading.enabled = true;
        _hovered = true;
        _hoveredButton = button;
    }

    public void ButtonHoverLeft(Button button)
    {
        Image progress = null, progressLoading = null, progressCenter = null;
        if (button.name.Contains("irst"))
        {
            progress = GameObject.Find("FirstProgressBar").GetComponent<Image>();
            progressLoading = GameObject.Find("FirstLoadingBar").GetComponent<Image>();
            progressCenter = GameObject.Find("FirstCenter").GetComponent<Image>();
        }
        else if (button.name.Contains("econd"))
        {
            progress = GameObject.Find("SecondProgressBar").GetComponent<Image>();
            progressLoading = GameObject.Find("SecondLoadingBar").GetComponent<Image>();
            progressCenter = GameObject.Find("SecondCenter").GetComponent<Image>();
        }
        else if (button.name.Contains("hird"))
        {
            progress = GameObject.Find("ThirdProgressBar").GetComponent<Image>();
            progressLoading = GameObject.Find("ThirdLoadingBar").GetComponent<Image>();
            progressCenter = GameObject.Find("ThirdCenter").GetComponent<Image>();
        }

        if (!_dwellStatus.Equals("T")) return;
        progress.enabled = false;
        progressCenter.enabled = false;
        progressLoading.enabled = false;
        _hovered = false;
        _currentStatus = 0;
    }
}
