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

    public AudioSource clickSFX;
    public bool clickOnCooldown = false;
    private void Start()
    {
        bgmAudioSource = bgmAudio.GetComponent<AudioSource>();
        clickSFX.enabled = false;
    }
    private void Update()
    {
        if (settingsCanvas.activeInHierarchy)
        {
            bgmSliderVal = bgmSlider.value;
            bgmAudioSource.volume = bgmSliderVal;

            sfxSliderVal = sfxSlider.value;
            clickSFX.volume = sfxSlider.value;
        }

        if (Input.GetMouseButtonDown(0) && !clickOnCooldown)
        {
            StartCoroutine(OnClickSFX());
        }
    }
    private IEnumerator OnClickSFX()
    {
        clickSFX.enabled = true;
        clickOnCooldown = true;
        yield return new WaitForSeconds(1f);
        clickSFX.enabled = false;
        clickOnCooldown = false;
    }
}
