using UnityEngine;

public class WeaponAudio
    : AudioManager
{
    [SerializeField] private AudioClip attackSoundClip;

    public void PlayAttackSound()
    {
        if(attackSoundClip != null)
            PlayClip(attackSoundClip);
    }
}
