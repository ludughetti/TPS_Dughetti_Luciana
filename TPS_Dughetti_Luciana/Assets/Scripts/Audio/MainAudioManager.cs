using System;
using UnityEngine;
using UnityEngine.UI;

public class MainAudioManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float volumeChangeAmount = 0.1f;

    public Action<float> OnVolumeChange = delegate { };

    public void VolumeUp()
    {
        Debug.Log("Volume up");
        volumeSlider.value += volumeChangeAmount;
        OnVolumeChange.Invoke(volumeSlider.value);
    }

    public void VolumeDown()
    {
        Debug.Log("Volume down");
        volumeSlider.value -= volumeChangeAmount;
        OnVolumeChange.Invoke(volumeSlider.value);
    }
}
