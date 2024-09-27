using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EncircleSetDifficulty : MonoBehaviour
{
    public Image image;
    public bool cooldown = false;
    public bool filled = false;
    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void Encircle()
    {
        if (!cooldown)
        {
            cooldown = true;
            if (!filled) StartCoroutine(FillImage());
            else StartCoroutine(UnFillImage());
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator FillImage()
    {
        float duration = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            image.fillAmount = Mathf.Lerp(0f, 1f, elapsed / duration);
            yield return null;
        }

        image.fillAmount = 1f;
        
        filled = true;
    }
    private IEnumerator UnFillImage()
    {
        float duration = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            image.fillAmount = Mathf.Lerp(1f, 0f, elapsed / duration);
            yield return null;
        }

        image.fillAmount = 0f;

        filled = false;
    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        cooldown = false;
    }
}
