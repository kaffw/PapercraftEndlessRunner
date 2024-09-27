using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtonManager : MonoBehaviour
{
    public GameObject MainCanvas, PlayCanvas, LeaderboardsCanvas, SettingsCanvas;
    public void PlayButtonOnClick()
    {
        //SceneManager.LoadScene(2);
    }
    public void StartGameButtonOnClick()
    {
        UsernameManager usernameManager = GameObject.Find("Username Manager").GetComponent<UsernameManager>();
        usernameManager.SetUsername();

        if (UsernameManager.username != "") SceneManager.LoadScene(2);
        else usernameManager.RequireUsername();
    }

    public void CustomizeEnterButtonOnClick()
    {
        MainCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);
        LeaderboardsCanvas.SetActive(false);

        PlayCanvas.SetActive(true);
    }
    public void CustomizeBackButtonOnClick()
    {
        MainCanvas.SetActive(true);

        PlayCanvas.SetActive(false);
    }
    public void LeaderboardsButtonOnClick()
    {
        MainCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);
        PlayCanvas.SetActive(false);

        LeaderboardsCanvas.SetActive(true);
    }

    public void LeaderboardsBackButtonOnClick()
    {
        MainCanvas.SetActive(true);

        LeaderboardsCanvas.SetActive(false);

    }
    public void SettingsButtonOnClick()
    {
        MainCanvas.SetActive(false);
        PlayCanvas.SetActive(false);
        LeaderboardsCanvas.SetActive(false);

        SettingsCanvas.SetActive(true);
    }
    public void SettingsBackButtonOnClick()
    {
        MainCanvas.SetActive(true);

        SettingsCanvas.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Application Quit!");
        Application.Quit();
    }
}
