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

    public AudioSource[] clickSFX;
    public bool clickOnCooldown = false;

    public static bool instanceTriggered = false;
    private void Start()
    {
        bgmAudioSource = bgmAudio.GetComponent<AudioSource>();
        //clickSFX.enabled = false;
        foreach (var sfx in clickSFX)
        {
            sfx.enabled = false;
        }

        if (!instanceTriggered)
        {
            instanceTriggered = true;
            bgmSliderVal = 1f;
            sfxSliderVal = 1f;
        }
    }
    private void Update()
    {
        if (settingsCanvas.activeInHierarchy)
        {
            bgmSliderVal = bgmSlider.value;
            bgmAudioSource.volume = bgmSlider.value;

            sfxSliderVal = sfxSlider.value;
            
            foreach (var sfx in clickSFX)
            {
                sfx.volume = sfxSlider.value;
            }
        }

        if (Input.GetMouseButtonDown(0) && !clickOnCooldown)
        {
            StartCoroutine(OnClickSFX(0));
        }
    }
    public void PlayErrorSFX()
    {
        StartCoroutine(OnClickSFX(1));
    } 
    private IEnumerator OnClickSFX(int index)
    {
        clickSFX[index].enabled = true;
        clickOnCooldown = true;
        yield return new WaitForSeconds(1f);
        clickSFX[index].enabled = false;
        clickOnCooldown = false;
    }
}
