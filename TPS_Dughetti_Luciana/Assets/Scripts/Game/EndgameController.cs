using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgameController : MonoBehaviour
{
    [SerializeField] private string mainMenu = "MainMenu";
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject endgameScreen;
    [SerializeField] private TMP_Text victory;
    [SerializeField] private TMP_Text defeat;
    [SerializeField] private TMP_Text killCounter;

    private readonly float _timePaused = 0f;
    private readonly float _timeUnpaused = 1f;

    public void ShowEndgameScreen(bool isVictory, int killCount)
    {
        Debug.Log($"killCount is {killCount}");

        Time.timeScale = _timePaused;

        victory.gameObject.SetActive(isVictory);
        defeat.gameObject.SetActive(!isVictory);
        killCounter.text = killCount.ToString();

        endgameScreen.SetActive(true);
        playerUI.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = _timeUnpaused;
        SceneManager.LoadScene(mainMenu);
    }

    public void QuitGame()
    {
        Time.timeScale = _timeUnpaused;
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}
