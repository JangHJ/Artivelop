using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    float time = 0;
    public float randomTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(time > Random.Range(4, 8))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            time = 0;
        }
        if (time > Random.Range(1, 3))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            time = 0;
        }
        time += Time.deltaTime;
    }
}
