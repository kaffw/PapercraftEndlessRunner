using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftBehaviour : MonoBehaviour
{
    public SpriteRenderer aircraftSR;
    public Sprite[] aircraftSkinCollection = new Sprite[5];
    void Start()
    {
        aircraftSR = GetComponent<SpriteRenderer>();

        aircraftSR.sprite = aircraftSkinCollection[CustomizeManager.aircraftIndex];
    }
}
