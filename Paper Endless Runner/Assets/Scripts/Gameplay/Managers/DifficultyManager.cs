using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public GameObject flashlightEffectObject, playerSpotLight;

    void Start()
    {
        if (CustomizeManager.flashlightModeOn)
        {
            flashlightEffectObject.SetActive(true);
            playerSpotLight.SetActive(true);
        }    
    }
}
