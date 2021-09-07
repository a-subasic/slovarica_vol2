using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Assets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;
using System;

/*
 * ZA REDOSLIJED
 * key = ORDER
 * value = ABC, RAND
 * za IZBOR SLOVA
 * key = CHOICE
 * value = ALL, SA (SAMOGLASNICI), SU (SUGLASNICI), ML
 * za KATEGORIJE
 * key = CATEGORY
 * value = BASIC, FOOD, ANIMAL
 */

public class GameScript : MonoBehaviour
{
    private static string[] _letters = { "A", "B", "C", "Č", "Ć", "D", "DŽ", "Đ", "E", "F", "G", "H", "I", "J", "K", "L", "LJ", "M", "N", "NJ", "O", "P", "R", "S", "Š", "T", "U", "V", "Z", "Ž" };
    private static string[] _reverseLetters = { "A", "B", "C", "Ć", "D", "E", "I", "J", "K", "L", "M", "N", "NJ", "O", "P", "R", "S", "Š", "T", "U", "V", "Ž" };
    private static string[] _reverseConsonants = { "B", "C", "Ć", "D", "J", "K", "L", "M", "N", "NJ", "P", "R", "S", "Š", "T", "V", "Ž" };
    private static string[] _vowels = {"A", "E", "I", "O", "U"};
    private static string[] _consonants = { "B", "C", "Č", "Ć", "D", "DŽ", "Đ", "F", "G", "H", "J", "K", "L", "LJ", "M", "N", "NJ", "P", "R", "S", "Š", "T", "V", "Z", "Ž" };
    private static string[] _customLetters;
    private static Dictionary<string, List<string>> _alphabetDictionary, _animalsDictionary, _foodDictionary;
    private TextMeshProUGUI _letter, _result;
    private List<TextMeshProUGUI> _wordsList;
    private List<Button> _buttonsList;
    private Random _rand = new Random();
    private static int _correctAnswerPosition, _currentIndex, _vowelsIndex, _consonantsIndex, _customLettersIndex;
    AudioSource _audioSource;
    private static AudioClip[] _clip = new AudioClip[3];
    private static bool _createDictionary = true, _hovered;
    private static float _currentStatus, _speed = 15;
    private static Button _hoveredButton;
    private string _orderType, _choiceType, _categoryType, _letterType, _myLetters, _dwellStatus, _slovoStatus;
    private static string _imagesFolder;
    private int skippedLetters = 0;

    private static double percentage = 0, count = 0, points = 0;

    void Awake()
    {
        _orderType = PlayerPrefs.GetString("ORDER");
        _choiceType = PlayerPrefs.GetString("CHOICE");
        _categoryType = PlayerPrefs.GetString("CATEGORY");
        _letterType = PlayerPrefs.GetString("LETTER");
        _myLetters = PlayerPrefs.GetString("MYLETTERS");
        _dwellStatus = PlayerPrefs.GetString("DWELL");
        _slovoStatus = PlayerPrefs.GetString("SLOVO");

        if (_createDictionary)
        {
            if(_slovoStatus == "Prvo") _alphabetDictionary = AlphabetDictionary.CreateDictionary(_categoryType);
            else _alphabetDictionary = AlphabetDictionary.CreateReverseDictionary(_categoryType);
        }

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
        _vowelsIndex = 0;
        _consonantsIndex = 0;
        _customLettersIndex = 0;
        _createDictionary = false;
        _hovered = false;

        //GenerateScene();
        SetGameFolder();
        SceneGenerator();
    }

