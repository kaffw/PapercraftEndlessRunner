using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class ButtonHoverDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    public Image image;

    public bool isHovering = false;

    private void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        
        image.fillAmount = 0f;
    }
    void Update()
    {
        if (!isHovering) image.fillAmount = 0f;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        StartCoroutine(FillImage());
        Debug.Log("Mouse entered the button.");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        image.fillAmount = 0f;
        Debug.Log("Mouse exited the button.");
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

    }
}
