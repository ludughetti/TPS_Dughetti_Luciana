using UnityEngine;

public class GenericAudio : AudioManager
{
    [SerializeField] private AudioClip clip;

    private void PlaySound()
    {
        PlayClip(clip);
    }
}