    void Update()
    {
        _orderType = PlayerPrefs.GetString("ORDER");
        _choiceType = PlayerPrefs.GetString("CHOICE");
        _categoryType = PlayerPrefs.GetString("CATEGORY");
        _letterType = PlayerPrefs.GetString("LETTER");
        _myLetters = PlayerPrefs.GetString("MYLETTERS");
        _dwellStatus = PlayerPrefs.GetString("DWELL");
        _slovoStatus = PlayerPrefs.GetString("SLOVO");

        _result = GameObject.Find("Result").GetComponent<TextMeshProUGUI>();

        SetGameTitle();
        SetGameSubtitle();
        SetGameSubSubtitle();

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
            points++;


            try
            {
                _audioSource = GetComponent<AudioSource>();
                var resultAudios = Resources.LoadAll<AudioClip>($"Audios/ResultAudios/Correct");
                //_audioSource.PlayOneShot(resultAudios[_rand.Next(resultAudios.Length)]);
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
        SceneGenerator();
    }

    public static void SetCreateDictionaryState()
    {
        _createDictionary = true;
    }

    private void SetGameFolder()
    {
        switch (_categoryType)
        {
            case "BASIC":
                _imagesFolder = "Alphabet";
                break;
            case "FOOD":
                _imagesFolder = "Food";
                break;
            case "ANIMAL":
                _imagesFolder = "Animals";
                break;
        }
    }

    private void SceneGenerator()
    {
        if (_slovoStatus == "Prvo")
        {
            switch (_choiceType)
            {
                case "ALL":
                    GenerateScene(_letters, _currentIndex);
                    break;
                case "SA":
                    GenerateScene(_vowels, _vowelsIndex);
                    break;
                case "SU":
                    GenerateScene(_consonants, _consonantsIndex);
                    break;
                case "ML":
                    _customLetters = _myLetters.Split(',');
                    GenerateScene(_customLetters, _customLettersIndex);
                    break;
            }
        }
        else
        {
            List<string> reverseML = new List<string>();

            switch (_choiceType)
            {
                case "ALL":
                    GenerateScene(_reverseLetters, _currentIndex);
                    break;
                case "SA":
                    GenerateScene(_vowels, _vowelsIndex);
                    break;
                case "SU":
                    GenerateScene(_reverseConsonants, _consonantsIndex);
                    break;
                case "ML":
                    _customLetters = _myLetters.Split(',');

                    foreach(var letter in _customLetters)
                    {
                        if (_reverseLetters.Contains(letter.ToLower())) reverseML.Add(letter);
                    }

                    string[] _reverseML = reverseML.ToArray();
                    GenerateScene(_reverseML, _customLettersIndex);
                    break;
            }
        }
    }

    private void IncreaseCurrentIndex()
    {
        switch (_choiceType)
        {
            case "ALL":
                _currentIndex++;
                break;
            case "SA":
                _vowelsIndex++;
                break;
            case "SU":
                _consonantsIndex++;
                break;
            case "ML":
                _customLettersIndex++;
                break;
        }
    }

    private void SetGameTitle()
    {
        var title = GameObject.Find("GameTitle").GetComponent<TextMeshProUGUI>();

        switch (_choiceType)
        {
            case "ALL":
                title.text = "Abeceda";
                break;
            case "SA":
                title.text = "Samoglasnici";
                break;
            case "SU":
                title.text = "Suglasnici";
                break;
            case "ML":
                title.text = "Moja slova";
                break;
        }
    }

    private void SetGameSubtitle()
    {
        var subtitle = GameObject.Find("GameSubtitle").GetComponent<TextMeshProUGUI>();

        switch (_categoryType)
        {
            case "BASIC":
                subtitle.text = "Mix";
                break;
            case "FOOD":
                subtitle.text = "Hrana";
                break;
            case "ANIMAL":
                subtitle.text = "Životinje";
                break;
        }
    }

    private void SetGameSubSubtitle()
    {
        var subsubtitle = GameObject.Find("GameSubSubtitle").GetComponent<TextMeshProUGUI>();

        switch (_slovoStatus)
        {
            case "Prvo":
                subsubtitle.text = "Prvo slovo";
                break;
            case "Zadnje":
                subsubtitle.text = "Zadnje slovo";
                break;
        }
    }

    private void CheckIfGameFinished()
    {
        if(_slovoStatus == "Prvo")
        {
            if (_currentIndex != _letters.Count() && _vowelsIndex != _vowels.Length && _consonantsIndex != _consonants.Length && (_customLetters == null || _customLettersIndex != _customLetters.Length - 1)) return;
        }
        else
        {
            if (_currentIndex != _reverseLetters.Count() && _vowelsIndex != _vowels.Length && _consonantsIndex != _reverseConsonants.Length && (_customLetters == null || _customLettersIndex != _customLetters.Length - 1)) return;
        }

        _currentIndex = 0;
        _vowelsIndex = 0;
        _consonantsIndex = 0;

        _createDictionary = true;

        if (count != 0)
        {
            count -= skippedLetters;
            percentage = (points / count) * 100;
        } else { 
            percentage = 0;
        }
        GameObject.Find("ScoreScript").GetComponent<ScoreScript>().save_score(_choiceType, " ("+_slovoStatus+")", Math.Round(percentage, 1), DateTime.Now.ToString("d/M/yyyy"));
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

        _result.text = _correctAnswerPosition == clickedButtonPosition ? "Točno": "Netočno";

        count++;
        if (_result.text.Equals("Netočno"))
        {
            try
            {
                _audioSource = GetComponent<AudioSource>();
                var resultAudios = Resources.LoadAll<AudioClip>($"Audios/ResultAudios/Wrong");
                _audioSource.PlayOneShot(resultAudios[_rand.Next(resultAudios.Length)]);

            }
            catch (Exception e) { Debug.Log(e); }
            Thread.Sleep(500);
        }
    }

    public void SkipLetter()
    {
        count++;
        //_currentIndex++;
        IncreaseCurrentIndex();
        _result.text = "";

        CheckIfGameFinished();
        SceneGenerator();
        //GenerateScene();
    }

    private bool CheckIfWordExist(string word)
    {
        if (!word.Equals("")) return false;
        IncreaseCurrentIndex();
        CheckIfGameFinished();
        SceneGenerator();

        return true;
    }

    private void GenerateScene(string[] lettersArray, int currentIndex)
    {
        _letter.text = _orderType.Equals("ABC") ? lettersArray[currentIndex] : lettersArray[_rand.Next(lettersArray.Length)];
        var l = _letter.text; 
        _letter.text = _letterType.Equals("A") ? _letter.text : _letter.text.ToLowerInvariant();
        _correctAnswerPosition = _rand.Next(_wordsList.Count);

        if (_alphabetDictionary[l].Count == 0)
        {
            skippedLetters++;
            SkipLetter();
        }

        else
        {
            var correctWord = _alphabetDictionary[l][_rand.Next(_alphabetDictionary[l].Count)];
            _wordsList[_correctAnswerPosition].text = correctWord;
            _wordsList[_correctAnswerPosition].text = _letterType.Equals("A") ? _wordsList[_correctAnswerPosition].text.ToUpperInvariant() : _wordsList[_correctAnswerPosition].text.ToLowerInvariant();
            _buttonsList[_correctAnswerPosition].image.sprite = Resources.Load<Sprite>($"Images/{_imagesFolder}/{correctWord.ToLowerInvariant()}");
            _clip[_correctAnswerPosition] = Resources.Load<AudioClip>($"Audios/{_imagesFolder}/{_buttonsList[_correctAnswerPosition].image.sprite.name.ToLowerInvariant()}");

            for (int i = 0; i < _wordsList.Count; i++)
            {
                var randomLetter = GenerateRandomLetter(i, lettersArray);
                int wordPosition;
                string word;

                if (_alphabetDictionary[randomLetter].Count > 1)
                {
                    wordPosition = _rand.Next(_alphabetDictionary[randomLetter].Count);
                    word = _alphabetDictionary[randomLetter][wordPosition];
                }
                else
                {
                    word = _alphabetDictionary[randomLetter][0];
                }

                if (CheckIfWordExist(word)) return;
                if (i != _correctAnswerPosition)
                {
                    _wordsList[i].text = word;
                    _wordsList[i].text = _letterType.Equals("A") ? _wordsList[i].text.ToUpperInvariant() : _wordsList[i].text.ToLowerInvariant();
                    _buttonsList[i].image.sprite = Resources.Load<Sprite>($"Images/{_imagesFolder}/{word.ToLowerInvariant()}");
                    _clip[i] = Resources.Load<AudioClip>($"Audios/{_imagesFolder}/{_buttonsList[i].image.sprite.name.ToLowerInvariant()}");
                }
                _wordsList[i].autoSizeTextContainer = true;
            }
        }
    }

    public void PlayAudio(Button button)
    {
        _audioSource = GetComponent<AudioSource>();

        if (button.name.Contains("irst")) _audioSource.PlayOneShot(_clip[0]);
        else if (button.name.Contains("econd")) _audioSource.PlayOneShot(_clip[1]);
        else if (button.name.Contains("hird")) _audioSource.PlayOneShot(_clip[2]);
    }

    private string GenerateRandomLetter(int currentIndex, string[] polje)
    {
        var l = _letter.text;

        var otherPreposition = 0;

        for (int i = 0; i < 3; i++)
        {
            if (i != _correctAnswerPosition && i != currentIndex)
                otherPreposition = i;
        }

        string last;
        if(_slovoStatus == "Prvo")
        {
            last = _wordsList[otherPreposition].text.Substring(0, 1).ToUpper();
        }
        else
        {
            last = _wordsList[otherPreposition].text.Substring(_wordsList[otherPreposition].text.Length - 1).ToUpper();
        }
        
        while (true)
        {
            var randomLetterPosition = _rand.Next(polje.Length);
            
            if (_alphabetDictionary[polje[randomLetterPosition]].Count() == 0) {
                continue;
            };
            if (!polje[randomLetterPosition].Equals(l.ToUpper()) && !polje[randomLetterPosition].Equals(last)) return polje[randomLetterPosition];
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
