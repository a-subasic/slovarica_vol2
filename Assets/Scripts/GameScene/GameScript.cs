using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Assets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class GameScript : MonoBehaviour
{
    private static string[] _letters = { "A", "B", "C", "Č", "Ć", "D", "DŽ", "Đ", "E", "F", "G", "H", "I", "J", "K", "L", "LJ", "M", "N", "NJ", "O", "P", "R", "S", "Š", "T", "U", "V", "Z", "Ž" }; 
    private static Dictionary<string, List<string>> _alphabetDictionary;
    private TextMeshProUGUI _letter, _result;
    private List<TextMeshProUGUI> _wordsList;
    private List<Button> _buttonsList;
    private Random _rand = new Random();
    private static int _correctAnswerPosition = 0, _currentIndex;
    AudioSource _audioSource;
    private static AudioClip[] _clip = new AudioClip[3];
    private static bool _createDictionary = true, _hovered;
    private static float _currentStatus, _speed = 15;
    private static Button _hoveredButton;

    void Awake()
    {
        if (_createDictionary) _alphabetDictionary = AlphabetDictionary.CreateDictionary();

        _letter = GameObject.Find("Letter").GetComponent<TextMeshProUGUI>();
        _result = GameObject.Find("Result").GetComponent<TextMeshProUGUI>();

        _wordsList = new List<TextMeshProUGUI>()
        {
            GameObject.Find("FirstWord").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("SecondWord").GetComponent<TextMeshProUGUI>(),
            GameObject.Find("ThirdWord").GetComponent<TextMeshProUGUI>(),
        };

        _buttonsList = new List<Button>()
        {
            GameObject.Find("FirstImage").GetComponent<Button>(),
            GameObject.Find("SecondImage").GetComponent<Button>(),
            GameObject.Find("ThirdImage").GetComponent<Button>(),
        };

        _result.text = "";
        _currentIndex = 0;
        _createDictionary = false;
        _hovered = false;

        GenerateAlphabetScene();
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
            }else { 
                _currentStatus += _speed * Time.deltaTime;
            }

            if (_hoveredButton.name.Contains("irst")) GameObject.Find("FirstLoadingBar").GetComponent<Image>().fillAmount = _currentStatus / 100;
            else if (_hoveredButton.name.Contains("econd")) GameObject.Find("SecondLoadingBar").GetComponent<Image>().fillAmount = _currentStatus / 100;
            else if (_hoveredButton.name.Contains("hird")) GameObject.Find("ThirdLoadingBar").GetComponent<Image>().fillAmount = _currentStatus / 100;
        }

        if (_result.text.Equals("Točno"))
        {
            _audioSource = GetComponent<AudioSource>();
            if (_audioSource == null)
            {
                _audioSource = GameObject.Find("CardsArea").AddComponent<AudioSource>();
            }
            var resultAudios = Resources.LoadAll<AudioClip>($"Audios/ResultAudios/Correct");
            _audioSource.PlayOneShot(resultAudios[_rand.Next(resultAudios.Length)]);
            _result.text = "";
            _currentIndex++;
            CheckIfGameFinished();
            GenerateAlphabetScene();
        }
    }

    private void CheckIfGameFinished()
    {
        if (_currentIndex == _letters.Count())
        {
            _currentIndex = 0;
            SceneManager.LoadScene("Main");
        }
    }

    public void CheckAnswer(Button button)
    {
        var clickedButtonPosition = 0;
        if (button.name.Contains("irst")) clickedButtonPosition = 0;
        else if (button.name.Contains("econd")) clickedButtonPosition = 1;
        else if (button.name.Contains("hird")) clickedButtonPosition = 2;

        _result.text = _correctAnswerPosition == clickedButtonPosition ? "Točno": "Netočno";

        if (_result.text.Equals("Netočno"))
        {
            _audioSource = GetComponent<AudioSource>();
            if (_audioSource == null)
            {
                _audioSource = GameObject.Find("CardsArea").AddComponent<AudioSource>();
            }
            var resultAudios = Resources.LoadAll<AudioClip>($"Audios/ResultAudios/Wrong");
            _audioSource.PlayOneShot(resultAudios[_rand.Next(resultAudios.Length)]);
        }
    }

    public void SkipLetter()
    {
        _letter.text = GenerateRandomLetter();
        _currentIndex++;
        _result.text = "";

        CheckIfGameFinished();
        GenerateAlphabetScene();
    }

    private void GenerateAlphabetScene()
    {
        _letter.text = _letters[_currentIndex];
        var l = _letter.text;
        _correctAnswerPosition = _rand.Next(_wordsList.Count);

        var correctWord = _alphabetDictionary[l][_rand.Next(_alphabetDictionary[l].Count)];
        _wordsList[_correctAnswerPosition].text = correctWord;
        _buttonsList[_correctAnswerPosition].image.sprite = Resources.Load<Sprite>($"Images/Alphabet/{correctWord.ToLowerInvariant()}");
        _clip[_correctAnswerPosition] = Resources.Load<AudioClip>($"Audios/PictureAudios/{_buttonsList[_correctAnswerPosition].image.sprite.name.ToLowerInvariant()}");

        for (int i = 0; i < _wordsList.Count; i++)
        {
            var randomLetter = GenerateRandomLetter();
            var wordPosition = _rand.Next(_alphabetDictionary[randomLetter].Count);
            var word = _alphabetDictionary[randomLetter][wordPosition];
            if (i != _correctAnswerPosition)
            {
                _wordsList[i].text = word;
                _buttonsList[i].image.sprite = Resources.Load<Sprite>($"Images/Alphabet/{word.ToLowerInvariant()}");
                _clip[i] = Resources.Load<AudioClip>($"Audios/PictureAudios/{_buttonsList[i].image.sprite.name.ToLowerInvariant()}");
            }
            //_wordsList[i].autoSizeTextContainer = true;
        }
    }

    public void PlayAudio(Button button)
    {
        _audioSource = GetComponent<AudioSource>();

        if (button.name.Contains("irst")) _audioSource.PlayOneShot(_clip[0]);
        else if (button.name.Contains("econd")) _audioSource.PlayOneShot(_clip[1]);
        else if (button.name.Contains("hird")) _audioSource.PlayOneShot(_clip[2]);
    }

    private string GenerateRandomLetter()
    {
        var l = _letter.text;
        var randomLetterPosition = 0;
        while (true)
        {
            randomLetterPosition = _rand.Next(_letters.Length);
            if (!_letters[randomLetterPosition].Equals(l)) return _letters[randomLetterPosition];
        }
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

        progress.enabled = false;
        progressCenter.enabled = false;
        progressLoading.enabled = false;
        _hovered = false;
        _currentStatus = 0;
    }
}
