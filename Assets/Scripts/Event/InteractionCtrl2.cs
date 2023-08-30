using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCtrl2 : MonoBehaviour
{
    SpriteRenderer InteractionSprite;
    // Start is called before the first frame update
    void Start()
    {
        InteractionSprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        InteractionSprite.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        InteractionSprite.enabled = false;
    }
}
