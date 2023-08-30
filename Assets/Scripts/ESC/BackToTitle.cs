using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class BackToTitle : MonoBehaviour,IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(0);
        DataManager.instance.game_temp = new bool[7];
        DataManager.instance.item_temp = new bool[23];
        DataManager.instance.DataClear();
    }
}
