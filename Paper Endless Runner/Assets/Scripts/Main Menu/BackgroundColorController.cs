using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorController : MonoBehaviour
{
    public SpriteRenderer[] sr;

    private void Start()
    {
        StartCoroutine(ColorCycle());
    }

    IEnumerator ColorCycle()
    {
        yield return new WaitForSeconds(10f);
        foreach (var spriteRenderer in sr)
        {
            spriteRenderer.color = new Color(70f/255f, 76f/255f, 92f/255f);
        }
        yield return new WaitForSeconds(10f);
        foreach (var spriteRenderer in sr)
        {
            spriteRenderer.color = Color.white;
        }

        yield return StartCoroutine(ColorCycle());
    }
}
