using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tabs;

    private void Start()
    {
        if (Screen.width / 3 > 600)
        {

            foreach (var tab in tabs)
            {
                RectTransform tabRect = tab.GetComponent<RectTransform>();

                tabRect.sizeDelta = new Vector2(Screen.width / 3, tabRect.sizeDelta.y);
                tabRect.position = new Vector3(-tabRect.sizeDelta.x / 2, tabRect.position.y, tabRect.position.z);
            }
        }
    }

    public void StartAgain()
    {
        Start();
    }
    
    

    public void HideTab()
    {
        foreach (var tab in tabs)
        {
            RectTransform tabRect = tab.GetComponent<RectTransform>();
            Vector3 tabPos = tabRect.position;
            tabRect.anchoredPosition = new Vector3(-tabRect.sizeDelta.x / 2,0);
            
        }
        
        // tabs[currentTabIndex].GetComponent<RectTransform>().position -= new Vector3(100, 0, 0);
    }
    
    public void ShowCurrentTab(int currentTabIndex)
    {
        RectTransform tabRect = tabs[currentTabIndex].GetComponent<RectTransform>();

        if (tabRect.sizeDelta.x > 600)
        {
            // tabRect.position +=  new Vector3(tabRect.sizeDelta.x/2,0,0);
            tabRect.anchoredPosition =  new Vector3(tabRect.sizeDelta.x/2,0);
        }
        else
        {
            // Debug.Log(tabRect.position);
            // Debug.Log(tabRect.sizeDelta.x);
            tabRect.anchoredPosition =  new Vector3(300,0,0);
            // Debug.Log(tabRect.position);
        }
        
        // Debug.Log(tabRect.position);

        
    }


    
    
    
}
