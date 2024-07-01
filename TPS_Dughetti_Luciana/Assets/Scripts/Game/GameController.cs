using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int killCountToWin = 50;
    [SerializeField] private TMP_Text killCountText;
    [SerializeField] private EndgameController endgameController;
    [SerializeField] private PauseController pauseController;
    [SerializeField] private InputReader inputReader;
    [SerializeField] private MainAudioManager mainAudioManager;

    private int _killCount = 0;

    private void OnEnable()
    {
        inputReader.OnPauseInput += TogglePauseScreen;
        inputReader.OnVolumeUpInput += IncreaseVolume;
        inputReader.OnVolumeDownInput += DecreaseVolume;
    }

    private void OnDisable()
    {
        inputReader.OnPauseInput -= TogglePauseScreen;
        inputReader.OnVolumeUpInput -= IncreaseVolume;
        inputReader.OnVolumeDownInput -= DecreaseVolume;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void AddKillToCounter()
    {
        Debug.Log($"{name}: Adding kill to counter. Current kills: {_killCount}");
        _killCount++;
        UpdateKillCounterText();

        if (_killCount == killCountToWin)
        {
            TriggerEndgameScreen(true);
        }
    }

    private void UpdateKillCounterText()
    {
        killCountText.text = _killCount.ToString();
    }

    public void TriggerEndgameScreen(bool isVictory)
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        endgameController.ShowEndgameScreen(isVictory, _killCount);
    }

    public void TogglePauseScreen()
    {
        pauseController.TogglePauseScreen();
    }

    private void IncreaseVolume()
    {
        mainAudioManager.VolumeUp();
    }

    private void DecreaseVolume()
    {
        mainAudioManager.VolumeDown();
    }
}
