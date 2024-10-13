using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopAudioManager : MonoBehaviour
{
    public GameObject gameLoopBGM;
    public GameObject[] gameLoopSFX;
    private void Start()
    {
        foreach(var sfx in gameLoopSFX)
        {
            AudioSource currSFX = sfx.GetComponent<AudioSource>();
            currSFX.volume = AudioManager.sfxSliderVal; // 1f

            sfx.SetActive(false);
        }

        AudioSource currBGM = gameLoopBGM.GetComponent<AudioSource>();
        currBGM.volume = AudioManager.bgmSliderVal;
        
    }
    public void PlayGameOverSFX()
    {
        
        StartCoroutine(Cooldown(0, 3f));
    }

    private IEnumerator Cooldown(int sfxIndex,float cdTime)
    {
        gameLoopSFX[sfxIndex].SetActive(true);
        yield return new WaitForSecondsRealtime(cdTime);
        gameLoopSFX[sfxIndex].SetActive(false);
    }
}
