using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Fridge : MonoBehaviour, 
    IPointerEnterHandler, 
    IPointerExitHandler, 
    IDropHandler,
    IPointerDownHandler
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   
   
    public void OnPointerEnter(PointerEventData eventData)
    {
        //При вхождении в границы холодильника драг-символу разрешается размещение
        if (eventData.pointerDrag != null && eventData.pointerDrag.gameObject.name != "RotateCircle")
        {
            // Debug.Log(eventData.pointerDrag.gameObject);
            eventData.pointerDrag.GetComponent<Symbol>().SetCanBePlaced();
        }
        
    }    
    
    public void OnPointerExit(PointerEventData eventData)
    {
        //При выходе за границы холодильника драг-символу запрещается размещение
        if (eventData.pointerDrag != null && eventData.pointerDrag.gameObject.name != "RotateCircle")
        {
            eventData.pointerDrag.GetComponent<Symbol>().SetCantBePlaced();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {

        
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Сброс кругов при клике на свободной области холодильника
        HideAllRotateCircles();
    }

    
    public void HideAllRotateCircles()
    {
        //Скрыть все круги вращений, если они есть 
        if (GameObject.Find("RotateCircle") != null)
        {
            GameObject.Find("RotateCircle").SetActive(false);
        } 
    }
    


}
