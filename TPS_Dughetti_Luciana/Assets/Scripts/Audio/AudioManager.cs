using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected MainAudioManager mainAudioManager;

    private void OnEnable()
    {
        mainAudioManager.OnVolumeChange += UpdateVolume;
    }

    private void OnDisable()
    {
        mainAudioManager.OnVolumeChange -= UpdateVolume;
    }

    public void PlayClip(AudioClip clip)
    {
        if (audioSource.clip != clip)
            audioSource.clip = clip;

        audioSource.Play();
    }

    private void UpdateVolume(float value)
    {
        audioSource.volume = value;
    }
}
