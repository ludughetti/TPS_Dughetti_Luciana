using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private string scene;
    [SerializeField] private Image loadingBarFill;
    [SerializeField] private Button playGameButton;

    private bool _playButtonClicked = false;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    public void PlayGame()
    {
        _playButtonClicked = true;
    }

    IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress * 100);
            Debug.Log($"progressValue is {progressValue}");

            loadingBarFill.fillAmount = progressValue;

            if (operation.progress >= 0.9f)
            {
                playGameButton.gameObject.SetActive(true);

                while (!_playButtonClicked)
                    yield return null;

                operation.allowSceneActivation = true;
            }

            yield return null;
        }


    }
}
