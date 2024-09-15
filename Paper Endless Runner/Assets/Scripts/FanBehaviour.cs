using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBehaviour : MonoBehaviour
{
    public GameObject papercraft;
    [SerializeField] public float xValue = 0f, yValue = 0f;

    public Camera mainCamera;

    public bool clickAction = false;

    public SpriteRenderer fanSR;
    public Sprite[] fanSkinCollection = new Sprite[5];
    void Start()
    {
        fanSR = GetComponent<SpriteRenderer>();

        fanSR.sprite = fanSkinCollection[CustomizeManager.fanIndex];
    }
    private void Update()
    {
        if (papercraft != null)
        {
            Vector3 direction = papercraft.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        if (Input.GetMouseButton(0) && !clickAction)
        {
            StartCoroutine(MouseClickAction());
        }

        MoveOnCursor();
    }
    void MoveOnCursor()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0f;
        transform.position = mouseWorldPosition;

    }
    private IEnumerator MouseClickAction()
    {
        clickAction = true;
        xValue *= 2f; yValue *= 2f;
        yield return new WaitForSeconds(.5f);
        xValue /= 2f; yValue /= 2f;
        clickAction = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D otherRB = other.GetComponent<Rigidbody2D>();

            Vector2 fanDirection = transform.right;
            Vector2 combinedForce = fanDirection * xValue  + Vector2.up * yValue ;
            otherRB.AddForce(combinedForce, ForceMode2D.Force);
        }
    }

}
