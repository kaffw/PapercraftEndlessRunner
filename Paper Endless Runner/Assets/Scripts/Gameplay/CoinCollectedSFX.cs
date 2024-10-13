using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectedSFX : MonoBehaviour
{
    AudioSource ccSFX;
    void Start()
    {
        ccSFX = GetComponent<AudioSource>();
        ccSFX.volume = AudioManager.sfxSliderVal; // 1f
        
        Destroy(gameObject, 1.1f);
    }
}
