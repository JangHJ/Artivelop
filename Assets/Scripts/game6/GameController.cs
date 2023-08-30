using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Image image;
    public Text UITIME;
    public Text gameEnd;
    AudioSource audioSource;
    public static bool bulletMinigameFailed;


    int sec;
    // Start is called before the first frame update
    void Start()
    {
        bulletMinigameFailed = false;
        sec = 40;
        InvokeRepeating("MakeBullet", 0f, 0.5f);
        InvokeRepeating("SetTime", 1f, 1f);
        audioSource = this.GetComponent<AudioSource>();
        
    }
    void SetTime()
    {
        if (PlayerController.number >= 3)
        {
            UITIME.enabled=false;
        }
        sec = sec - 1;
        if (sec < 10)
        {
            UITIME.text = "00:0" + sec;
        }
        else
        {
            UITIME.text = "00:" + sec;
        }

        if (sec == 0)
        {
            gameEnd.text = "SUCCESS";
            
            DataManager.instance.game_temp[5] = true;
            //DataManager.instance.item_temp[15] = true;

            audioSource.Play();
        }
        else if (sec < 0)
        {
            UITIME.text = "00:00";
            
            Invoke("sceneChange", 2);
        }
        
    }
    void sceneChange()
    {
        SceneManager.LoadScene("main");
    }
    void MakeBullet()
    {
        if (image.enabled == false)
        {
            GameObject bullet;
            float switchValue = Random.value;
            float xValue = Random.Range(-3f, 3f);
            float yValue = 3.5f;



            if (bulletMinigameFailed == false && sec > 0)
            {

                bullet = Instantiate(bulletPrefab, new Vector3(xValue, 4.5f, 0), Quaternion.identity);
                AudioSource audiosource = bullet.GetComponent<AudioSource>();
                audiosource.Play();
                /*
                 if (switchValue > 0.75f)
                    {
                        bullet = Instantiate(bulletPrefab, new Vector3(xValue, 3.5f, 0), Quaternion.identity);
                    }
                    else if (switchValue > 0.5f)
                    {
                        bullet = Instantiate(bulletPrefab, new Vector3(xValue, -3.5f, 0), Quaternion.identity);
                    }
                    else if (switchValue > 0.25f)
                    {
                        bullet = Instantiate(bulletPrefab, new Vector3(-6f, yValue, 0), Quaternion.identity);
                    }
                    else
                    {
                        bullet = Instantiate(bulletPrefab, new Vector3(6f, yValue, 0), Quaternion.identity);
                    }*/
            }

        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
