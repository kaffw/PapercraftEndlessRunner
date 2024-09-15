using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtonManager : MonoBehaviour
{
    public GameObject MainCanvas, CustomizeCanvas;
    public void PlayButtonOnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void CustomizeEnterButtonOnClick()
    {
        MainCanvas.SetActive(false);
        CustomizeCanvas.SetActive(true);
    }
    public void CustomizeBackButtonOnClick()
    {
        MainCanvas.SetActive(true);
        CustomizeCanvas.SetActive(false);
    }
}
