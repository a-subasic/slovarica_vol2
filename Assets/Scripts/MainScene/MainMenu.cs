using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
}
