using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MarcLevel");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("mainGame");
    }


    public void QuitGame()
    {
        Application.Quit();
    }

     public void BackToMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
