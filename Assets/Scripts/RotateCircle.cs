using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateCircle : MonoBehaviour, IPointerDownHandler,IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private Vector2 prevtDragPos;
    private int rotateAngle = 90;
    private GameObject symbTextGO;
    private GameObject symbTextGeomGO;
  
    
    void Start()
    {
        symbTextGO = gameObject.transform.parent.transform.GetChild(1).gameObject;

        if (gameObject.transform.parent.transform.childCount > 2)
        {
            symbTextGeomGO = gameObject.transform.parent.transform.GetChild(2).gameObject;
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        prevtDragPos = eventData.position;
        // Debug.Log(startDragPos);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        RotateCircleWithSymbol(eventData.position);
    }

    private void RotateCircleWithSymbol(Vector2 currentDragPosition)
    {
        //Проверяем новое положение курсора относительное предыдущего по осям
        //и вращаем круг по оси Z

        //првоеряем выше или ниже объекта курсор
        //в зависимости от этого задаем направление вращения
        if (currentDragPosition.y > gameObject.transform.position.y)
        {
            if ((currentDragPosition.x - prevtDragPos.x) > 0.0f)
            {
                gameObject.transform.rotation = gameObject.transform.rotation * new Quaternion(0,0,1,-rotateAngle);
            }
            else if ((currentDragPosition.x - prevtDragPos.x) < 0.0f)
            {
                gameObject.transform.rotation = gameObject.transform.rotation * new Quaternion(0,0,1,rotateAngle);
            } 
        }
        else
        {
            if ((currentDragPosition.x - prevtDragPos.x) < 0.0f)
            {
                gameObject.transform.rotation = gameObject.transform.rotation * new Quaternion(0,0,1,-rotateAngle);
            }
            else if ((currentDragPosition.x - prevtDragPos.x) > 0.0f)
            {
                
                gameObject.transform.rotation = gameObject.transform.rotation * new Quaternion(0,0,1,rotateAngle);
            }
        }
        
        //првоеряем справа или слева от объекта курсор
        //в зависимости от этого задаем направление вращения
        if (currentDragPosition.x < gameObject.transform.position.x)
        {
            if ((currentDragPosition.y - prevtDragPos.y) > 0.0f)
            {
                gameObject.transform.rotation = gameObject.transform.rotation * new Quaternion(0,0,1,-rotateAngle);
            }
            else if ((currentDragPosition.y - prevtDragPos.y) < 0.0f)
            {
                gameObject.transform.rotation = gameObject.transform.rotation * new Quaternion(0,0,1,rotateAngle);
            } 
        }
        else
        {
            if ((currentDragPosition.y - prevtDragPos.y) < 0.0f)
            {
                gameObject.transform.rotation = gameObject.transform.rotation * new Quaternion(0,0,1,-rotateAngle);
            }
            else if ((currentDragPosition.y - prevtDragPos.y) > 0.0f)
            {
                gameObject.transform.rotation = gameObject.transform.rotation * new Quaternion(0,0,1,rotateAngle);
            }
        }
        
        //Вместе с кругом вращаем символ
        symbTextGO.transform.rotation = gameObject.transform.rotation;
        if (symbTextGeomGO != null)
        {
            symbTextGeomGO.transform.rotation = gameObject.transform.rotation;
        }
        //запоминаем текущую позицию для следующего вызова
        prevtDragPos = currentDragPosition;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {


    }
    
    public void OnPointerDown(PointerEventData eventData)
    {


    }

    public void OnPointerUp(PointerEventData eventData)
    {
  
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }    
    
    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    
}
