using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CustomizeManager : MonoBehaviour
{
    public Sprite[] aircraftSkinCollection = new Sprite[5];
    public Sprite[] fanSkinCollection = new Sprite[5];

    public Image aircraftSkinSelected;
    public Image fanSkinSelected;

    public Image aircraftImageDisplay;
    public Image fanImageDisplay;

    public static int aircraftIndex = 0, fanIndex = 0;

    public GameObject customizeCanvas;

    private void Start()
    {
        aircraftSkinSelected.sprite = aircraftSkinCollection[aircraftIndex];
        fanSkinSelected.sprite = fanSkinCollection[fanIndex];

        aircraftImageDisplay.sprite = aircraftSkinCollection[aircraftIndex];

        customizeCanvas.SetActive(false);
    }
    public void AircraftSkinNextOnClick()
    {
        aircraftIndex++;
        if (aircraftIndex >= aircraftSkinCollection.Length)
        {
            aircraftIndex = 0;
            aircraftImageDisplay.sprite = aircraftSkinCollection[aircraftIndex];
        }
        else aircraftImageDisplay.sprite = aircraftSkinCollection[aircraftIndex];
        
        Debug.Log("aircraft next skin");
    }
    public void AircraftSkinPrevOnClick()
    {
        aircraftIndex--;
        if (aircraftIndex < 0)
        {
            aircraftIndex = aircraftSkinCollection.Length - 1;
            aircraftImageDisplay.sprite = aircraftSkinCollection[aircraftIndex];
        }
        else aircraftImageDisplay.sprite = aircraftSkinCollection[aircraftIndex];

        Debug.Log("aircraft previous skin");
    }

    public void FanSkinNextOnClick()
    {
        fanIndex++;
        if (fanIndex >= fanSkinCollection.Length)
        {
            fanIndex = 0;
            fanImageDisplay.sprite = fanSkinCollection[fanIndex];
        }
        else fanImageDisplay.sprite = fanSkinCollection[fanIndex];

        Debug.Log("fan next skin");
    }
    public void FanSkinPrevOnClick()
    {
        fanIndex--;
        if (fanIndex < 0)
        {
            fanIndex = fanSkinCollection.Length - 1;
            fanImageDisplay.sprite = fanSkinCollection[fanIndex];
        }
        else fanImageDisplay.sprite = fanSkinCollection[fanIndex];

        Debug.Log("fan previous skin");
    }


}
