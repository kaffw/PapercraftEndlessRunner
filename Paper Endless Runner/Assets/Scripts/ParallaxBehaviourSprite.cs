using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviourSprite : MonoBehaviour
{
    public float spriteSpeed;
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x - Time.deltaTime * spriteSpeed, transform.localPosition.y, transform.localPosition.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BorderBound"))
        {
            transform.localPosition = new Vector3(transform.localPosition.x + 17.2f, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
