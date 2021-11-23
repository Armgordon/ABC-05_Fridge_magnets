using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tab : MonoBehaviour,
    IPointerDownHandler,
    IPointerExitHandler
{
    private TabManager tabManager;
    private GameManager gameManger;
    
    void Start()
    {
        tabManager = GameObject.Find("TabLayer").GetComponent<TabManager>();
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        int currentTabIndex = gameObject.transform.GetSiblingIndex();

        tabManager.HideTab();
        
        gameManger.StopGoGame();
        
        tabManager.ShowCurrentTab(currentTabIndex);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameManger.StartGoGame();
    }

    public void Update()
    {

        
    }
}
