using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string loadingScene = "Loading";
    [SerializeField] private string creditsScene = "Credits";

    public void PlayGame()
    {
        SceneManager.LoadScene(loadingScene);
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene(creditsScene);
    }

    public void QuitGame()
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}
