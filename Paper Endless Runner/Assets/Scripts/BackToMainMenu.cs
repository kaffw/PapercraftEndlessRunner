using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToMainMenu : MonoBehaviour
{
    public GameObject gameOverCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) Pause();
    }
    public void Pause()
    {
        if (!UserRecordManager.gameOver)
        {
            Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
            gameOverCanvas.SetActive(Time.timeScale == 0);
        }
    }
    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
