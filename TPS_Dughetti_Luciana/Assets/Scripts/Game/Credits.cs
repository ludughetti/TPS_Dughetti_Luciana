using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] private string mainMenu = "MainMenu";

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void QuitGame()
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}