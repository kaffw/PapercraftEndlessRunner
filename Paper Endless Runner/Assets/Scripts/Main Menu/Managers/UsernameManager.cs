using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UsernameManager : MonoBehaviour
{
    public static string username;
    public TMP_InputField inputField;
    public TextMeshProUGUI usernameText;
    public AudioManager audioManager;
    void Start()
    {
        if (username != null)
        {
            inputField.text = username;
        }

        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        inputField.onValueChanged.AddListener(OnValueChanged);
    }
    public void SetUsername()
    {
        username = inputField.text;
    }

    public void RequireUsername()
    {
        Debug.Log("Username_required!");
        //SFX Error play      
        audioManager.PlayErrorSFX();

        StartCoroutine(HighlightText());
    }

    private IEnumerator HighlightText()
    {
        usernameText.color = Color.red;
        yield return new WaitForSeconds(3f);
        usernameText.color = Color.black;
    }

    private void OnValueChanged(string input)
    {
        inputField.text = input.Replace(" ", "");
    }
}
