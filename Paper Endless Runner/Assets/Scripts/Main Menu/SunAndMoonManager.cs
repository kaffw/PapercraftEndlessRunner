using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAndMoonManager : MonoBehaviour
{
    public float timer = 0f;
    public GameObject sun, moon;

    public Camera mainCamera;
    private void Start()
    {
        sun = GameObject.Find("Sun");
        moon = GameObject.Find("Moon");
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        moon.SetActive(false);
        StartCoroutine(SunMoonCycle());
    }

    IEnumerator SunMoonCycle()
    {
        yield return new WaitForSeconds(10f);
        mainCamera.backgroundColor = new Color(46f/255f, 68f/255f, 130f/255f);
        sun.SetActive(false);
        moon.SetActive(true);
        yield return new WaitForSeconds(10f);
        mainCamera.backgroundColor = new Color(135f/255f, 206f/255f, 250f/255f);
        sun.SetActive(true);
        moon.SetActive(false);

        yield return StartCoroutine(SunMoonCycle());
    }
}
