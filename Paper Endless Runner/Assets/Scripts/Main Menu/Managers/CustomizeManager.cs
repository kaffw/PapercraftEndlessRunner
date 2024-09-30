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

    public bool acNextCD, acPrevCD, fanNextCD, fanPrevCD;

    public static bool flashlightModeOn, hardModeOn;
    public bool flashlightCD, hardCD;

    private void Start()
    {
        aircraftSkinSelected.sprite = aircraftSkinCollection[aircraftIndex];
        fanSkinSelected.sprite = fanSkinCollection[fanIndex];

        aircraftImageDisplay.sprite = aircraftSkinCollection[aircraftIndex];

        customizeCanvas.SetActive(false);

        acNextCD = acPrevCD = fanNextCD = fanPrevCD = false;
        flashlightModeOn = hardModeOn = flashlightCD = hardCD = false;
    }
    public void AircraftSkinNextOnClick()
    {
        if (!acNextCD)
        {
            aircraftIndex++;
            if (aircraftIndex >= aircraftSkinCollection.Length)
            {
                aircraftIndex = 0;
                aircraftImageDisplay.sprite = aircraftSkinCollection[aircraftIndex];
            }
            else aircraftImageDisplay.sprite = aircraftSkinCollection[aircraftIndex];

            acNextCD = true;
            StartCoroutine(Cooldown(1));

            Debug.Log("aircraft next skin");
        }
    }
    public void AircraftSkinPrevOnClick()
    {
        if (!acPrevCD)
        {
            aircraftIndex--;
            if (aircraftIndex < 0)
            {
                aircraftIndex = aircraftSkinCollection.Length - 1;
                aircraftImageDisplay.sprite = aircraftSkinCollection[aircraftIndex];
            }
            else aircraftImageDisplay.sprite = aircraftSkinCollection[aircraftIndex];

            acPrevCD = true;
            StartCoroutine(Cooldown(2));

            Debug.Log("aircraft previous skin");
        }
    }

    public void FanSkinNextOnClick()
    {
        if (!fanNextCD)
        {
            fanIndex++;
            if (fanIndex >= fanSkinCollection.Length)
            {
                fanIndex = 0;
                fanImageDisplay.sprite = fanSkinCollection[fanIndex];
            }
            else fanImageDisplay.sprite = fanSkinCollection[fanIndex];

            fanNextCD = true;
            StartCoroutine(Cooldown(3));

            Debug.Log("fan next skin");
        }
    }
    public void FanSkinPrevOnClick()
    {
        if (!fanPrevCD)
        {
            fanIndex--;
            if (fanIndex < 0)
            {
                fanIndex = fanSkinCollection.Length - 1;
                fanImageDisplay.sprite = fanSkinCollection[fanIndex];
            }
            else fanImageDisplay.sprite = fanSkinCollection[fanIndex];

            fanPrevCD = true;
            StartCoroutine(Cooldown(4));

            Debug.Log("fan previous skin");
        }
    }

    public void SetFlashlightDifficultyOn()
    {
        if (!flashlightCD)
        {
            flashlightModeOn = true;
            StartCoroutine(Cooldown(1));
        }
    }

    public void SetHardDifficultyOn()
    {
        if (!hardCD)
        {
            hardModeOn = true;
            StartCoroutine(Cooldown(1));
        }
    }

    private IEnumerator Cooldown(int val)
    {
        switch (val)
        {
            case 1:
                yield return new WaitForSeconds(1f);
                acNextCD = false;
            break;

            case 2:
                yield return new WaitForSeconds(1f);
                acPrevCD = false;
            break;

            case 3:
                yield return new WaitForSeconds(1f);
                fanNextCD = false;
            break;

            case 4:
                yield return new WaitForSeconds(1f);
                fanPrevCD = false;
            break;
        }
    }
}
