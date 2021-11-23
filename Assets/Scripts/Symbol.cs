using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Symbol : MonoBehaviour, 
    IPointerDownHandler,
    IPointerUpHandler, 
    IPointerEnterHandler, 
    IPointerExitHandler, 
    IBeginDragHandler, 
    IEndDragHandler, 
    IDragHandler
{
    
    [SerializeField] private Canvas canvas;
    private Fridge fridge;
    private GameManager gameManager;
    
    
    
    private List<Component> Components = new List<Component>();
    private Component[] array_comp;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private GameObject rotateCircle;

    private bool canBePlaced = false;

    private string symbolText;

    private bool isSymbolOnInstantiate = false;
    
    private void Start()
    {

        
        rotateCircle = gameObject.transform.GetChild(0).gameObject;
        fridge = GameObject.Find("Fridge").GetComponent<Fridge>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (gameManager.GetStateOfTheGame())
        {
            gameObject.transform.SetSiblingIndex(gameManager.GetSiblingIndex());    
        }
        

        if (gameObject.name.StartsWith("symb"))
        {
            gameObject.name = "symb";
        }

        symbolText = gameObject.GetComponentInChildren<TextMeshProUGUI>().text.ToLower();

        // Debug.Log(symbolText);

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        // canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        // canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;


        ShowRotateCircle();


    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log(symbolText);
        
        
        string tag = gameObject.transform.GetChild(1).gameObject.tag;
        gameManager.PlaySymbolSound(symbolText, tag);

        fridge.HideAllRotateCircles();
       
        if (!CreateCopyOfSymbol())
        {
            ShowRotateCircle();
        };
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!canBePlaced)
        {
            Destroy(gameObject);
        }  
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Debug.Log("pointer enter symb");
        
    }    
    
    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("pointer exit");
    }

    public void SetCanBePlaced()
    {
        // Debug.Log("can be placed");
        canBePlaced = true;
        
    }
    public void SetCantBePlaced()
    {
        // Debug.Log("can NOT be placed");
        canBePlaced = false;
    }

    private bool CreateCopyOfSymbol()
    {
        
        if (gameObject.name.StartsWith("symb"))
        {
            gameManager.PutSiblingIndex(transform.GetSiblingIndex());
            Instantiate(gameObject, transform.position + new Vector3(0, 0, 1), transform.rotation, transform.parent);
            gameObject.name = "copy_symb";
            gameObject.transform.SetParent(GameObject.Find("Fridge_layer").transform);
            return true;
        }
        return false;
        
    }
    private void ShowRotateCircle()
    {
        rotateCircle.SetActive(true);
    }
    
}
