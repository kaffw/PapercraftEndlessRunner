using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncircleOnClickEffect : MonoBehaviour
{
    public Image image;
    public bool cooldown = false;
    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void Encircle()
    {
        if (!cooldown)
        {
            cooldown = true;
            StartCoroutine(FillImage());
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

        image.fillAmount = 0f;

    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        cooldown = false;
    }
}
