using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public GameObject settingsCanvas;
    public Slider bgmSlider, sfxSlider;

    public static float bgmSliderVal, sfxSliderVal;

    public GameObject bgmAudio;
    public AudioSource bgmAudioSource;

    private void Start()
    {
        bgmAudioSource = bgmAudio.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (settingsCanvas.activeInHierarchy)
        {
            bgmSliderVal = bgmSlider.value;
            bgmAudioSource.volume = bgmSliderVal;

            sfxSliderVal = sfxSlider.value;
        }
    }
}
