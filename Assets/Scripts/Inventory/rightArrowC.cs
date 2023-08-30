using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class rightArrowC : MonoBehaviour,IPointerClickHandler
{
    void Start()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        QuizController.current++;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
