using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
   public Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float a = 5;

    void Update()
    {

        if (image.isActiveAndEnabled == false)
        {

            if (transform.position.y < -3.0f)

            {

                a = Random.Range(3.0f, 8.0f);

            }
            else if (transform.position.y > 0.8f)

            {

                a = Random.Range(-8.0f, -3.0f);

            }



            transform.Translate(Vector3.up * 1.0f * Time.deltaTime * a);


        }
      

    }//end update

}
