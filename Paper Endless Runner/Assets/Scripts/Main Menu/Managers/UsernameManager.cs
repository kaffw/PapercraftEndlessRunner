using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UsernameManager : MonoBehaviour
{
    public static string username;
    public TMP_InputField inputField;
    public TextMeshProUGUI usernameText;

    void Start()
    {
        if (username != null)
        {
            inputField.text = username;
        }    
    }
    public void SetUsername()
    {
        username = inputField.text;
    }

    public void RequireUsername()
    {
        Debug.Log("Username required!");
        //SFX Error play
        AudioManager audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        audioManager.PlayErrorSFX();

        StartCoroutine(HighlightText());
    }

    private IEnumerator HighlightText()
    {
        usernameText.color = Color.red;
        yield return new WaitForSeconds(3f);
        usernameText.color = Color.black;
    }
}
