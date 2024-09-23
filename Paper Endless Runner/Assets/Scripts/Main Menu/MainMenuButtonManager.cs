using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtonManager : MonoBehaviour
{
    public GameObject MainCanvas, CustomizeCanvas, SettingsCanvas;
    public void PlayButtonOnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void CustomizeEnterButtonOnClick()
    {
        MainCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);

        CustomizeCanvas.SetActive(true);
    }
    public void CustomizeBackButtonOnClick()
    {
        MainCanvas.SetActive(true);

        CustomizeCanvas.SetActive(false);
    }
    public void SettingsButtonOnClick()
    {
        MainCanvas.SetActive(false);
        CustomizeCanvas.SetActive(false);

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
